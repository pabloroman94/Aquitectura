using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;

namespace Customer.Api.Models
{
    public class NetworkModel : BaseCrudEntityModel<Guid>
    {
        public Guid UserID { get; set; }  // Clave foránea que referencia a User(ID)
        public string Description { get; set; }  // Descripción del enlace (e.g., "Facebook", "Instagram")
        public string URL { get; set; }  // URL del perfil o enlace
        public Guid NetworkTypeID { get; set; }  // Clave foránea que referencia a NetworkType(ID)

        // Navigation properties
        //public User UserModel { get; set; }
        //public NetworkTypeModel NetworkType { get; set; }
    }
} 
