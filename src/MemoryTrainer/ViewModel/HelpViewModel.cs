using MemoryTrainer.MMVM;
using MemoryTrainer.MVVM;
using MemoryTrainer.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MemoryTrainer.ViewModel
{
    public class HelpViewModel : PageViewModel
    {
        public HelpViewModel()
        {
            Close = new DefaultCommand(OnClose);
        }

        public ICommand Close { get; private set; }


        private void OnClose()
        {
            InternalClose();
        }
    }
}
