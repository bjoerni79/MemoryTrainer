using MemoryTrainer.Lib;
using MemoryTrainer.MMVM;
using MemoryTrainer.MVVM;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MemoryTrainer.ViewModel
{
    public class CardGameViewModel : ViewModelBase
    {
        private Deck deck = new Deck();

        public CardGameViewModel()
        {
            deck.Shuffle();

            NextCards = new DefaultCommand(OnNextCards);
            Reset = new DefaultCommand(OnReset);
            OnNextCards();
        }

        public PlayingCard PersonCard { get; private set; }

        public PlayingCard ActionCard { get; private set; }

        public PlayingCard ObjectCard { get; private set; }

        public ICommand NextCards { get; private set; }

        public ICommand Reset { get; private set; }

        private void OnNextCards()
        {
            PersonCard = deck.GetNext();
            ActionCard = deck.GetNext();
            ObjectCard = deck.GetNext();

            RaisePropertyChange("PersonCard");
            RaisePropertyChange("ActionCard");
            RaisePropertyChange("ObjectCard");
        }

        private void OnReset()
        {
            deck = new Deck();
            deck.Shuffle();

            OnNextCards();
        }
    }
}
