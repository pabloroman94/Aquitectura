﻿using Domain.Entities.Enums;
using System;

namespace Customer.Api.Models.Request
{
    public class UserPersonRequest //: UserRequest
    {
        public DateTime FInsert { get; set; }
        public string UserName { get; set; }
        public DateTime? FUpdate { get; set; }
        public string? UserNameUpdate { get; set; }
        public string Username { get; set; }
        public string ProfileDescription { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Gender { get; set; }


        //// Propiedades obligatorias de BaseStampEntity
        //public BoolCharEnum Active { get; set; }
        //public int Version { get; set; }
    }
}