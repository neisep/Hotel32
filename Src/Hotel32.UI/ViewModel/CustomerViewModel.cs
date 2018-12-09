using Hotel32.Domain.Models;
using Hotel32.UI.DataService;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Hotel32.UI.ViewModel
{
    public class CustomerViewModel : ViewModelBase
    {
        private ICustomerDataService _customerDataService;
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

        public CustomerViewModel(ICustomerDataService customerDataService)
        {
            Customers = new ObservableCollection<Customer>();
            _customerDataService = customerDataService;
        }

        public async Task LoadAsync()
        {
            try
            {
                var response = await _customerDataService.GetAllAsync();

                if (response == null)
                    return;

                var test = JsonConvert.DeserializeObject<List<Customer>>(response);

                foreach (var customer in test)
                {
                    Customers.Add(customer);
                }
            }
            catch (System.Exception e)
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
