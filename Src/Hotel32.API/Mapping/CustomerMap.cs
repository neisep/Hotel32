using FluentNHibernate.Mapping;
using Hotel32.Domain.Models;

namespace Hotel32.API.Mapping
{
    public class CustomerMap : ClassMap<Customer>
    {
        public CustomerMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Table("Customer");
        }
    }
}
