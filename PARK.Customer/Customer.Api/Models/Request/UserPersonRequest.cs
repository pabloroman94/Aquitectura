using Domain.Entities;
using Domain.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Customer.Api.Models.Request
{
    public class UserPersonRequest //: UserRequest
    {
        public DateTime FInsert { get; set; }
        public string UserName { get; set; }
        public DateTime? FUpdate { get; set; }
        public string? UserNameUpdate { get; set; }
        public string Username { get; set; }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string ProfileImage { get; set; }
        public string Gender { get; set; }
        public string ShortDescription { get; set; }
        public string ProfileTitle { get; set; }
        public string LongDescription { get; set; }
        public List<string> Tags { get; set; }
        public List<string> Professions { get; set; }
        public AddressProfileRequest AddressProfile { get; set; }
        public List<NetworkProfileRequest> NetworkProfiles { get; set; }

        public UserPersonRequest()
        {
            Tags = new List<string>();
            Professions = new List<string>();
            NetworkProfiles = new List<NetworkProfileRequest>();
        }
    }
    public class AddressProfileRequest
    {
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string Floor { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string UrlMaps { get; set; }
    }

    public class NetworkProfileRequest
    {
        public string Title { get; set; }
        public string UrlIcon { get; set; }
        public string ButtonColor { get; set; }
        public string PhoneNumber { get; set; }
        public string UrlNetwork { get; set; }
    }
}
