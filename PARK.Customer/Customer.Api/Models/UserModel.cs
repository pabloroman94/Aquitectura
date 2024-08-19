using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Customer.Api.Models
{
    /// <summary>
    /// Representa un usuario en el sistema, que puede ser una persona o una empresa.
    /// Esta clase hereda de BaseCrudEntityModel con Guid como tipo de clave primaria.
    /// </summary>
    public class UserModel : BaseCrudEntityModel<Guid>
    {

        public string Username { get; set; }


        public string ProfileDescription { get; set; }


        public UserType Type { get; set; }  // Nuevo campo para identificar si es Persona o Empresa


        // Propiedades de navegación
        //public UserPersonModel Person { get; set; }

        //public UserCompanyModel Company { get; set; }
        public ICollection<Network> Networks { get; set; }
        // Redes sociales/enlaces del usuario

        //public CredentialModel Credential { get; set; }  // La credencial asociada al usuario

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
