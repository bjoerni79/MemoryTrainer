using MemoryTrainer.MMVM;
using MemoryTrainer.MVVM;
using MemoryTrainer.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace MemoryTrainer.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private const string name_prefix = "page_";
        private const string name_resultOverview = "resultOverview";
        private int nextId = 1;

        public MainWindowViewModel()
        {
            CurrentState = "Memory Trainer Version 1.4";

            ShowHelp = new DefaultCommand(OnShowHelp);
            OpenCardGame = new DefaultCommand(OnOpenCardGame);
            OpenResultOverview = new DefaultCommand(OnOpenResultOverview);
            OpenNumberGame = new DefaultCommand(OnOpenNumberGame);
        }

        public ICommand ShowHelp { get; private set; }

        public ICommand OpenCardGame { get; private set; }

        public ICommand OpenResultOverview { get; private set; }

        public ICommand OpenNumberGame { get; private set; }

        public string CurrentState { get; private set; }

        private void OnOpenCardGame()
        {
            var viewModel = new CardGameViewModel();
            OpenPage(viewModel, PageSelection.CardGame);
        }

        private void OnOpenNumberGame()
        {
            var viewModel = new NumberGameViewModel();
            OpenPage(viewModel, PageSelection.NumberGame);
        }

        private void OnShowHelp()
        {
            var viewModel = new HelpViewModel();
            OpenPage(viewModel, PageSelection.ShowHelp);
        }

        private void OnOpenResultOverview()
        {
            var helper = new ContainerFacade();
            var uiService = helper.Get<IUiService>();

            if (uiService != null)
            {
                // Create or resuse the view model and view
                if (!helper.Exists(name_resultOverview))
                {
                    var viewModel = new ResultOverviewViewModel();
                    helper.Add(viewModel, name_resultOverview);
                    var page = uiService.ShowResultOverview(name_resultOverview);
                    viewModel.Init(page);
                }
                else
                {
                    uiService.ShowResultOverview(name_resultOverview);
                }

            }
        }

        private void OpenPage(PageViewModel viewModel, PageSelection pageSelection)
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
