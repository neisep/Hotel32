//
// Copyright (c) 2018 Jimmie Jönsson <jimmie@neisep.com>
// In dedication to my Grandpa Erling
//
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelSDK.Test
{
    [TestClass]
    public class TestGuests
    {
        private Guests _guests => new Guests();
        [TestMethod]
        public async Task Add()
        {
            GuestInfo guestInfo = new GuestInfo
            {
                ID = Guid.Parse("f65e7e2f-bad3-414d-aacc-6e9f614c293b"),
                Name = "Erling",
            };

            //TODO Make sure if exception raised make the test fail.
            await _guests.Add(JsonConvert.SerializeObject(guestInfo));

            //Assert.AreEqual();
            //Assert.AreEqual(guests.);
           
        }
        [TestMethod]
        public void Modify()
        {
            GuestInfo guestInfo = new GuestInfo
            {
                ID = Guid.Parse("f65e7e2f-bad3-414d-aacc-6e9f614c293b"),
                Name = "Adam Bertil",
            };

            _guests.Modify(guestInfo);
        }
        [TestMethod]
        public void Delete()
        {
            GuestInfo guestInfo = new GuestInfo()
            {
                ID = Guid.Parse("f65e7e2f-bad3-414d-aacc-6e9f614c293b"),
            };
            _guests.Delete(guestInfo);
        }
    }
}
