using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseCrudEntity<Guid>
    {

        public string Username { get; set; }


        public string ProfileDescription { get; set; }


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
    /// <summary>
    /// Enum que define los tipos de usuario disponibles en el sistema.
    /// </summary>
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
