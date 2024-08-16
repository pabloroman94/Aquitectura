using CustomerApp.Api.Models.SeedWork;
using System;
using System.Collections.Generic;

namespace Customer.Api.Models
{
    public class NetworkTypeModel : BaseCrudEntityModel<Guid>
    {
        public string Description { get; set; }  // Descripción del tipo de red social (e.g., "Social Media", "Website")
        public string IconURL { get; set; }  // Descripción del tipo de red social (e.g., "Social Media", "Website")

        // Navigation property
        //public IEnumerable<Network> Networks { get; set; }  // Una relación uno a muchos con Network
    }
}
