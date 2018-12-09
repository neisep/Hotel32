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
    public partial class CustomerEditUserControl : UserControl
    {
        public CustomerEditUserControl(ViewModel.CustomerViewModel customerViewModel)
        {
            InitializeComponent();
            //customerViewModel
        }
    }
}
