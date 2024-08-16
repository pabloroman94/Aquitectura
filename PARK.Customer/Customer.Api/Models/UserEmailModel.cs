using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;

namespace Customer.Api.Models
{
    public class UserEmailModel : BaseCrudEntityModel<Guid>
    {
        // UserID property to associate email with a specific user
        public Guid UserID { get; set; }

        // Email property to store the email address
        public string Email { get; set; }

        // Preferred property to indicate if this is the preferred email for the user
        public bool Preferred { get; set; }

        // Navigation property to relate this email with a specific user
        //public virtual User User { get; set; }
    }
}
