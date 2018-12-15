using Hotel32.UI.DataService;
using Hotel32.UI.Managers;
using Hotel32.UI.Managers.Interfaces;
using Hotel32.UI.View.Interfaces;
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
using Unity;

namespace Hotel32.UI.View
{
    public partial class CustomerUserControl : UserControl, ICustomerUserControl
    {
        private CustomerViewModel _viewModel;
        private IGridManager _gridManager;
        private IUnityContainer _container;

        public CustomerUserControl(CustomerViewModel viewModel, IGridManager gridManager, IUnityContainer container)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
            _gridManager = gridManager;
            _container = container;

            Loaded += CustomerUserControl_Loaded;
        }

        private void CustomerUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.LoadAsync();
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var userControl = _container.Resolve<CustomerEditUserControl>();
            userControl.SetValue(Grid.RowProperty, 1);

            _gridManager.AddUserControl(userControl);

            //_parentWindow.AddUserControl();
            //Window window = new Window
            //{
            //    MinHeight = 400,
            //    MaxHeight = 400,
            //    MinWidth = 400,
            //    MaxWidth = 800,
            //    Title = "Test",
            //    Content = new CustomerEditUserControl(new ViewModel.CustomerViewModel(new CustomerDataService())),
            //};
            //window.ShowDialog();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            _gridManager.ClearMainGridFromUserControls();
        }
    }
}
