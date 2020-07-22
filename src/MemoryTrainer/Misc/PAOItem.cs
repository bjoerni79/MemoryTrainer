using MemoryTrainer.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MemoryTrainer.Misc
{
    public class PAOItem : INotifyPropertyChanged
    {
        public PlayingCard Person { get; set; }

        public PlayingCard Action { get; set; }

        public PlayingCard Object { get; set; }



        public bool? RecallOk { get; set; }

        public void Refresh()
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                var args = new PropertyChangedEventArgs("RecallOK");
                handler(this, args);
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
    }
}
