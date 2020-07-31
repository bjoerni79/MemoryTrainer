using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MemoryTrainer.MVVM
{
    public interface IRefreshCommand : ICommand
    {
        void Refresh();
    }
}
