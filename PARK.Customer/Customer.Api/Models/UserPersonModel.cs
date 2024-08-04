using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Customer.Api.Models
{
    public class UserPersonModel : BaseCrudEntityModel<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public Guid ProfessionalTypeID { get; set; }
    }
} 
