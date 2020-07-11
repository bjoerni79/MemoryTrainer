﻿using MemoryTrainer.MMVM;
using MemoryTrainer.MVVM;
using MemoryTrainer.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MemoryTrainer.ViewModel
{
    public class HelpViewModel : ViewModelBase
    {
        public HelpViewModel()
        {
            Close = new DefaultCommand(OnClose);
        }

        public ICommand Close { get; private set; }


        private void OnClose()
        {
            var id = page.GetId();

            var helper = new ContainerFacade();
            var uiService = helper.Get<IUiService>();

            if (uiService != null)
            {
                uiService.Close(id);
            }
        }
    }
}
