using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Newtonsoft.Json;
using System.Linq;
using Hotel32.Domain.Models;

namespace HotelAPI.Test
{
    //THIS UNIT TESTS ARE WRONG !!!
    //THEY NEED TO USE MOQ AND NOT THE ACTUALL OBJECT!
    public class GuestControllerTest
    {
        private User GetStandardUser()
        {
            return new User()
            {
                ID = Guid.Parse("e2952ce8-8c69-42d8-b53a-858eda1c8bea"),
                UserName = "NeiSep",
                Password = "password123",
                Token = "3IJRIU3908RY03HHYF978YF89T3FOSHYFIT63",
            };
        }

        [Fact]
        public void GetAllCustomers_ShouldReturnAllCustmers()
        {
            var user1 = GetStandardUser();
            var user2 = GetStandardUser();
            List<User> users = new List<User>();
            users.Add(user1);
            users.Add(user2);

            GuestController controller = new GuestController(users);
            var response = controller.GetAll();

            var customerJson = JsonConvert.DeserializeObject<List<User>>(response);

            Assert.NotEmpty(response);
            Assert.Equal(customerJson.First().ID, user1.ID);
            Assert.Equal(customerJson.First().UserName, user1.UserName);
            Assert.Equal(customerJson.First().Password, user1.Password);
            Assert.Equal(customerJson.First().Token, user1.Token);
        }

        [Fact]
        public void CreateCustomer()
        {
            GuestController controller = new GuestController();

            var customer = JsonConvert.SerializeObject(GetStandardUser());

            controller.Post(customer);
        }
    }
}
