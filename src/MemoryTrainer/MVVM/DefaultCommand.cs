using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace MemoryTrainer.MVVM
{
    /// <summary>
    /// Implements a WPF ready button representation based on ICommand
    /// </summary>
    public class DefaultCommand : IRefreshCommand
    {
        private Action executer;
        private Func<bool> isExecutable;

        /// <summary>
        /// Creates a new DefaultCommand
        /// </summary>
        /// <param name="action">the action delegate</param>
        public DefaultCommand(Action action)
        {
            executer += action;
        }

        /// <summary>
        /// Creates a new DefaultCommand
        /// </summary>
        /// <param name="action">the action delegate</param>
        /// <param name="canBeExecuted">the enabled/disabled logic delegate</param>
        public DefaultCommand(Action action, Func<bool> canBeExecuted)
        {
            executer += action;
            isExecutable += canBeExecuted;
        }

        /// <summary>
        /// Implements the ICommand interface
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Implements the ICommand interface
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            if (isExecutable != null)
            {
                return isExecutable();
            }

            return true;
        }

        /// <summary>
        /// Implements the ICommand interface
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            executer();
        }

        /// <summary>
        /// Raises the CanExecuteChanged event
        /// </summary>
        public void Refresh()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                var args = new EventArgs();
                handler(this, args);
            }
        }
    }
}
