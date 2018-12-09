//
// Copyright (c) 2018 Jimmie Jönsson <jimmie@neisep.com>
// In dedication to my Grandpa Erling
//
using System;
using System.Threading.Tasks;

namespace HotelSDK
{
    /// <summary>
    /// Add, Modify, Delete Guests from Database
    /// </summary>
    public class Guests
    {
        public Api GetApi => new Api("http://localhost:51229/api/guest/");
        /// <summary>
        /// Adds guest information
        /// </summary>
        /// <param name="guestInfo"></param>
        public async Task Add(string guestInfo)
        {
            var api = GetApi;
            await api.Post(guestInfo);
        }
        /// <summary>
        /// Modify a guest information
        /// </summary>
        /// <param name="guestInfo"></param>
        public void Modify(GuestInfo guestInfo)
        {
            var api = GetApi;
        }
        /// <summary>
        /// Deletes a guest
        /// </summary>
        /// <param name="guestInfo"></param>
        public void Delete(GuestInfo guestInfo)
        {
            var api = GetApi;
        }
    }

    //TODO MOVE THIS MODEL
    public class GuestInfo
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
    }
        
}
