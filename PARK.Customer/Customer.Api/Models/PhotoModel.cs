using CustomerApp.Api.Models.SeedWork;
using System;

namespace Customer.Api.Models
{
    public class PhotoModel : BaseCrudEntityModel<Guid>
    {
        public Guid? CustomerId { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
