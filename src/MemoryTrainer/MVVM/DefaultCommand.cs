using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace MemoryTrainer.MVVM
{
    public class DefaultCommand : ICommand
    {
        private Action executer;

        public DefaultCommand(Action action)
        {
            executer += action;
            // Func<...> for CanExecute
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            executer();
        }
    }
}
