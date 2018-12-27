using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Hotel32.Domain.Models;
using NHibernate;
using Hotel32.API;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelAPI
{
    [Route("api/[controller]")]
    public class GuestController : Controller
    {
        private List<User> _users;
        // GET: api/<controller>
        [HttpGet]
        public string GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var customers = session.Query<Customer>().ToList();
                return JsonConvert.SerializeObject(customers);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    var customer = session.Query<Customer>().Where(i => i.Id == id);
                    return Ok(customer);
                }
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Customer value)
        {
            //TODO Add validation
            try
            {
                using (var session = NHibernateHelper.OpenSession())
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(value);
                    transaction.Commit();
                }
                return Ok(value);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //Patch Api/<Controller>/5
        [HttpPatch]
        public IActionResult Patch([FromBody]Customer value)
        {
            //TODO UPDATE ENTITY HERE!
            return Ok(value);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            //TODO Delete entity here!
            //If we should allow delete of entity thought.
        }
    }
}
