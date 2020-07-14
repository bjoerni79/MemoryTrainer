using MemoryTrainer.Misc;
using MemoryTrainer.MMVM;
using MemoryTrainer.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace MemoryTrainer.ViewModel
{
    public class CardGameViewModel : ViewModelBase
    {
        private bool cardsLeft;
        private Deck deck = new Deck();

        public CardGameViewModel()
        {
            NextCards = new DefaultCommand(OnNextCards);
            New = new DefaultCommand(OnNew);
            Close = new DefaultCommand(OnClose);

            OnNew();
        }

        public string InstructionText { get; private set; }

        public int MaxNumberOfCards { get; private set; }

        public int CurrentNumberOfCards { get; private set; }

        public ObservableCollection<PAOItem> RecentCards { get; private set; }

        public PlayingCard PersonCard { get; private set; }

        public PlayingCard ActionCard { get; private set; }

        public PlayingCard ObjectCard { get; private set; }

        public ICommand NextCards { get; private set; }

        public ICommand New { get; private set; }

        public ICommand Close { get; private set; }

        private void OnNextCards()
        {
            if (cardsLeft)
            {
                PersonCard = deck.GetNext();
                ActionCard = deck.GetNext();
                ObjectCard = deck.GetNext();

                RaisePropertyChange("PersonCard");
                RaisePropertyChange("ActionCard");
                RaisePropertyChange("ObjectCard");

                CurrentNumberOfCards += 3;
                RaisePropertyChange("CurrentNumberOfCards");

                // Check for blank cards. 
                var isEndOfDeck = (PersonCard == PlayingCard.Blank) || (ActionCard == PlayingCard.Blank) || (ObjectCard == PlayingCard.Blank);
                if (isEndOfDeck)
                {
                    //TODO:  Switch to recall state!
                    InstructionText = "Well done!  Now prepare yourself for the recalling process. The list on the right shows the last cards later. What are the next three cards? Please click next when you are ready.";
                    CurrentNumberOfCards = 0;

                    RaisePropertyChange("InstructionText");
                    RaisePropertyChange("CurrentNumberOfCards");

                    deck.ResetIndex();
                    cardsLeft = false;
                }
            }
            else
            {
                if (deck.IsEndOfDeck())
                {
                    InstructionText = "That's it. Click New for a new round.";
                    CurrentNumberOfCards = 52;

                    RaisePropertyChange("InstructionText");
                    RaisePropertyChange("CurrentNumberOfCards");
                }
                else
                {
                    // Recall Mode
                    PersonCard = deck.GetNext();
                    ActionCard = deck.GetNext();
                    ObjectCard = deck.GetNext();

                    RaisePropertyChange("PersonCard");
                    RaisePropertyChange("ActionCard");
                    RaisePropertyChange("ObjectCard");

                    CurrentNumberOfCards += 3;
                    RaisePropertyChange("CurrentNumberOfCards");

                    // Add the latest on top
                    var newRecentList = new List<PAOItem>();
                    var paoItem = new PAOItem() { Person = PersonCard, Action = ActionCard, Object = ObjectCard };
                    newRecentList.Add(paoItem);

                    newRecentList.AddRange(RecentCards);

                    RecentCards = new ObservableCollection<PAOItem>(newRecentList);
                    RaisePropertyChange("RecentCards");
                }
            }
        }

        private void OnNew()
        {
            // Create a new deck and shuffle it.
            deck = new Deck();
            deck.Shuffle();
            cardsLeft = true;

            // Update the UI
            InstructionText = "Prepare yourself and store the following cards with the help of your choosen strategy.";
            MaxNumberOfCards = 52;
            CurrentNumberOfCards = 0;
            RecentCards = new ObservableCollection<PAOItem>();

            RaisePropertyChange("InstructionText");
            RaisePropertyChange("MaxNumberOfCards");
            RaisePropertyChange("CurrentNumberOfCards");
            RaisePropertyChange("RecentCards");

            OnNextCards();
        }

        private void OnClose()
        {
            InternalClose();
        }
    }
}
