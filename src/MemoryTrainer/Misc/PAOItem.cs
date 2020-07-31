using MemoryTrainer.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MemoryTrainer.Misc
{
    /// <summary>
    /// Represents the result of a PAO set. 
    /// </summary>
    /// 
    [Serializable]
    public class PAOItem : INotifyPropertyChanged
    {
        /// <summary>
        /// The Person
        /// </summary>
        public PlayingCard Person { get; set; }

        /// <summary>
        /// The Action
        /// </summary>
        public PlayingCard Action { get; set; }
        /// <summary>
        /// The Object
        /// </summary>
        public PlayingCard Object { get; set; }

        /// <summary>
        /// Property for the user feedback. If the user could recall it the return value is true.
        /// </summary>
        public bool? RecallOk { get; set; }
        /// <summary>
        /// Refreshs the RecallOK bindings
        /// </summary>
        public void Refresh()
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                var args = new PropertyChangedEventArgs("RecallOK");
                handler(this, args);
            }
        }

        // The event notifier for the bindings
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
