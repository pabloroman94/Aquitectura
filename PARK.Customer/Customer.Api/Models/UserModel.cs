using CustomerApp.Api.Models.SeedWork;
using System;

namespace Customer.Api.Models
{
    public class UserModel : BaseCrudEntityModel<Guid>
    {
        public string LoginName { get; set; }
        public string ProfileDescription { get; set; }
    }
} 
