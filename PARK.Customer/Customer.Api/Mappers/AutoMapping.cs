using AutoMapper;
using Customer.Api.Models;
using Customer.Api.Models.Request;
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
            CreateMap<UserPersonModel, UserPerson>()
                .ForMember(dest => dest.PersonTags, opt => opt.MapFrom(src => src.PersonTags))
                .ReverseMap();
            CreateMap<UserCompanyModel, Domain.Entities.UserCompany>().ReverseMap();
            CreateMap<UserCategoryModel, Domain.Entities.UserCategory>().ReverseMap();
            CreateMap<TagModel, Domain.Entities.Tag>().ReverseMap();
            //CreateMap<PersonTagModel, Domain.Entities.PersonTag>().ReverseMap();
            CreateMap<PersonTagModel, PersonTag>()
            .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.Person))  // Mapear la propiedad de navegación
            .ForMember(dest => dest.Tag, opt => opt.MapFrom(src => src.Tag))
            .ReverseMap();

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
            CreateMap<SubCategoryModel, Domain.Entities.SubCategory>().ReverseMap();
            CreateMap<ClassificationModel, Domain.Entities.Classification>().ReverseMap();

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

            CreateMap<UserPersonResponse, Domain.Entities.UserPerson>().ReverseMap();
            CreateMap<UserPersonModel, UserPersonResponse>().ReverseMap();

            //CreateMap<UserPersonRequest, Domain.Entities.UserPerson>().ReverseMap();
            //CreateMap<UserPersonModel, UserPersonRequest>().ReverseMap();

            //CreateMap<UserRequest, Domain.Entities.User>().ReverseMap();
            //CreateMap<UserPerson, UserRequest>().ReverseMap();

            CreateMap<UserPersonRequest, UserPerson>()
               .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
               .ForMember(dest => dest.ProfileDescription, opt => opt.MapFrom(src => src.ProfileDescription))
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
               .ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.Birthdate))
               .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
               // Mapeo de las propiedades de BaseStampEntity
               //.ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active))
               .ForMember(dest => dest.FInsert, opt => opt.MapFrom(src => src.FInsert))
               .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
               //.ForMember(dest => dest.Version, opt => opt.MapFrom(src => src.Version))
               .ForMember(dest => dest.FUpdate, opt => opt.MapFrom(src => src.FUpdate))
               .ForMember(dest => dest.UserNameUpdate, opt => opt.MapFrom(src => src.UserNameUpdate))
               // Ignorar propiedades de navegación si no se van a mapear directamente desde el request
               .ForMember(dest => dest.PersonProfessions, opt => opt.Ignore())
               .ForMember(dest => dest.PersonTags, opt => opt.Ignore());
        }
    }
}
