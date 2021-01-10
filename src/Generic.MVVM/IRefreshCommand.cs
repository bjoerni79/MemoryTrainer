using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Generic.MVVM
{
    /// <summary>
    /// Defines a RefreshCommand based on the WPF ICommand. 
    /// </summary>
    public interface IRefreshCommand : ICommand
    {
        /// <summary>
        /// Refreshs the binding
        /// </summary>
        void Refresh();
    }
}
