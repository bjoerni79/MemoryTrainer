﻿using MemoryTrainer.MVVM;
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
    /// Interaction logic for CardGame.xaml
    /// </summary>
    public partial class CardGame : UserControl, IPage
    {
        private string id;

        public CardGame(string id)
        {
            InitializeComponent();

            this.id = id;

            var containerFacade = FacadeFactory.Create();
            var vm = containerFacade.Get<CardGameViewModel>(id);

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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            close.Focus();
        }
    }
}
