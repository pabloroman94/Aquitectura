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
        /// <summary>
        /// Nombre de usuario único utilizado para la autenticación.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Descripción del perfil del usuario, que podría incluir detalles personales o información sobre la empresa.
        /// </summary>
        public string ProfileDescription { get; set; }

        /// <summary>
        /// Enum que indica si el usuario es una persona o una empresa.
        /// </summary>
        public UserType Type { get; set; }  // Nuevo campo para identificar si es Persona o Empresa

        // Propiedades de navegación

        /// <summary>
        /// Información adicional cuando el usuario es una persona. Relaciona al usuario con la entidad 'UserPersonModel'.
        /// </summary>
        public UserPersonModel Person { get; set; }

        /// <summary>
        /// Información adicional cuando el usuario es una empresa. Relaciona al usuario con la entidad 'UserCompanyModel'.
        /// </summary>
        public UserCompanyModel Company { get; set; }

        /// <summary>
        /// Colección de redes sociales o enlaces asociados al usuario. 
        /// Por ejemplo, Facebook, Instagram, página web, etc.
        /// </summary>
        public IEnumerable<NetworkModel> Networks { get; set; }  // Redes sociales/enlaces del usuario

        /// <summary>
        /// Información de autenticación del usuario, como nombre de usuario y contraseña.
        /// Relaciona al usuario con la entidad 'CredentialModel'.
        /// </summary>
        public CredentialModel Credential { get; set; }  // La credencial asociada al usuario

        /// <summary>
        /// Colección de otros usuarios que este usuario ha marcado como favoritos.
        /// Relaciona al usuario con la entidad 'UserFavoriteModel'.
        /// </summary>
        public IEnumerable<UserFavoriteModel> Favorites { get; set; }  // Lista de usuarios favoritos
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
