using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Customer : BaseCrudEntity<Guid> 
    {
        public int DocumentNumber { get; set; }
        public Guid? DocumentTypeId { get; set; }
        public Guid? ComunityId { get; set; }
        public string InvoiceType { get; set; }
        public IEnumerable<Photo> CustomerPhotos { get; set; }
        public IEnumerable<Mail> CustomerMails { get; set; }
        public IEnumerable<Phone> CustomerPhones { get; set; }
        public IEnumerable<Address> CustomerAddress { get; set; }
        public DocumentType DocumentType { get; set; }


        public IEnumerable<CompanyContactPerson> CustomerPersonContacts { get; set; }
        //public CompanyContactPerson CustomerPersonContact { get; set; }


    }
}