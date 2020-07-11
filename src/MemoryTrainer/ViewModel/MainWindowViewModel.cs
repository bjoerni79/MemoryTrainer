using MemoryTrainer.MMVM;
using MemoryTrainer.MVVM;
using MemoryTrainer.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MemoryTrainer.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private const string name_prefix = "page_";
        private int nextId = 1;

        public MainWindowViewModel()
        {
            CurrentState = "Hello MVVM";

            ShowHelp = new DefaultCommand(OnShowHelp);
        }

        public ICommand ShowHelp { get; private set; }

        public string CurrentState { get; private set; }

        private void OnShowHelp()
        {
            var helper = new ContainerFacade();
            var uiService = helper.Get<IUiService>();

            if (uiService != null)
            {
                var newId = name_prefix + nextId;

                // Step one: Creata a new view model
                var viewModel = new HelpViewModel();
                helper.Add(viewModel, newId);

                // Step two : Create a new UI Element
                var page = uiService.CreatePage(PageSelection.ShowHelp, newId);

                // Step three:  Add a link between them
                viewModel.Init(page);

                nextId++;
            }
        }
    }
}
