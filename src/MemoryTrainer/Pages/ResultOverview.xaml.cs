using MemoryTrainer.MVVM;
using MemoryTrainer.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MemoryTrainer.Pages
{
    /// <summary>
    /// Interaction logic for ResultPage.xaml
    /// </summary>
    public partial class ResultPage : UserControl, IPage
    {
        private string pageId;

        public ResultPage(string id)
        {
            InitializeComponent();

            pageId = id;
            var containerFacade = FacadeFactory.Create();
            var vm = containerFacade.Get<ResultOverviewViewModel>(id);

            DataContext = vm;
        }

        public string GetId()
        {
            return pageId;
        }

        public void SetFocus()
        {
        }
    }
}
