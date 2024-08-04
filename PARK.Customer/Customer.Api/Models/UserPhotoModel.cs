using CustomerApp.Api.Models.SeedWork;
using System;

namespace Customer.Api.Models
{
    public class UserPhotoModel : BaseCrudEntityModel<Guid>
    {
        public Guid UserID { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        //public virtual User User { get; set; }
    }
}
