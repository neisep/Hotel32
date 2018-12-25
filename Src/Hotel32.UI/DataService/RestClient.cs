using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hotel32.UI.DataService
{
    //TODO Need to replace string url to something like this $"{_apiBaseUri}/{route}", then we got support for running multiple apps instead of just one instance.
    //Probobly need some kind of Authentication Token to API maybe today there is no Auth at all that is bad.
    public class RestClient : IDisposable
    {
        //We want to reause this since we might use this ALOT, and reinstancate would just make big mess.
        private static HttpClient _httpClient = new HttpClient(new HttpClientHandler { Proxy = null, UseProxy = false });

        //POST
        //PUT
        //DELETE
        //GET

        //TODO Need too add somekind of Model of the information we trying to reach here!
        public async Task<List<T>> HttpGetAsync<T>(string url)
        {
            try
            {
                //UserAgent is probobly not needed.
                _httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
                using (var request = new HttpRequestMessage(HttpMethod.Get, url))
                using (var response = await _httpClient.SendAsync(request)) //TODO ADD CANCELATION!
                {
                    var stream = await response.Content.ReadAsStreamAsync();

                    if (!response.IsSuccessStatusCode)
                    {
                        var content = await StreamToStringAsync(stream);
                        throw new ApiException
                        {
                            StatusCode = (int)response.StatusCode,
                            Content = content,
                        };
                    }

                    return DeserializeJsonFromStream<List<T>>(stream);
                }
            }
            catch (Exception ex)
            {
                //TODO ADD SOME EXCEPTION HERE MAYBE!
            }
            return null;
        }

        public async Task<string> HttpPostAsync<T>(string url, T content)
        {
            try
            {
                if (content == null)
                    return null;

                using (var request = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    request.Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");
                    using (var response = await _httpClient.SendAsync(request)) //TODO ADD CANCELATION!
                    {
                        var responseString = await response.Content.ReadAsStringAsync();

                        if (!response.IsSuccessStatusCode)
                        {
                            throw new ApiException
                            {
                                StatusCode = (int)response.StatusCode,
                                Content = responseString,
                            };
                        }

                        return responseString;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
        private async Task<string> StreamToStringAsync(Stream stream)
        {
            string content = null;

            if (stream != null)
                using (var sr = new StreamReader(stream))
                    content = await sr.ReadToEndAsync();

            return content;
        }

        private T DeserializeJsonFromStream<T>(Stream stream)
        {
            if (stream == null || stream.CanRead == false)
                return default(T);

            using (var sr = new StreamReader(stream))
            using (var jtr = new JsonTextReader(sr))
            {
                var js = new JsonSerializer();
                var searchResult = js.Deserialize<T>(jtr);
                return searchResult;
            }
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
