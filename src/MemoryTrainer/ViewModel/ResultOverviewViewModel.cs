using MemoryTrainer.Environment;
using MemoryTrainer.Misc;
using MemoryTrainer.MMVM;
using MemoryTrainer.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MemoryTrainer.ViewModel
{
    public class ResultOverviewViewModel : ViewModelBase
    {
        private ResultOverview resultOverview;

        public ResultOverviewViewModel()
        {
            Close = new DefaultCommand(OnClose);
            Refresh = new DefaultCommand(OnRefresh);

            OnRefresh();
        }

        public IRefreshCommand Close { get; private set; }

        public IRefreshCommand Refresh { get; private set; }

        public ObservableCollection<PAOResultOverview> Results { get; set; }

        private void OnClose()
        {
            InternalClose();
        }

        private void OnRefresh()
        {
            var facade = new ContainerFacade();
            resultOverview = facade.Get<ResultOverview>(Bootstrap.Results);
            if (resultOverview != null)
            {
                var list = new List<PAOResultOverview>();
                int id = 0;
                foreach (var paoResult in resultOverview.PAOResults)
                {
                    var paoResultOverview = new PAOResultOverview(id);
                    paoResultOverview.Comment = paoResult.Comment;
                    paoResultOverview.Deck = paoResult.DeckTitle;

                    list.Add(paoResultOverview);
                }

                // Refresh the UI
                Results = new ObservableCollection<PAOResultOverview>(list);
                RaisePropertyChange("Results");
            }
        }
    }
}
