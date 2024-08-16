using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;

namespace Customer.Api.Models
{
    public class UserFavoriteModel : BaseCrudEntityModel<Guid>
    {
        public Guid UserID { get; set; }  // Clave foránea que referencia al usuario que tiene la lista de favoritos
        public Guid FavoriteUserID { get; set; }  // Clave foránea que referencia al usuario favorito

        // Navigation properties
        //public User User { get; set; }
        //public User FavoriteUser { get; set; }
    }
} 
