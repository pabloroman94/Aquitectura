using CustomerApp.Api.Models.SeedWork;
using System;

namespace Customer.Api.Models
{
    public class ContactTypeModel : BaseCrudEntityModel<Guid>
    {
        public string Description { get; set; }

    }
}
