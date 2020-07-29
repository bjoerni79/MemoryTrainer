using MemoryTrainer.MVVM;
using MemoryTrainer.Pages;
using MemoryTrainer.Service;
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

        /*
         * TODO:
         * 
         * Erzeuge einen Container und füge ihn in den Application Dict mit ein. -> IOC
         */

        public IPage CreatePage(PageSelection element, string pageId)
        {
            UserControl page;
            string headerName = "Unknown";

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
                default:
                    throw new Exception("Unknown page selection detected");
            }

            // Create a new page {element
            var tabItem = new TabItem() { Header = headerName };
            tabItem.Content = page;
            tabItem.Name = pageId;
            tabItem.HeaderTemplate = FindResource("tabItemTemplate") as DataTemplate;

            tabControl.Items.Add(tabItem);
            tabItem.Focus();

            return page as IPage;
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
                var containerHelper = new ContainerFacade();
                containerHelper.Remove(pageId);
            }
        }
    }
}
