//
// Copyright (c) 2018 Jimmie Jönsson <jimmie@neisep.com>
// In dedication to my Grandpa Erling
//
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HotelSDK
{
    public class Api
    {
        private string _adress;
        public Api(string Adress)
        {
            _adress = Adress;
        }

        /// <summary>
        /// Get request from API.
        /// Returns Json string.
        /// </summary>
        /// <returns></returns>
        public string Get()
        {
            //TODO ADD LOGIC

            return "TEST";
        }

        /// <summary>
        /// Post to API
        /// Accept only Json string
        /// </summary>
        /// <param name="value"></param>
        public async Task Post(string jsonData)
        {
            ValidatePost(jsonData);

            using (var client = new HttpClient())
            {
                try
                {
                    //TODO HANDLE STATUS CODE!
                    var response = await client.PostAsync(_adress, new StringContent(JsonConvert.SerializeObject(jsonData)));

                    if (!response.IsSuccessStatusCode)
                        throw new Exception("Not accepted");
                }
                catch (Exception crap)
                {
                    //TODO ADD LOGGER!
                }
            }
        }

        /// <summary>
        /// Validation before posting data
        /// </summary>
        /// <returns></returns>
        private bool ValidatePost(string jsonData)
        {
            if (string.IsNullOrEmpty(_adress))
                throw new ArgumentNullException("missing adress");

            if (string.IsNullOrEmpty(jsonData))
                throw new ArgumentNullException("missing json data");

                return true;
        }
    }
}
