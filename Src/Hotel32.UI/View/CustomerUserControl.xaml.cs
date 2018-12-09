﻿using Hotel32.UI.DataService;
using Hotel32.UI.ViewModel;
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

namespace Hotel32.UI.View
{
    public partial class CustomerUserControl : UserControl
    {
        private CustomerViewModel _viewModel;

        public CustomerUserControl(CustomerViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;

            Loaded += CustomerUserControl_Loaded;
        }

        private void CustomerUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.LoadAsync();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                MinHeight = 400,
                MaxHeight = 400,
                MinWidth = 400,
                MaxWidth = 800,
                Title = "Test",
                Content = new CustomerEditUserControl(new ViewModel.CustomerViewModel(new CustomerDataService())),
            };
            window.ShowDialog();
        }
    }
}
