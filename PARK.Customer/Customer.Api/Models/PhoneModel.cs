using CustomerApp.Api.Models.SeedWork;
using System;

namespace Customer.Api.Models
{
    public class PhoneModel : BaseCrudEntityModel<Guid>
    {
        public Guid? CustomerId { get; set; }
        public Guid? ContactTypeId { get; set; }
        public string PhoneNumber { get; set; }
        public ContactTypeModel ContactTypes { get; set; }
    }
}