using Hotel32.UI.DataService;
using Hotel32.UI.Managers;
using Hotel32.UI.Managers.Interfaces;
using Hotel32.UI.View;
using Hotel32.UI.View.Interfaces;
using Hotel32.UI.ViewModel;
using Hotel32.UI.ViewModel.Interfaces;
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

namespace Hotel32.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IUnityContainer _container;
        public MainWindow()
        {
            InitializeComponent();

            Start_DependencyInjection();
        }

        private void Start_DependencyInjection()
        {
            _container = new UnityContainer();
            _container.RegisterInstance(MainGrid);
            _container.RegisterInstance(_container);
            _container.RegisterType<IGridManager, GridManager>();
            _container.RegisterType<ICustomerDataService, CustomerDataService>();

            //ViewModels
            _container.RegisterType<ICustomerViewModel, CustomerViewModel>();

            //UserControlls
            _container.RegisterType<ICustomerUserControl, CustomerUserControl>();
            _container.RegisterType<ICustomerEditUserControl, CustomerEditUserControl>();
        }

        private void Customers_Click(object sender, RoutedEventArgs e)
        {
            //var window = new Window { Content = _container.Resolve<CustomerUserControl>()};
            //window.ShowDialog();

            var manager = _container.Resolve<GridManager>();

            var userControl = _container.Resolve<CustomerUserControl>();
            userControl.SetValue(Grid.RowProperty, 1);

            manager.AddUserControl(userControl);

            //Window window = new Window
            //{
            //    MinHeight = 400,
            //    MaxHeight = 400,
            //    MinWidth = 400,
            //    MaxWidth = 800,
            //    Title = "Test",
            //    Content = new CustomerUserControl(new ViewModel.CustomerViewModel(new CustomerDataService())),
            //};
            //window.ShowDialog();
        }
    }
}
