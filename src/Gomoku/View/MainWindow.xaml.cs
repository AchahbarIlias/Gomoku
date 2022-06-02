using Cells;
using Model.Gomoku;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using ViewModel;
using ViewModel.VM;

namespace View
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainViewModel();
            

        }

    }

   
}


