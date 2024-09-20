using AutoMapper;
using Customer.Api.Models;
using Customer.Api.Models.Request;
using Domain.Entities;
using System.Collections.Generic;
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

            //CreateMap<UserPersonResponse, Domain.Entities.UserPerson>().ReverseMap();
            //CreateMap<UserPersonModel, UserPersonResponse>().ReverseMap();

            //CreateMap<UserPersonRequest, Domain.Entities.UserPerson>().ReverseMap();
            //CreateMap<UserPersonModel, UserPersonRequest>().ReverseMap();

            //CreateMap<UserRequest, Domain.Entities.User>().ReverseMap();
            //CreateMap<UserPerson, UserRequest>().ReverseMap();

            CreateMap<UserPersonRequest, UserPerson>()
               .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
               .ForMember(dest => dest.ProfileDescription, opt => opt.MapFrom(src => src.ProfileDescription))
               .ForMember(dest => dest.PersonTags, opt => opt.MapFrom(src => src.PersonTags))
               .ForMember(dest => dest.PersonProfessions, opt => opt.MapFrom(src => src.PersonProfessions))
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
               .ForMember(dest => dest.UserNameUpdate, opt => opt.MapFrom(src => src.UserNameUpdate));
            // Ignorar propiedades de navegación si no se van a mapear directamente desde el request
            //.ForMember(dest => dest.PersonProfessions, opt => opt.Ignore())
            //.ForMember(dest => dest.PersonTags, opt => opt.Ignore());



            CreateMap<PersonTagRequest, PersonTag>()
                .ForMember(dest => dest.TagID, opt => opt.MapFrom(src => src.TagID))
                .ReverseMap();
            CreateMap<PersonProfessionRequest, PersonProfession>().ReverseMap();
            CreateMap<NetworkRequest, Network>().ReverseMap();
            CreateMap<UserAddressRequest, UserAddress>().ReverseMap();




            // Mapeo para UserPerson y UserPersonResponse, propiedad por propiedad
            CreateMap<UserPerson, UserPersonResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                //.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName ?? "Unknown")) // Manejo de null
                //.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName ?? "Unknown")) // Manejo de null
                //.ForMember(dest => dest.Birthdate, opt => opt.MapFrom(src => src.Birthdate))
                //.ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender ?? "Not specified")) // Manejo de null
                //.ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username ?? "Unknown")) // Manejo de null
                //.ForMember(dest => dest.ProfileDescription, opt => opt.MapFrom(src => src.ProfileDescription ?? string.Empty)) // Manejo de null
                //.ForMember(dest => dest.PersonProfessions, opt => opt.MapFrom(src => src.PersonProfessions ?? new List<PersonProfession>())) // Manejo de null para listas
                //.ForMember(dest => dest.PersonTags, opt => opt.MapFrom(src => src.PersonTags ?? new List<PersonTag>())) // Manejo de null para listas
                //.ForMember(dest => dest.Networks, opt => opt.MapFrom(src => src.Networks ?? new List<Network>())) // Manejo de null para listas
                //.ForMember(dest => dest.UserAddresses, opt => opt.MapFrom(src => src.UserAddresses ?? new List<UserAddress>())) // Manejo de null para listas
                .ReverseMap(); // Map automático en ambas direcciones

            // Mapeo para PersonProfession y PersonProfessionResponse
            CreateMap<PersonProfession, PersonProfessionResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PersonID, opt => opt.MapFrom(src => src.PersonID))
                .ForMember(dest => dest.ProfessionID, opt => opt.MapFrom(src => src.ProfessionID))
                .ForMember(dest => dest.Profession, opt => opt.MapFrom(src => src.Profession ?? new Profession())) // Manejo de null
                .ReverseMap();

            // Mapeo para Profession y ProfessionResponse
            CreateMap<Profession, ProfessionResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ProfessionName, opt => opt.MapFrom(src => src.ProfessionName ?? "Unknown")) // Manejo de null
                .ForMember(dest => dest.CategoryID, opt => opt.MapFrom(src => src.CategoryID))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category ?? new UserCategory())) // Manejo de null
                .ReverseMap();

            // Mapeo para UserCategory y UserCategoryResponse
            CreateMap<UserCategory, UserCategoryResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.CategoryName ?? "Unknown")) // Manejo de null
                .ReverseMap();

            // Mapeo para PersonTag y PersonTagResponse
            CreateMap<PersonTag, PersonTagResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PersonID, opt => opt.MapFrom(src => src.PersonID))
                .ForMember(dest => dest.TagID, opt => opt.MapFrom(src => src.TagID))
                .ForMember(dest => dest.Tag, opt => opt.MapFrom(src => src.Tag ?? new Tag())) // Manejo de null
                .ReverseMap();

            // Mapeo para Tag y TagResponse
            CreateMap<Tag, TagResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TagName, opt => opt.MapFrom(src => src.TagName ?? "Unknown")) // Manejo de null
                .ReverseMap();

            // Mapeo para Network y NetworkResponse
            CreateMap<Network, NetworkResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description ?? string.Empty)) // Manejo de null
                .ForMember(dest => dest.URL, opt => opt.MapFrom(src => src.URL ?? string.Empty)) // Manejo de null
                .ForMember(dest => dest.NetworkTypeID, opt => opt.MapFrom(src => src.NetworkTypeID))
                .ForMember(dest => dest.NetworkType, opt => opt.MapFrom(src => src.NetworkType ?? new NetworkType())) // Manejo de null
                .ReverseMap();

            // Mapeo para NetworkType y NetworkTypeResponse
            CreateMap<NetworkType, NetworkTypeResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description ?? "Unknown")) // Manejo de null
                .ForMember(dest => dest.IconURL, opt => opt.MapFrom(src => src.IconURL ?? string.Empty)) // Manejo de null
                .ReverseMap();

            // Mapeo para UserAddress y UserAddressResponse
            CreateMap<UserAddress, UserAddressResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID))
                .ForMember(dest => dest.StreetID, opt => opt.MapFrom(src => src.StreetID))
                .ForMember(dest => dest.CoordinatesID, opt => opt.MapFrom(src => src.CoordinatesID))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street ?? new Street())) // Manejo de null
                .ForMember(dest => dest.Coordinates, opt => opt.MapFrom(src => src.Coordinates ?? new Coordinates())) // Manejo de null
                .ReverseMap();

            // Mapeo para Street y StreetResponse
            CreateMap<Street, StreetResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.StreetName, opt => opt.MapFrom(src => src.StreetName ?? "Unknown")) // Manejo de null
                .ForMember(dest => dest.StreetNumber, opt => opt.MapFrom(src => src.StreetNumber ?? "N/A")) // Manejo de null
                .ForMember(dest => dest.Floor, opt => opt.MapFrom(src => src.Floor ?? "N/A")) // Manejo de null
                .ForMember(dest => dest.CityID, opt => opt.MapFrom(src => src.CityID))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City ?? new City())) // Manejo de null
                .ReverseMap();

            // Mapeo para Coordinates y CoordinatesResponse
            CreateMap<Coordinates, CoordinatesResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Lng, opt => opt.MapFrom(src => src.Lng))
                .ForMember(dest => dest.Lat, opt => opt.MapFrom(src => src.Lat))
                .ForMember(dest => dest.GoogleMapsURL, opt => opt.MapFrom(src => src.GoogleMapsURL ?? string.Empty)) // Manejo de null
                .ReverseMap();


              //CreateMap<UserPerson, CardPersonResponse>()
              //  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              //  .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.ProfileImage))
              //  .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
              //  .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName ?? string.Empty)) // Manejo de null
              //  //.ForMember(dest => dest.Professions, opt => opt.MapFrom(src => src.PersonProfessions ?? string.Empty)) // Manejo de null
              //  .ForMember(dest => dest.ShortDescription, opt => opt.MapFrom(src => src.ProfileDescription ?? string.Empty)) // Manejo de null
              //  //.ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.GoogleMapsURL ?? string.Empty)) // Manejo de null
              //  .ReverseMap();

            CreateMap<UserPerson, CardPersonResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Professions, opt => opt.MapFrom(src => src.PersonProfessions.Select(pt => pt.Profession.ProfessionName)))
            .ForMember(dest => dest.ShortDescription, opt => opt.MapFrom(src => src.ProfileDescription))
                .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.ProfileImage))
            .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.PersonTags.Select(pt => pt.Tag.TagName)));


            CreateMap<AddressProfile, AddressProfileResponse>().ReverseMap();
            CreateMap<NetworkProfile, NetworkProfileResponse>().ReverseMap();
        }

    }
}
