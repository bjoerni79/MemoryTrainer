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
            CurrentState = "Memory Trainer Version 1.2";

            ShowHelp = new DefaultCommand(OnShowHelp);
            OpenCardGame = new DefaultCommand(OnOpenCardGame);
            OpenResultOverview = new DefaultCommand(OnOpenResultOverview);
        }

        public ICommand ShowHelp { get; private set; }

        public ICommand OpenCardGame { get; private set; }

        public ICommand OpenResultOverview { get; private set; }

        public string CurrentState { get; private set; }

        private void OnOpenCardGame()
        {
            var viewModel = new CardGameViewModel();
            OpenPage(viewModel, PageSelection.CardGame);
        }

        private void OnShowHelp()
        {
            var viewModel = new HelpViewModel();
            OpenPage(viewModel, PageSelection.ShowHelp);
        }

        private void OnOpenResultOverview()
        {
            var viewModel = new ResultOverviewViewModel();
            OpenPage(viewModel, PageSelection.ResultOverview);
        }

        private void OpenPage(ViewModelBase viewModel, PageSelection pageSelection)
        {
            var helper = new ContainerFacade();
            var uiService = helper.Get<IUiService>();

            if (uiService != null)
            {
                var newId = name_prefix + nextId;

                // Step one: Creata a new view model
                helper.Add(viewModel, newId);

                // Step two : Create a new UI Element
                var page = uiService.CreatePage(pageSelection, newId);

                // Step three:  Add a link between them
                viewModel.Init(page);

                nextId++;
            }
        }
    }
}
