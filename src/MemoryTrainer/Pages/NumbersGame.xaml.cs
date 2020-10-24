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
    /// Interaction logic for NumbersGame.xaml
    /// </summary>
    public partial class NumbersGame : UserControl, IPage
    {
        private string id;

        public NumbersGame(string id)
        {
            InitializeComponent();

            this.id = id;

            var containerFacade = new ContainerFacade();
            var vm = containerFacade.Get<NumberGameViewModel>(id);

            DataContext = vm;
        }

        public string GetId()
        {
            return id;
        }

        public void SetFocus()
        {
            close.Focus();
        }
    }
}
