using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Hotel32.Domain.Models;

namespace Hotel32.UI.ViewModel.Interfaces
{
    public interface ICustomerViewModel
    {
        ObservableCollection<Customer> Customers { get; set; }
        Customer SelectedCustomer { get; set; }

        Task LoadAsync();
        Task SaveAsync(Customer customer);
    }
}