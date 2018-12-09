using Hotel32.UI.DataService;
using Hotel32.UI.View;
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

namespace Hotel32.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Customers_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                MinHeight = 400,
                MaxHeight = 400,
                MinWidth = 400,
                MaxWidth = 400,
                Title = "Test",
                Content = new CustomerUserControl(new ViewModel.CustomerViewModel(new CustomerDataService())),
            };
            window.ShowDialog();
        }
    }
}
