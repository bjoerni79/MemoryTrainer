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
    public class ViewModelBase : INotifyPropertyChanged, IViewModel
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

        /// <summary>
        /// The page assigned to this view model
        /// </summary>
        protected IPage page;


        public void Init(IPage page)
        {
            this.page = page;
        }

        /// <summary>
        /// Closes the view model and the view.
        /// </summary>
        protected void InternalClose()
        {
            var id = page.GetId();

            var helper = new ContainerFacade();
            var uiService = helper.Get<IUiService>();

            if (uiService != null)
            {
                uiService.Close(id);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
