using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Customer.Api.Models.Request
{
    public class UserPersonResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string ProfileImage { get; set; }
        public string Gender { get; set; }
        //public string Username { get; set; }
        public string ShortDescription { get; set; }
        public string ProfileTitle { get; set; }
        public string LongDescription { get; set; }
        public List<string> Tags { get; set; }
        public List<string> Professions { get; set; }


        //public ICollection<PersonProfessionResponse> PersonProfessions { get; set; }
        //public ICollection<PersonTagResponse> PersonTags { get; set; }
        //public ICollection<NetworkResponse> Networks { get; set; }
        //public ICollection<UserAddressResponse> UserAddresses { get; set; }
        public AddressProfileResponse? AddressProfile { get; set; }
        public ICollection<NetworkProfileResponse> NetworkProfiles { get; set; }

    }
    public class NetworkProfileResponse
    {
        public string Title { get; set; } // Nombre de la red social (Instagram, Facebook, Twitter)
        public string UrlIcon { get; set; } // URL del icono de la red social
        public string ButtonColor { get; set; } // Color del botón
        public string PhoneNumber { get; set; } // Color del botón
        public string UrlNetwork { get; set; } // URL de la red social
    }

    public class PersonProfessionResponse
    {
        public Guid Id { get; set; }
        public Guid PersonID { get; set; }
        public Guid ProfessionID { get; set; }
        public ProfessionResponse Profession { get; set; }
    }
    public class ProfessionResponse
    {
        public Guid Id { get; set; }
        public string ProfessionName { get; set; }
        public Guid CategoryID { get; set; }
        public UserCategoryResponse Category { get; set; }
    }
    public class UserCategoryResponse
    {
        public Guid Id { get; set; }
        public string CategoryName { get; set; }
    }


    public class PersonTagResponse
    {
        public Guid Id { get; set; }
        public Guid PersonID { get; set; }
        public Guid TagID { get; set; }

        // Navigation properties
        public Tag Tag { get; set; }
    }
    public class TagResponse
    {
        public Guid Id { get; set; }
        public string TagName { get; set; }
    }


    public class NetworkResponse
    {
        public Guid Id { get; set; }
        public Guid UserID { get; set; }  // Clave foránea que referencia a User(ID)
        public string Description { get; set; }  // Descripción del enlace (e.g., "Facebook", "Instagram")
        public string URL { get; set; }  // URL del perfil o enlace
        public Guid NetworkTypeID { get; set; }  // Clave foránea que referencia a NetworkType(ID)
        public NetworkType NetworkType { get; set; }
    }
    public class NetworkTypeResponse
    {
        public Guid Id { get; set; }
        public string Description { get; set; }  // Descripción del tipo de red social (e.g., "Social Media", "Website")
        public string IconURL { get; set; }  // Descripción del tipo de red social (e.g., "Social Media", "Website")
    }


    public class UserAddressResponse
    {
        public Guid Id { get; set; }
        public Guid UserID { get; set; }
        public Guid StreetID { get; set; }
        public Guid? CoordinatesID { get; set; }

        public Street Street { get; set; }
        public Coordinates Coordinates { get; set; }
    }
    public class StreetResponse
    {
        public Guid Id { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string Floor { get; set; }
        public Guid CityID { get; set; }
        public City City { get; set; }
    }
    public class CoordinatesResponse
    {
        public Guid Id { get; set; }
        public decimal Lng { get; set; }  // Longitud
        public decimal Lat { get; set; }  // Latitud
        public string GoogleMapsURL { get; set; }
    }

    public class AddressProfileResponse
    {
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string Floor { get; set; }

        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string URLMaps { get; set; }
    }
    public class TestResponse
    { }
}