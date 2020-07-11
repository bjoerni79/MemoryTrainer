using MemoryTrainer.MVVM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MemoryTrainer.MMVM
{
    public class ViewModelBase : INotifyPropertyChanged, IViewModel
    {
        protected void RaisePropertyChange(string eventName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                var args = new PropertyChangedEventArgs(eventName);
                handler(this, args);
            }
        }

        protected IPage page;

        public void Init(IPage page)
        {
            this.page = page;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
