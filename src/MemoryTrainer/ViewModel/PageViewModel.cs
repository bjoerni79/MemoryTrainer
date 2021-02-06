using Generic.MVVM;
using MemoryTrainer.MVVM;
using MemoryTrainer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryTrainer.ViewModel
{
    public abstract class PageViewModel : GenericViewModel, IViewModel
    {
        internal PageViewModel() : base()
        {
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

            var helper = FacadeFactory.Create();
            var uiService = helper.Get<IUiService>();

            if (uiService != null)
            {
                uiService.Close(id);
            }
        }
    }
}
