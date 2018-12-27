using Hotel32.Domain.Models;
using Hotel32.UI.DataService;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Hotel32.UI.ViewModel.Interfaces;
using System;
using System.Net.Http;
using Hotel32.UI.Managers.Interfaces;

namespace Hotel32.UI.ViewModel
{
    public class CustomerViewModel : ViewModelBase, ICustomerViewModel
    {
        private ICustomerDataService _customerDataService;
        private IGridManager _gridManager;
        private Customer _selectedCustomer;

        public ObservableCollection<Customer> Customers { get; set; }

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged();
            }
        }

        public CustomerViewModel(ICustomerDataService customerDataService, IGridManager gridManager)
        {
            Customers = new ObservableCollection<Customer>();
            _customerDataService = customerDataService;
            _gridManager = gridManager;
        }

        public async Task SaveAsync(Customer customer)
        {
            try
            {
                await _customerDataService.PostCustomerAsync(customer);
            }
            catch (HttpRequestException ex)
            {
                if (ex.InnerException != null)
                    _gridManager.AddStatusMessage(ex.InnerException.Message);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task LoadAsync()
        {
            try
            {
                var response = await _customerDataService.GetAllAsync();

                if (response == null || response.Count == 0)
                    return;

                foreach (var customer in response)
                {
                    Customers.Add(customer);
                }
            }
            catch (Exception e)
            {

                throw;
            }
            //Customers.Clear();
            //foreach (var customer in response.Result)
            //{
            //    Customers.Add(customer);
            //}
        }
    }
}
