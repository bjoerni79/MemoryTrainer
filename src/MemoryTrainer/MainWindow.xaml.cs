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
using System.Windows.Controls.Ribbon;
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
    public partial class MainWindow : RibbonWindow
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
            var uiService = new UiService(this, tabControl);

            var container = FindResource("Container") as IContainer;
            container.AddService(typeof(IUiService), uiService);

        }

    }
}
