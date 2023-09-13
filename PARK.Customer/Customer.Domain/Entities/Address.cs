using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Address : BaseCrudEntity<Guid>
    {
        public Customer Customer { get; set; }
        public Guid? ContactTypeId { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string Floor { get; set; }
        public string Dept { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Lng { get; set; }
        public string Lat { get; set; }
        public int AddressTypeId { get; set; }
        public Guid? CustomerId { get; set; }
        public ContactType ContactTypes { get; set; }
    }
}
