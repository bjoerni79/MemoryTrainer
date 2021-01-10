using Generic.MVVM;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryTrainer.ViewModel
{
    public class NumberGameViewModel : PageViewModel
    {

        public IRefreshCommand Close { get; private set; }

        public NumberGameViewModel()
        {
            Close = new DefaultCommand(OnClose);
        }


        public void OnClose()
        {
            InternalClose();
        }
    }
}
