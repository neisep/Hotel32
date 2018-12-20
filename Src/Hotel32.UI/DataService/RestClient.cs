using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hotel32.UI.DataService
{
    public class RestClient : IDisposable
    {
        //We want to reause this since we might use this ALOT, and reinstancate would just make big mess.
        private static HttpClient _httpClient = new HttpClient(new HttpClientHandler { Proxy = null, UseProxy = false });

        //POST
        //PUT
        //DELETE
        //GET
        public async Task<string> HttpGetAsync(string url)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
                var response = await _httpClient.GetStringAsync(url);
                return response;
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
