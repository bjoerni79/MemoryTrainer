using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryTrainer.Environment
{
    /// <summary>
    /// Represents a number in the game. 
    /// </summary>
    public class Number : INotifyPropertyChanged
    {
        /// <summary>
        /// Creates a new instance of a Number
        /// </summary>
        /// <param name="orginalValue">the value to recall</param>
        /// <exception cref="ArgumentNullException">thrown if string is null</exception>
        public Number(string orginalValue)
        {
            if (orginalValue == null)
            {
                throw new ArgumentNullException("originalValue");
            }

            Original = orginalValue;
            Response = String.Empty;
            Order = 0;
        }

        /// <summary>
        /// The generated number scheme
        /// </summary>
        public string Original { get; set; }

        /// <summary>
        /// The higher the value, the higher is this Number prioritized. Default is 0.
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// The response by the user
        /// </summary>
        public string Response { get; set; }

        /// <summary>
        /// Trigger the INotifyPropertyChanged event and update the listeners (i.e a WPF UI Element)
        /// </summary>
        public void Refresh()
        {
            // https://docs.microsoft.com/de-de/dotnet/api/system.componentmodel.inotifypropertychanged?view=net-5.0
            // PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Original"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Response"));
        }

        /// <summary>
        /// The event specified in the INotifyPropertyChanged interface
        /// </summary>
        /// <seealso cref="INotifyPropertyChanged.PropertyChanged"/>
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
