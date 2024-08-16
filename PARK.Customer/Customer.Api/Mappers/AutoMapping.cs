using AutoMapper;
using Customer.Api.Models;
using Domain.Entities;
using System.Linq;

namespace PARK.CustomerApi.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            //CreateMap<CustomerModel,  Domain.Entities.Customer> ().ReverseMap();
            CreateMap<Domain.Entities.Person, PersonModel>().ReverseMap();
            CreateMap<CompanyModel, Domain.Entities.Company>().ReverseMap();
            CreateMap<PhotoModel, Domain.Entities.Photo>().ReverseMap();
            CreateMap<MailModel, Domain.Entities.Mail>().ReverseMap();
            CreateMap<PhoneModel, Domain.Entities.Phone>().ReverseMap();
            CreateMap<DocumentTypeModel, Domain.Entities.DocumentType>().ReverseMap();
            CreateMap<AddressModel, Domain.Entities.Address>().ReverseMap();
            CreateMap<ContactTypeModel, Domain.Entities.ContactType>().ReverseMap();
            CreateMap<GenderModel, Domain.Entities.Gender>().ReverseMap();
            CreateMap<CompanyContactPersonModel, Domain.Entities.CompanyContactPerson>().ReverseMap();
            CreateMap<PersonModel, Domain.Entities.Person>().ReverseMap();
            CreateMap<PersonProfessionModel, Domain.Entities.PersonProfession>().ReverseMap();
            CreateMap<ProfessionModel, Domain.Entities.Profession>().ReverseMap();

            CreateMap<UserEmailModel, Domain.Entities.UserEmail>().ReverseMap();
            CreateMap<UserPhotoModel, Domain.Entities.UserPhoto>().ReverseMap();
            CreateMap<UserModel, Domain.Entities.User>().ReverseMap();
            CreateMap<UserPersonModel, Domain.Entities.UserPerson>().ReverseMap();
            CreateMap<UserCompanyModel, Domain.Entities.UserCompany>().ReverseMap();
            CreateMap<UserCategoryModel, Domain.Entities.UserCategory>().ReverseMap();
            CreateMap<TagModel, Domain.Entities.Tag>().ReverseMap();
            CreateMap<PersonTagModel, Domain.Entities.PersonTag>().ReverseMap();
            CreateMap<CompanyTagModel, Domain.Entities.CompanyTag>().ReverseMap();
            CreateMap<CompanyBusinessTypeModel, Domain.Entities.CompanyBusinessType>().ReverseMap();
            CreateMap<BusinessTypeModel, Domain.Entities.BusinessType>().ReverseMap();
            CreateMap<UserAddressModel, Domain.Entities.UserAddress>().ReverseMap();
            CreateMap<StreetModel, Domain.Entities.Street>().ReverseMap();
            CreateMap<ProvinceModel, Domain.Entities.Province>().ReverseMap();
            CreateMap<CityModel, Domain.Entities.City>().ReverseMap();
            CreateMap<CoordinatesModel, Domain.Entities.Coordinates>().ReverseMap();
            CreateMap<NetworkModel, Domain.Entities.Network>().ReverseMap();
            CreateMap<NetworkTypeModel, Domain.Entities.NetworkType>().ReverseMap();

            CreateMap<Address, Person>().ReverseMap()
                    .ForMember(d => d.StreetName, m => m.MapFrom(s => s.CustomerAddress.FirstOrDefault().StreetName))
                   .ForMember(d => d.StreetNumber, m => m.MapFrom(s => s.CustomerAddress.FirstOrDefault().StreetNumber))
                   .ForMember(d => d.Floor, m => m.MapFrom(s => s.CustomerAddress.FirstOrDefault().Floor))
                   .ForMember(d => d.Dept, m => m.MapFrom(s => s.CustomerAddress.FirstOrDefault().Dept))
                   .ForMember(d => d.City, m => m.MapFrom(s => s.CustomerAddress.FirstOrDefault().City))
                   .ForMember(d => d.PostalCode, m => m.MapFrom(s => s.CustomerAddress.FirstOrDefault().PostalCode))
                   .ForMember(d => d.Country, m => m.MapFrom(s => s.CustomerAddress.FirstOrDefault().Country))
                   .ForMember(d => d.ContactTypeId, m => m.MapFrom(s => s.CustomerAddress.FirstOrDefault().ContactTypeId));

            CreateMap<Domain.Entities.Customer, Person>().ReverseMap()
                   .ForMember(d => d.DocumentNumber, m => m.MapFrom(s => s.DocumentNumber))
                   .ForMember(d => d.DocumentTypeId, m => m.MapFrom(s => s.DocumentTypeId))
                   .ForMember(d => d.CustomerMails, m => m.Ignore())
                   .ForMember(d => d.CustomerPhones, m => m.Ignore())
                   .ForMember(d => d.CustomerAddress, m => m.Ignore());

            CreateMap<Mail, Person>().ReverseMap()
                    .ForMember(d => d.Email, m => m.MapFrom(s => s.CustomerMails.FirstOrDefault().Email))
                    .ForMember(d => d.ContactTypeId, m => m.MapFrom(s => s.CustomerMails.FirstOrDefault().ContactTypeId))
                    .ForMember(d => d.Customer, m => m.Ignore())
                    .ForMember(d => d.ContactTypes, m => m.Ignore());

            CreateMap<Phone, Person>().ReverseMap()
                    .ForMember(d => d.PhoneNumber, m => m.MapFrom(s => s.CustomerPhones.FirstOrDefault().PhoneNumber))
                    .ForMember(d => d.ContactTypeId, m => m.MapFrom(s => s.CustomerPhones.FirstOrDefault().ContactTypeId))
                    .ForMember(d => d.Customer, m => m.Ignore())
                    .ForMember(d => d.ContactTypes, m => m.Ignore());

        }
    }
}
