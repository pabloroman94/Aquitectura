using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Customer.Api.Models.Request
{
    public class CardPersonResponse
    {
        public Guid Id { get; set; }
        public string ProfileImage { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<string> Professions { get; set; }
        public string ShortDescription { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}