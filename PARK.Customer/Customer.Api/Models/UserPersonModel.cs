using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Customer.Api.Models
{
    public class UserPersonModel : BaseCrudEntityModel<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }
        public int? ProfessionalTypeID { get; set; }  // Optional, consider removing if not in use

        // Navigation properties
        //public UserModel User { get; set; }
        //public IEnumerable<PersonProfessionModel> PersonProfessions { get; set; }
        //public IEnumerable<PersonTagModel> PersonTags { get; set; }
    }
} 
