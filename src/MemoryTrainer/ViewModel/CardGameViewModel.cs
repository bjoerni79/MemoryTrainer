using MemoryTrainer.Lib;
using MemoryTrainer.MMVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryTrainer.ViewModel
{
    public class CardGameViewModel : ViewModelBase
    {
        public CardGameViewModel()
        {
            TestCard = PlayingCard.Club_10;
        }

        public PlayingCard TestCard { get; private set; }

    }
}
