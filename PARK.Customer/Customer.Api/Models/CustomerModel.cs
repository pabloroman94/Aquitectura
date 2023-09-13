using CustomerApp.Api.Models.SeedWork;
using System;
using System.Collections.Generic;

namespace Customer.Api.Models
{
    public class CustomerModel : BaseCrudEntityModel<Guid>
    {
        public int DocumentNumber { get; set; }
        public Guid? DocumentTypeId { get; set; }
        public Guid? ComunityId { get; set; }
        public string InvoiceType { get; set; }
        public IEnumerable<PhotoModel>? CustomerPhotos { get; set; }
        public IEnumerable<MailModel>? CustomerMails { get; set; }
        public IEnumerable<PhoneModel>? CustomerPhones { get; set; }
        public IEnumerable<AddressModel>? CustomerAddress { get; set; }
        public DocumentTypeModel? DocumentType { get; set; }
        public IEnumerable<CompanyContactPersonModel>? CustomerPersonContacts { get; set; }
    }
}
