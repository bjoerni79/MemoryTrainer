using MemoryTrainer.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryTrainer
{
    /// <summary>
    /// Bootstrapper Code for the intial MVVM set up. See also App.xaml content for more.
    /// </summary>
    public class Bootstrap
    {
        private readonly MainWindowViewModel mainWindowViewModel;

        public Bootstrap()
        {
            mainWindowViewModel = new MainWindowViewModel();
        }

        public MainWindowViewModel Main
        {
            get
            {
                return mainWindowViewModel;
            }
        }


    }
}
