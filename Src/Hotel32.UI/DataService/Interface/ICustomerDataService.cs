using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel32.Domain.Models;

namespace Hotel32.UI.DataService
{
    public interface ICustomerDataService
    {
        Task<List<Customer>> GetAllAsync();
        Task<string> PostCustomerAsync(Customer customer);
    }
}