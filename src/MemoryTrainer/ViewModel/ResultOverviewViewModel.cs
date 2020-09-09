using MemoryTrainer.Environment;
using MemoryTrainer.Misc;
using MemoryTrainer.MMVM;
using MemoryTrainer.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Documents;

namespace MemoryTrainer.ViewModel
{
    public class ResultOverviewViewModel : ViewModelBase
    {
        private ResultOverview resultOverview;
        private PAOResultOverview currentResultOverview;
        private Dictionary<int, PAOResult> resultDict;

        private bool isDebugModeEnabled = true;

        public ResultOverviewViewModel()
        {
            Close = new DefaultCommand(OnClose);
            Refresh = new DefaultCommand(OnRefresh);

            OnRefresh();
        }

        public IRefreshCommand LoadFile { get; private set; }

        public IRefreshCommand SaveFile { get; private set; }

        public IRefreshCommand Close { get; private set; }

        public IRefreshCommand Refresh { get; private set; }

        public PAOResultOverview CurrentResultOverview
        {
            get
            {
                return currentResultOverview;
            }
            set
            {
                currentResultOverview = value;
                RenderCards();
            }
        }

        public ObservableCollection<PAOResultOverview> Results { get; set; }

        public ObservableCollection<PAOResultItem>  SelectedCards {get;set;}

        private void OnClose()
        {
            InternalClose();
        }

        private void InternalLoadFile(string filename)
        {

        }

        private void InternalSaveFile(string filename)
        {

        }

        private void RenderCards()
        {
            if (CurrentResultOverview != null)
            {
                var id = CurrentResultOverview.Id;
                var containsKey = resultDict.ContainsKey(id);
                if (containsKey)
                {
                    var result = resultDict[id];
                    var cards = result.Items;
                    var tempList = new List<PAOResultItem>();

                    foreach (var curItem in cards)
                    {
                        var paoResultItem = new PAOResultItem()
                        {
                            Person = curItem.Person,
                            Action = curItem.Action,
                            Object = curItem.Object,
                            RecallState = curItem.RecallState
                        };

                        tempList.Add(paoResultItem);
                    }

                    SelectedCards = new ObservableCollection<PAOResultItem>(tempList);
                    RaisePropertyChange("SelectedCards");
                }
            }
        }

        private void OnRefresh()
        {
            var facade = new ContainerFacade();
            resultOverview = facade.Get<ResultOverview>(Bootstrap.Results);
            if (resultOverview != null)
            {
                // Create a list and and an ID integer to play with later.
                var list = new List<PAOResultOverview>();
                int id = 0;

                // Use a temporary list instead of the enumeration of the instance, because we need to add tests items maybe.
                resultDict = new Dictionary<int, PAOResult>();
                var results = new List<PAOResult>();
                results.AddRange(resultOverview.PAOResults);

                //
                //  Create some fake results for debugging if enabled
                //
                if (isDebugModeEnabled)
                {
                    // testResult1
                    var testResult1 = new PAOResult
                    {
                        Comment = "Test Result 1",
                        DeckTitle = "Test Deck 1"
                    };
                    testResult1.Add(new PAOResultItem { Person = PlayingCard.Diamond_Jack, Action = PlayingCard.Diamond_Queen, Object = PlayingCard.Diamond_King, RecallState = 0 });
                    testResult1.Add(new PAOResultItem { Person = PlayingCard.Heart_Jack, Action = PlayingCard.Heart_Queen, Object = PlayingCard.Heart_King, RecallState = 1 });
                    testResult1.Add(new PAOResultItem { Person = PlayingCard.Spade_Jack, Action = PlayingCard.Spade_Queen, Object = PlayingCard.Spade_King, RecallState = 2 });


                    // testResult2
                    var testResult2 = new PAOResult();
                    testResult2.Comment = "Test Result 2";
                    testResult2.DeckTitle = "Test Deck 2";
                    testResult2.Add(new PAOResultItem { Person = PlayingCard.Diamond_2, Action = PlayingCard.Diamond_3, Object = PlayingCard.Diamond_4 });

                    results.Add(testResult1);
                    results.Add(testResult2);
                }

                foreach (var paoResult in results)
                {
                    var paoResultOverview = new PAOResultOverview(id);
                    paoResultOverview.Comment = paoResult.Comment;
                    paoResultOverview.Deck = paoResult.DeckTitle;

                    list.Add(paoResultOverview);
                    resultDict.Add(id, paoResult);
                    id++;
                }

                // Refresh the UI
                Results = new ObservableCollection<PAOResultOverview>(list);
                RaisePropertyChange("Results");
            }
        }
    }
}
