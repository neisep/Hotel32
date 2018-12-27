using Hotel32.UI.Managers.Interfaces;
using Hotel32.UI.View.Interfaces;
using Hotel32.UI.ViewModel.Interfaces;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Hotel32.UI.View
{
    /// <summary>
    /// Interaction logic for CustomerEditUserControl.xaml
    /// </summary>
    public partial class CustomerEditUserControl : UserControl, ICustomerEditUserControl
    {
        private IGridManager _gridManager;
        private ICustomerViewModel _customerViewModel;

        public CustomerEditUserControl(ViewModel.CustomerViewModel customerViewModel, IGridManager gridManager)
        {
            InitializeComponent();
            //customerViewModel
            _gridManager = gridManager;
            _customerViewModel = customerViewModel;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            _gridManager.ClearMainGridFromUserControls();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Domain.Models.Customer model = NewMethod();
                _customerViewModel.SaveAsync(model);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private Domain.Models.Customer NewMethod()
        {
            return new Domain.Models.Customer
            {
                Id = Guid.NewGuid(),
                FirstName = FirstName.Text,
                LastName = LastName.Text
            };
        }
    }
}
