using Hotel32.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel32.UI.DataService
{
    public class CustomerDataService : ICustomerDataService
    {
        public async Task<List<Customer>> GetAllAsync()
        {
            var client = new RestClient();

            return await client.HttpGetAsync<Customer>("http://localhost:51229/api/guest/");
        }

        public async Task<string> PostCustomerAsync(Customer customer)
        {
            var client = new RestClient();

            return await client.HttpPostAsync("http://localhost:51229/api/guest/", customer);
        }
    }
}
