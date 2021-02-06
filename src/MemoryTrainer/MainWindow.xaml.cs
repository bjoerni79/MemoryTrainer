using Generic.MVVM.IOC;
using MemoryTrainer.MVVM;
using MemoryTrainer.Pages;
using MemoryTrainer.Service;
using MemoryTrainer.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MemoryTrainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IUiService
    {


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Init..

            // Register the IUiService
            //
            // The IContainer resources is available via the application wide App.xaml
            //
            var container = FindResource("Container") as IContainer;
            container.AddService(typeof(IUiService), this);

        }

        public IPage ShowResultOverview(string id)
        {
            var headerName = "Result Overview";
            var page = new ResultPage(id);

            var viewFound = false;
            foreach (TabItem item in tabControl.Items)
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

        public IPage CreatePage(PageSelection element, string pageId)
        {
            UserControl page;
            string headerName;

            switch(element)
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

        private void CreateTab(UserControl page, string id, string headerName)
        {
            // Create a new page {element
            var tabItem = new TabItem() { Header = headerName };
            tabItem.Content = page;
            tabItem.Name = id;
            tabItem.HeaderTemplate = FindResource("tabItemTemplate") as DataTemplate;

            tabControl.Items.Add(tabItem);
            tabItem.Focus();
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
            var result = dialog.ShowDialog(this);
            if (result.HasValue && result.Value)
            {
                var filename = dialog.FileName;
                return filename;
            }

            return null;
        }

        public string ShowSaveFileDialog()
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "PAO Results|*.json|All Files|*.*";
            var result = dialog.ShowDialog(this);
            if (result.HasValue && result.Value)
            {
                var filename = dialog.FileName;
                return filename;
            }

            return null;
        }

        public void Close(string pageId)
        {
            TabItem currentItem = null;

            var items = tabControl.Items;
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
                tabControl.Items.Remove(currentItem);

                // Remove the associated view model
                var containerHelper = FacadeFactory.Create();
                containerHelper.Remove(pageId);
            }
        }


    }
}
