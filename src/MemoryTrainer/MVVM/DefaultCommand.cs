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
        private Func<bool> isExecutable;

        public DefaultCommand(Action action)
        {
            executer += action;
        }

        public DefaultCommand(Action action, Func<bool> canBeExecuted)
        {
            executer += action;
            isExecutable += canBeExecuted;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (isExecutable != null)
            {
                return isExecutable();
            }

            return true;
        }

        public void Execute(object parameter)
        {
            executer();
        }
    }
}
