using MemoryTrainer.Environment;
using MemoryTrainer.Misc;
using MemoryTrainer.MMVM;
using MemoryTrainer.MVVM;
using MemoryTrainer.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
        private bool isDebugModeEnabled = false;

        private string currentDeck;
        private string oldCurrentDeck;

        private string comment;
        private string oldComment;

        public ResultOverviewViewModel()
        {
            Close = new DefaultCommand(OnClose);
            Refresh = new DefaultCommand(OnRefresh);
            SaveFile = new DefaultCommand(OnSaveFile);
            LoadFile = new DefaultCommand(OnLoadFile);
            ApplyChanges = new DefaultCommand(OnApplyChanges, IsContentChanged);

            //SelectSource = new DefaultCommand(OnSelectedSource);

            OnRefresh();
        }

        public IRefreshCommand LoadFile { get; private set; }

        public IRefreshCommand SaveFile { get; private set; }

        public IRefreshCommand SelectSource { get; private set; }

        public IRefreshCommand Close { get; private set; }

        public IRefreshCommand Refresh { get; private set; }

        public IRefreshCommand ApplyChanges { get; private set; }

        public string Source { get; private set; }

        public string CurrentDeck
        {
            get
            {
                return currentDeck;
            }
            set
            {
                currentDeck = value;
                ApplyChanges.Refresh();
            }
        }

        public string CurrentComment
        {
            get
            {
                return comment;
            }
            set
            {
                comment = value;
                ApplyChanges.Refresh();
            }
        }

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

                    oldCurrentDeck = CurrentResultOverview.Deck;
                    oldComment = CurrentResultOverview.Comment;

                    SelectedCards = new ObservableCollection<PAOResultItem>(tempList);
                    CurrentDeck = CurrentResultOverview.Deck;
                    CurrentComment = CurrentResultOverview.Comment;
                    

                    RaisePropertyChange("SelectedCards");
                    RaisePropertyChange("CurrentDeck");
                    RaisePropertyChange("CurrentComment");
                }
            }
        }

        private bool IsContentChanged()
        {
            if (oldComment == null || oldCurrentDeck == null)
            {
                return false;
            }

            var isCommentDifferent = !(oldComment.Equals(comment));
            var isDeckDifferent =  !(oldCurrentDeck.Equals(currentDeck));

            return isCommentDifferent || isDeckDifferent;
        }

        private void OnApplyChanges()
        {
            var facade = new ContainerFacade();
            resultOverview = facade.Get<ResultOverview>(Bootstrap.Results);
            if (resultOverview != null)
            {
                // Get the ID of the current id and get the instance
                var id = CurrentResultOverview.Id;
                var item = resultOverview.PAOResults.Skip(id).First();

                item.Comment = CurrentComment;
                item.DeckTitle = CurrentDeck;
                OnRefresh();
            }
        }

        private void OnRefresh()
        {
            var facade = new ContainerFacade();
            resultOverview = facade.Get<ResultOverview>(Bootstrap.Results);
            if (resultOverview != null)
            {
                Source = resultOverview.Source;

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
                AddDebugValues(results);
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

                oldComment = null;
                oldCurrentDeck = null;
                ApplyChanges.Refresh();
            }
        }

        private void AddDebugValues(List<PAOResult> results)
        {
            if (isDebugModeEnabled)
            {
                // testResult1
                var testResult1 = new PAOResult
                {
                    Comment = "Test Result 1",
                    DeckTitle = "Test Deck 1"
                };
                testResult1.Items.Add(new PAOResultItem { Person = PlayingCard.Diamond_Jack, Action = PlayingCard.Diamond_Queen, Object = PlayingCard.Diamond_King, RecallState = 0 });
                testResult1.Items.Add(new PAOResultItem { Person = PlayingCard.Heart_Jack, Action = PlayingCard.Heart_Queen, Object = PlayingCard.Heart_King, RecallState = 1 });
                testResult1.Items.Add(new PAOResultItem { Person = PlayingCard.Spade_Jack, Action = PlayingCard.Spade_Queen, Object = PlayingCard.Spade_King, RecallState = 2 });


                // testResult2
                var testResult2 = new PAOResult();
                testResult2.Comment = "Test Result 2";
                testResult2.DeckTitle = "Test Deck 2";
                testResult2.Items.Add(new PAOResultItem { Person = PlayingCard.Diamond_2, Action = PlayingCard.Diamond_3, Object = PlayingCard.Diamond_4 });

                results.Add(testResult1);
                results.Add(testResult2);
            }
        }

        //private void OnSelectedSource()
        //{
        //    var facade = new ContainerFacade();
        //    var uiService = facade.Get<IUiService>();

        //    var result = uiService.ShowOpenFileDialog();
        //    if (result != null)
        //    {
        //        Source = result;
        //        RaisePropertyChange("Source");
        //    }
        //}

        private void OnLoadFile()
        {
            var facade = new ContainerFacade();
            var uiService = facade.Get<IUiService>();

            try
            {
                // Load the resutls and refresh the view
                var result = InternalLoadFile(Source);
                resultOverview = facade.Get<ResultOverview>(Bootstrap.Results);
                resultOverview.Reload(result);
                OnRefresh();
            }
            catch (IOServiceException serviceException)
            {
                uiService.ShowDialog(serviceException.Message, "Error");
            }
        }

        private void OnSaveFile()
        {
            var facade = new ContainerFacade();
            var uiService = facade.Get<IUiService>();

            try
            {
                InternalSaveFile(Source);
            }
            catch (IOServiceException serviceException)
            {
                uiService.ShowDialog(serviceException.Message, "Error");
            }   
        }

        private IEnumerable<PAOResult> InternalLoadFile(string filename)
        {
            var facade = new ContainerFacade();
            var ioService = facade.Get<IIOService>(Bootstrap.IoService);
            if (ioService != null)
            {
                var result = ioService.LoadResult(filename);
                return result;
            }

            return null;
        }

        private void InternalSaveFile(string filename)
        {
            var facade = new ContainerFacade();
            var ioService = facade.Get<IIOService>(Bootstrap.IoService);
            if (ioService != null)
            {
                var results = resultDict.Values;
                ioService.SaveResult(results, filename);
            }
        }
    }
}
