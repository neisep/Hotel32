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
        public async Task<string> GetAllAsync()
        {
            var client = new RestClient();
            return await client.HttpGetAsync("http://localhost:51229/api/guest/");
        }
    }
}
