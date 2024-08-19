using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Customer.Api.Models
{
    public class UserPersonModel : UserModel//BaseCrudEntityModel<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }

        // Navigation properties
        //public UserModel User { get; set; }
        public ICollection<PersonProfessionModel> PersonProfessions { get; set; }  // Relación con las profesiones de la persona
        public ICollection<PersonTagModel> PersonTags { get; set; }  // Relación con las etiquetas de la persona
    }
} 
