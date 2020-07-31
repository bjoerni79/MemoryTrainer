using MemoryTrainer.MVVM;
using MemoryTrainer.Service;
using MemoryTrainer.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace MemoryTrainer.Pages
{
    /// <summary>
    /// Interaction logic for Help.xaml
    /// </summary>
    public partial class Help : UserControl,IPage
    {
        private string id;

        public Help(string id)
        {
            InitializeComponent();

            var containerHelper = new ContainerFacade();
            var vm = containerHelper.Get<HelpViewModel>(id);

            DataContext = vm;

            this.id = id;
        }

        public string GetId()
        {
            return id;
        }

        public void SetFocus()
        {
            //Nothing to do
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            

            //var la = XamlReader.Load()
        }
    }
}
