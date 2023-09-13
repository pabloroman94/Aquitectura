using Domain.Entities;
using Domain.Entities.Enums;
using System;

namespace Application.Specifications
{
    public class PersonSpecification : BaseSpecification<Person>
    {
        public PersonSpecification() : base(x => x.Active.Equals(BoolCharEnum.Y))
        {
            ApplyOrderBy(x => x.Id);
        }
        public PersonSpecification(Guid? documentType, int documentNumber) : base(x => x.DocumentNumber.Equals(documentNumber) && x.DocumentTypeId.Equals(documentType)
                                                                            && x.Active.Equals(BoolCharEnum.Y))
        {
            ApplyOrderBy(x => x.Id);
            AddInclude(x => x.CustomerPhotos);
            AddInclude(x => x.CustomerMails);
            AddInclude(x => x.CustomerPhones);
            AddInclude(x => x.CustomerAddress);
            AddInclude(x => x.Gender);
            AddInclude(x => x.DocumentType);
            AddInclude($"{nameof(Company.CustomerAddress)}.{nameof(Address.ContactTypes)}");
            AddInclude($"{nameof(Company.CustomerMails)}.{nameof(Mail.ContactTypes)}");
            AddInclude($"{nameof(Company.CustomerPhones)}.{nameof(Phone.ContactTypes)}");

        }
        public PersonSpecification(string name, string lastname) : base(x => x.Name.Equals(name) && x.Lastname.Equals(lastname)
                                                                            && x.Active.Equals(BoolCharEnum.Y))
        {
            ApplyOrderBy(x => x.Id);
            AddInclude(x => x.CustomerPhotos);
            AddInclude(x => x.CustomerMails);
            AddInclude(x => x.CustomerPhones);
            AddInclude(x => x.CustomerAddress);
            AddInclude(x => x.Gender);
            AddInclude(x => x.DocumentType);
            AddInclude($"{nameof(Company.CustomerAddress)}.{nameof(Address.ContactTypes)}");
            AddInclude($"{nameof(Company.CustomerMails)}.{nameof(Mail.ContactTypes)}");
            AddInclude($"{nameof(Company.CustomerPhones)}.{nameof(Phone.ContactTypes)}");
        }
    }
}
