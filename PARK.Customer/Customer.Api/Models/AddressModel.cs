using CustomerApp.Api.Models.SeedWork;
using System;
using System.Collections.Generic;

namespace Customer.Api.Models
{
    public class AddressModel : BaseCrudEntityModel<Guid>
    {
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
        public int? AddressTypeId { get; set; }
        public Guid? CustomerId { get; set; }
        public ContactTypeModel ContactTypes { get; set; }
    }
}
