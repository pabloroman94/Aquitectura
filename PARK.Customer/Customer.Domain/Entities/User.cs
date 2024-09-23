using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseCrudEntity<Guid>
    {

        public string Username { get; set; }
        public string ProfileImage { get; set; }


        public string ProfileTitle { get; set; }

        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }


        //public UserType Type { get; set; }  // Nuevo campo para identificar si es Persona o Empresa

        // Propiedades de navegación

        /// <summary>
        /// Información adicional cuando el usuario es una persona. Relaciona al usuario con la entidad 'UserPersonModel'.
        /// </summary>
        //public UserPersonModel Person { get; set; }

        /// <summary>
        /// Información adicional cuando el usuario es una empresa. Relaciona al usuario con la entidad 'UserCompanyModel'.
        /// </summary>
        //public UserCompanyModel Company { get; set; }

        /// <summary>
        /// Colección de redes sociales o enlaces asociados al usuario. 
        /// Por ejemplo, Facebook, Instagram, página web, etc.
        /// </summary>
        public ICollection<Network> Networks { get; set; }
        public ICollection<UserAddress> UserAddresses { get; set; }
        [NotMapped]
        public AddressProfile? AddressProfile { get; set; }
        [NotMapped]
        public ICollection<NetworkProfile> NetworkProfiles { get; set; }


        /// <summary>
        /// Información de autenticación del usuario, como nombre de usuario y contraseña.
        /// Relaciona al usuario con la entidad 'CredentialModel'.
        /// </summary>
        //public CredentialModel Credential { get; set; }  // La credencial asociada al usuario

        /// <summary>
        /// Colección de otros usuarios que este usuario ha marcado como favoritos.
        /// Relaciona al usuario con la entidad 'UserFavoriteModel'.
        /// </summary>
        //public IEnumerable<UserFavoriteModel> Favorites { get; set; }  // Lista de usuarios favoritos
    }
    public class AddressProfile
    {
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string Floor { get; set; }

        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string URLMaps { get; set; }
    }
    public class NetworkProfile
    {
        public string Title { get; set; } // Nombre de la red social (Instagram, Facebook, Twitter)
        public string UrlIcon { get; set; } // URL del icono de la red social
        public string ButtonColor { get; set; } // Color del botón
        public string PhoneNumber { get; set; } // Color del botón
        public string UrlNetwork { get; set; } // URL de la red social
    }

    public enum UserType
    {
        /// <summary>
        /// El usuario es una persona física.
        /// </summary>
        Person,

        /// <summary>
        /// El usuario es una empresa u organización.
        /// </summary>
        Company
    }
}
