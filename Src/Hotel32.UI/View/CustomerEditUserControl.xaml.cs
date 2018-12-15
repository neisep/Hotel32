using Hotel32.UI.Managers.Interfaces;
using Hotel32.UI.View.Interfaces;
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
    /// <summary>
    /// Interaction logic for CustomerEditUserControl.xaml
    /// </summary>
    public partial class CustomerEditUserControl : UserControl, ICustomerEditUserControl
    {
        private IGridManager _gridManager;

        public CustomerEditUserControl(ViewModel.CustomerViewModel customerViewModel, IGridManager gridManager)
        {
            InitializeComponent();
            //customerViewModel
            _gridManager = gridManager;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            _gridManager.ClearMainGridFromUserControls();
        }
    }
}
