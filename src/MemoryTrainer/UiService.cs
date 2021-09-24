using MemoryTrainer.MVVM;
using MemoryTrainer.Pages;
using MemoryTrainer.Service;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MemoryTrainer
{
    public class UiService : IUiService
    {
        private readonly MainWindow mainWindow;
        private readonly TabControl tabControl;

        public UiService(MainWindow mainWindow, TabControl tabControl)
        {
            this.mainWindow = mainWindow;
            this.tabControl = tabControl; 
        }

        public MainWindow MainWindow => mainWindow;

        public TabControl TabControl => tabControl;

        public void Close(string pageId)
        {
            TabItem currentItem = null;

            var items = TabControl.Items;
            foreach (TabItem item in items)
            {
                if (item.Name.Equals(pageId))
                {
                    currentItem = item;
                    break;
                }
            }

            if (currentItem != null)
            {
                // Remove the TabItem
                TabControl.Items.Remove(currentItem);

                // Remove the associated view model
                var containerHelper = FacadeFactory.Create();
                containerHelper.Remove(pageId);
            }
        }

        public IPage CreatePage(PageSelection element, string pageId)
        {
            UserControl page;
            string headerName;

            switch (element)
            {
                case PageSelection.CardGame:
                    page = new CardGame(pageId);
                    headerName = "PAO Card Game";
                    break;
                case PageSelection.ShowHelp:
                    headerName = "Help";
                    page = new Help(pageId);
                    break;
                case PageSelection.NumberGame:
                    page = new NumbersGame(pageId);
                    headerName = "Number Game";
                    break;

                default:
                    throw new Exception("Unknown page selection detected");
            }

            CreateTab(page, pageId, headerName);

            return page as IPage;
        }

        public bool ShowDialog(string message, string caption)
        {
            MessageBox.Show(message, caption);
            return true;
        }

        public string ShowOpenFileDialog()
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "PAO Results|*.json|All Files|*.*";
            var result = dialog.ShowDialog(MainWindow);
            if (result.HasValue && result.Value)
            {
                var filename = dialog.FileName;
                return filename;
            }

            return null;
        }

        public IPage ShowResultOverview(string id)
        {
            var headerName = "Result Overview";
            var page = new ResultPage(id);

            var viewFound = false;
            foreach (TabItem item in TabControl.Items)
            {
                // let's do some old school coding ...
                if (item.Name.Equals(id))
                {
                    viewFound = true;
                    item.Focus();
                    break;
                }
            }

            if (!viewFound)
            {
                CreateTab(page, id, headerName);
            }

            return page;
        }

        public string ShowSaveFileDialog()
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "PAO Results|*.json|All Files|*.*";
            var result = dialog.ShowDialog(MainWindow);
            if (result.HasValue && result.Value)
            {
                var filename = dialog.FileName;
                return filename;
            }

            return null;
        }

        private void CreateTab(UserControl page, string id, string headerName)
        {
            // Create a new page {element
            var tabItem = new TabItem() { Header = headerName };
            tabItem.Content = page;
            tabItem.Name = id;
            tabItem.HeaderTemplate = MainWindow.FindResource("tabItemTemplate") as DataTemplate;

            TabControl.Items.Add(tabItem);
            tabItem.Focus();
        }
    }
}
