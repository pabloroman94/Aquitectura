using CustomerApp.Api.Models.SeedWork;
using System;

namespace Customer.Api.Models
{
    public class DocumentTypeModel : BaseCrudEntityModel<Guid>
    {
        public string Description { get; set; }
        public int? CustomerType { get; set; }
    }
}