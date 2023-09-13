using Domain.Entities;
using Domain.Entities.Enums;
using System;

namespace Application.Specifications
{
    public class CompanySpecification : BaseSpecification<Company>
    {
        public CompanySpecification() : base(x => x.Active.Equals(BoolCharEnum.Y))
        {
            ApplyOrderBy(x => x.Id);
        }
        public CompanySpecification(Guid? documentType, int documentNumber) : base(x => x.DocumentNumber.Equals(documentNumber) && x.DocumentTypeId.Equals(documentType)
                                                                            && x.Active.Equals(BoolCharEnum.Y))
        {
            ApplyOrderBy(x => x.Id);
            AddInclude(x => x.CustomerPhotos);
            AddInclude(x => x.CustomerMails);
            AddInclude(x => x.CustomerPhones);
            AddInclude(x => x.CustomerAddress);
            AddInclude(x => x.DocumentType);
            AddInclude(x => x.CustomerPersonContacts);

            AddInclude($"{nameof(Company.CustomerAddress)}.{nameof(Address.ContactTypes)}");
            AddInclude($"{nameof(Company.CustomerMails)}.{nameof(Mail.ContactTypes)}");
            AddInclude($"{nameof(Company.CustomerPhones)}.{nameof(Phone.ContactTypes)}");
            AddInclude($"{nameof(Company.CustomerPersonContacts)}.{nameof(CompanyContactPerson.Person)}");

            AddInclude($"{nameof(Company.CustomerPersonContacts)}.{nameof(CompanyContactPerson.Person)}.{nameof(Person.CustomerAddress)}");
            AddInclude($"{nameof(Company.CustomerPersonContacts)}.{nameof(CompanyContactPerson.Person)}.{nameof(Person.CustomerMails)}");
            AddInclude($"{nameof(Company.CustomerPersonContacts)}.{nameof(CompanyContactPerson.Person)}.{nameof(Person.CustomerPhones)}");
            AddInclude($"{nameof(Company.CustomerPersonContacts)}.{nameof(CompanyContactPerson.Person)}.{nameof(Person.CustomerPhotos)}");
        }
        public CompanySpecification(string nameCompany) : base(x => x.CompanyName.Equals(nameCompany) 
                                                                            && x.Active.Equals(BoolCharEnum.Y))
        {
            ApplyOrderBy(x => x.Id);
            AddInclude(x => x.CustomerPhotos);
            AddInclude(x => x.CustomerMails);
            AddInclude(x => x.CustomerPhones);
            AddInclude(x => x.CustomerAddress);
            AddInclude(x => x.DocumentType);
            AddInclude(x => x.CustomerPersonContacts);

            AddInclude($"{nameof(Company.CustomerAddress)}.{nameof(Address.ContactTypes)}");
            AddInclude($"{nameof(Company.CustomerMails)}.{nameof(Mail.ContactTypes)}");
            AddInclude($"{nameof(Company.CustomerPhones)}.{nameof(Phone.ContactTypes)}");
            AddInclude($"{nameof(Company.CustomerPersonContacts)}.{nameof(CompanyContactPerson.Person)}");

            AddInclude($"{nameof(Company.CustomerPersonContacts)}.{nameof(CompanyContactPerson.Person)}.{nameof(Person.CustomerAddress)}");
            AddInclude($"{nameof(Company.CustomerPersonContacts)}.{nameof(CompanyContactPerson.Person)}.{nameof(Person.CustomerMails)}");
            AddInclude($"{nameof(Company.CustomerPersonContacts)}.{nameof(CompanyContactPerson.Person)}.{nameof(Person.CustomerPhones)}");
            AddInclude($"{nameof(Company.CustomerPersonContacts)}.{nameof(CompanyContactPerson.Person)}.{nameof(Person.CustomerPhotos)}");
        }
    }
}