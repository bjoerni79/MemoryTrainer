using MemoryTrainer.MVVM;
using MemoryTrainer.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MemoryTrainer.MMVM
{
    /// <summary>
    /// Base class for all viewmodels.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Raises a property change on a binded property
        /// </summary>
        /// <param name="eventName">the property name</param>
        protected void RaisePropertyChange(string eventName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                var args = new PropertyChangedEventArgs(eventName);
                handler(this, args);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
