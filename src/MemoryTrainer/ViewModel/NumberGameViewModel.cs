using Generic.MVVM;
using MemoryTrainer.Environment;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryTrainer.ViewModel
{
    public class NumberGameViewModel : PageViewModel
    {
        private readonly NumberGenerator numberGenerator;
        private NumberSet numberSet;

        public NumberGameViewModel()
        {
            numberGenerator = new NumberGenerator();
            numberSet = new NumberSet();

            // Bind the commands
            Close = new DefaultCommand(OnClose);


        }

        public IRefreshCommand Close { get; private set; }

        private void OnGenerateVisaCard()
        {

        }

        private void OnGenerateNumber()
        {

        }


        public void OnClose()
        {
            InternalClose();
        }
    }
}
