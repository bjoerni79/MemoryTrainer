using MemoryTrainer.Misc;
using MemoryTrainer.MMVM;
using MemoryTrainer.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MemoryTrainer.ViewModel
{
    public class CardGameViewModel : ViewModelBase
    {
        private bool cardsLeft;
        private bool showEndOfDeck;
        private Deck deck = new Deck();

        public CardGameViewModel()
        {
            NextCards = new DefaultCommand(OnNextCards);
            New = new DefaultCommand(OnNew);
            Close = new DefaultCommand(OnClose);
            MarkAsOk = new DefaultCommand(() => OnMarkAs(true),IsRecallMode);
            MarkAsFailed = new DefaultCommand(() => OnMarkAs(false),IsRecallMode);
            SelectDeck = new ParameterCommand(OnSelectDeck);


            // Init the decks
            var facade = new ContainerFacade();
            var settings = facade.Get<GameSetting>("SETTINGS") as GameSetting;

            AvailableDecks = new ObservableCollection<DeckConfiguration>(settings.AvailableDecks);
            CurrentDeck = AvailableDecks.First();

            // Start the game
            OnNew();
        }

        #region UI elements

        public string InstructionText { get; private set; }

        public int MaxNumberOfCards { get; private set; }

        public int CurrentNumberOfCards { get; private set; }

        public ObservableCollection<PAOItem> RecentCards { get; private set; }

        public ObservableCollection<DeckConfiguration> AvailableDecks { get; private set; }

        public DeckConfiguration CurrentDeck {
            get;
            set;
        }

        public PlayingCard PersonCard { get; private set; }

        public PlayingCard ActionCard { get; private set; }

        public PlayingCard ObjectCard { get; private set; }

        #endregion

        #region Commands

        public DefaultCommand NextCards { get; private set; }

        public DefaultCommand New { get; private set; }

        public DefaultCommand Close { get; private set; }

        public DefaultCommand MarkAsOk { get; private set; }

        public DefaultCommand MarkAsFailed { get; private set; }

        public ParameterCommand SelectDeck { get; private set; }

        #endregion

        #region Game Logic

        private void OnSelectDeck(object parameter)
        {
            // Run some type checks before we start using it.
            int index;
            var selectedDeck = parameter as string;
            if (Int32.TryParse(selectedDeck,out index))
            {
                // Try to get the deck at this index
                var deckAtIndex = AvailableDecks.ElementAtOrDefault(index);
                if (deckAtIndex != null)
                {
                    // Found. Apply and update UI
                    CurrentDeck = deckAtIndex;
                    RaisePropertyChange("CurrentDeck");
                }
            }

        }

        private void OnMarkAs(bool passed)
        {
            if (RecentCards != null && RecentCards.Any())
            {
                var currentItem = RecentCards.First();
                currentItem.RecallOk = passed;

                currentItem.Refresh();
            }

        }

        private bool IsRecallMode()
        {
            return !cardsLeft;
        }

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
                    CurrentNumberOfCards = CurrentDeck.Cards.Count();

                    RaisePropertyChange("InstructionText");
                    RaisePropertyChange("CurrentNumberOfCards");
                }
                else
                {
                    if (showEndOfDeck)
                    {
                        PersonCard = PlayingCard.Deck;
                        ActionCard = PlayingCard.Deck;
                        ObjectCard = PlayingCard.Deck;

                        showEndOfDeck = false;
                    }
                    else
                    {
                        // Recall Mode
                        PersonCard = deck.GetNext();
                        ActionCard = deck.GetNext();
                        ObjectCard = deck.GetNext();

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

                RaisePropertyChange("PersonCard");
                RaisePropertyChange("ActionCard");
                RaisePropertyChange("ObjectCard");
            }

            // Trigger the Enabled / Disabled lifecycle of the OK and Failed buttons
            MarkAsFailed.Refresh();
            MarkAsOk.Refresh();
        }

        private void OnNew()
        {
            InstructionText = "Prepare yourself and store the following cards with the help of your choosen strategy.";
            MaxNumberOfCards = CurrentDeck.Cards.Count();
            CurrentNumberOfCards = 0;
            RecentCards = new ObservableCollection<PAOItem>();

            // Create a new deck and shuffle it.
            var cards = CurrentDeck.Cards;
            deck = new Deck(cards);
            deck.Shuffle();
            cardsLeft = true;
            showEndOfDeck = true;

            // Update the UI
            RaisePropertyChange("InstructionText");
            RaisePropertyChange("MaxNumberOfCards");
            RaisePropertyChange("CurrentNumberOfCards");
            RaisePropertyChange("RecentCards");
            RaisePropertyChange("AvailableDecks");
            RaisePropertyChange("CurrentDeck");

            OnNextCards();
        }

        private void OnClose()
        {
            InternalClose();
        }

        #endregion
    }
}
