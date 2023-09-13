using CustomerApp.Api.Models.SeedWork;
using System;

namespace Customer.Api.Models
{
    public class GenderModel : BaseCrudEntityModel<Guid>
    {
        public string Description { get; set; }
    }
}
