using Domain.Entities;
using Domain.Entities.Enums;
using System;

namespace Application.Specifications
{
    public class CustomerListByDocument : BaseSpecification<Customer>
    {
        public CustomerListByDocument() : base(x => x.Active.Equals(BoolCharEnum.Y))
        {
            ApplyOrderBy(x => x.Id);
        }
        public CustomerListByDocument(string documentType, string documentNumber) : base(x => x.DocumentNumber.Equals(documentNumber) && x.DocumentTypeId.Equals(documentType) 
                                                                            && x.Active.Equals(BoolCharEnum.Y))
        {
            ApplyOrderBy(x => x.Id);
            AddInclude(x=>x.CustomerPhotos);
            AddInclude($"{nameof(Customer.CustomerPhotos)}");
            AddInclude(x=>x.CustomerMails);
            AddInclude($"{nameof(Mail.Customer)}");
            AddInclude(x => x.CustomerPhones);
            AddInclude($"{nameof(Phone.Customer)}");
        }
    }
}
