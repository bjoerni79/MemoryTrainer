using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Generic.MVVM
{
    /// <summary>
    ///  Generic ViewModel implementation
    /// </summary>
    public abstract class GenericViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Creates a new GenericViewModel instance
        /// </summary>
        public GenericViewModel()
        {

        }

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
