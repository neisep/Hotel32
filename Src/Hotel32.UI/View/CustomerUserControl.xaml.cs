using Hotel32.UI.Managers.Interfaces;
using Hotel32.UI.View.Interfaces;
using Hotel32.UI.ViewModel;
using System.Windows;
using System.Windows.Controls;
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
            userControl.SetValue(Grid.RowProperty, 2);

            _gridManager.AddUserControl(userControl);
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            _gridManager.ClearMainGridFromUserControls();
        }
    }
}
