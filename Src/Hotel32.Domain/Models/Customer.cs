using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel32.Domain.Models
{
    public class Customer
    {
        [JsonProperty("Id")]
        public virtual Guid Id { get; set; }
        [JsonProperty("FirstName")]
        public virtual string FirstName { get; set; }
        [JsonProperty("LastName")]
        public virtual string LastName { get; set; }
    }
}
