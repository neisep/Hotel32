using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Hotel32.Domain.Models;
using NHibernate;
using Hotel32.API;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelAPI
{
    [Route("api/[controller]")]
    public class GuestController : Controller
    {
        private List<User> _users;
        //public GuestController() { }
        //public GuestController(List<User> users)
        //{
        //    _users = users;
        //}
        // GET: api/<controller>
        [HttpGet]
        public string GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                //using (ITransaction transaction = session.BeginTransaction())
                //{
                //    var addedCustomer = new Customer
                //    {
                //        Id = Guid.NewGuid(),
                //        FirstName = "Jimmie",
                //        LastName = "Jönsson",
                //    };
                //    session.Save(addedCustomer);
                //    transaction.Commit();
                //}

                var customers = session.Query<Customer>().ToList();
                return JsonConvert.SerializeObject(customers);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {

        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
