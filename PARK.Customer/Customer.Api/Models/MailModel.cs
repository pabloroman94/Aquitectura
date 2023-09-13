using CustomerApp.Api.Models.SeedWork;
using System;

namespace Customer.Api.Models
{
    public class MailModel : BaseCrudEntityModel<Guid>
    {
        public Guid? CustomerId { get; set; }
        public Guid? ContactTypeId { get; set; }
        public string Email { get; set; }
        public int? Preferred { get; set; }
        public ContactTypeModel ContactTypes { get; set; }

    }
}
