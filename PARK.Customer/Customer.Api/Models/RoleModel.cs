using CustomerApp.Api.Models.SeedWork;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net;

namespace Customer.Api.Models
{
    public class RoleModel : BaseCrudEntityModel<Guid>
    {
        public string Description { get; set; }  // Descripción del rol (e.g., "Admin", "User", "Manager")

        // Navigation property
        //public IEnumerable<CredentialModel> Credentials { get; set; }  // Una relación uno a muchos con Credential
    }
}
