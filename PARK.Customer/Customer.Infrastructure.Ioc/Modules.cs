using Application.Aplications;
using Domain.Entities;
using Domain.Entities.Filters;
using Domain.Interfaces.Aplication;
using Domain.Interfaces.Aplication.SeedWork;
using Domain.Interfaces.Infraestructure.Data.SeedWork;
using Infrastructure.Data.Dapper.Mappers;
using Infrastructure.Data.Dapper.Mappers.Interfaces;
using Infrastructure.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Customer.Infrastructure.Ioc
{
    public static class Modules
    {
        public static void AddModules(this IServiceCollection services, IConfiguration configuration)
        {
            LoadModulesApplication(services);
            LoadModulesInfrastructureData(services, configuration);
            LoadModulesInfrastructure(services, configuration);
        }

        private static void LoadModulesApplication(IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseAplication<,,>), typeof(BaseAplication<,,>));
            services.AddScoped(typeof(IBaseCrudStampAplication<,,>), typeof(BaseCrudStampAplication<,,>));

            services.AddScoped<IBaseCrudStampAplication<Domain.Entities.Customer, Guid, CustomerFilter>, CustomerAplication>();
            services.AddScoped<IBaseStampAplication<Domain.Entities.Person, Guid, PersonFilter>, PersonAplication>();
            services.AddScoped<IBaseStampAplication<Domain.Entities.Company, Guid, CompanyFilter>, CompanyAplication>();
            services.AddScoped<IBaseStampAplication<Domain.Entities.Phone, Guid, PhoneFilter>, PhoneAplication>();
            services.AddScoped<IBaseStampAplication<Domain.Entities.Gender, Guid, GenderFilter>, GenderAplication>();
            services.AddScoped<IBaseStampAplication<DocumentType, Guid, DocumentTypeFilter>, DocumentTypeAplication>();
            services.AddScoped<IBaseStampAplication<CompanyContactPerson, Guid, CompanyContactPersonFilter>, CompanyContactPersonAplication>();
            services.AddScoped<IBaseStampAplication<UserEmail, Guid, UserEmailFilter>, UserEmailAplication>();
            services.AddScoped<IBaseStampAplication<User, Guid, UserFilter>, UserAplication>();
            services.AddScoped<IBaseStampAplication<Domain.Entities.UserPhoto, Guid, UserPhotoFilter>, UserPhotoAplication>();
            services.AddScoped<IBaseStampAplication<Domain.Entities.UserPerson, Guid, UserPersonFilter>, UserPersonAplication>();
            services.AddScoped<IBaseStampAplication<Domain.Entities.PersonProfession, Guid, PersonProfessionFilter>, PersonProfessionAplication>();
            services.AddScoped<IBaseStampAplication<Domain.Entities.Profession, Guid, ProfessionFilter>, ProfessionAplication>();
            services.AddScoped<IBaseStampAplication<Domain.Entities.UserCategory, Guid, UserCategoryFilter>, UserCategoryAplication>();
            services.AddScoped<IBaseStampAplication<Domain.Entities.UserCompany, Guid, UserCompanyFilter>, UserCompanyAplication>();
            services.AddScoped<IBaseStampAplication<Domain.Entities.Tag, Guid, TagFilter>, TagAplication>();
            services.AddScoped<IBaseStampAplication<Domain.Entities.PersonTag, Guid, PersonTagFilter>, PersonTagAplication>();
            services.AddScoped<IBaseStampAplication<Domain.Entities.CompanyTag, Guid, CompanyTagFilter>, CompanyTagAplication>();
            services.AddScoped<IBaseStampAplication<Domain.Entities.CompanyBusinessType, Guid, CompanyBusinessTypeFilter>, CompanyBusinessTypeAplication>();
            services.AddScoped<IBaseStampAplication<Domain.Entities.BusinessType, Guid, BusinessTypeFilter>, BusinessTypeAplication>();
            services.AddScoped<IBaseStampAplication<Domain.Entities.UserAddress, Guid, UserAddressFilter>, UserAddressAplication>();
            services.AddScoped<IBaseStampAplication<Domain.Entities.Street, Guid, StreetFilter>, StreetAplication>();
            services.AddScoped<IBaseStampAplication<Domain.Entities.Province, Guid, ProvinceFilter>, ProvinceAplication>();
            services.AddScoped<IBaseStampAplication<Domain.Entities.City, Guid, CityFilter>, CityAplication>();
            services.AddScoped<IBaseStampAplication<Domain.Entities.Coordinates, Guid, CoordinatesFilter>, CoordinatesAplication>();
            services.AddScoped<IBaseStampAplication<Domain.Entities.Network, Guid, NetworkFilter>, NetworkAplication>();
            services.AddScoped<IBaseStampAplication<Domain.Entities.NetworkType, Guid, NetworkTypeFilter>, NetworkTypeAplication>();



            services.AddScoped<IPersonAplication, PersonAplication>();
            services.AddScoped<ICompanyAplication, CompanyAplication>();
            services.AddScoped<ICustomerAplication, CustomerAplication>();
            services.AddScoped<IMailAplication, MailAplication>();
            services.AddScoped<IDocumentTypeAplication, DocumentTypeAplication>();
            services.AddScoped<IGenderAplication, GenderAplication>();
            services.AddScoped<IAddressAplication, AddressAplication>();
            services.AddScoped<IPhoneAplication, PhoneAplication>();
            services.AddScoped<ICompanyContactPersonAplication, CompanyContactPersonAplication>();
            services.AddScoped<IUserEmailAplication, UserEmailAplication>();
            services.AddScoped<IUserPhotoAplication, UserPhotoAplication>();
            services.AddScoped<IUserAplication, UserAplication>();
            services.AddScoped<IUserPersonAplication, UserPersonAplication>();
            services.AddScoped<IPersonProfessionAplication, PersonProfessionAplication>();
            services.AddScoped<IProfessionAplication, ProfessionAplication>();
            services.AddScoped<IUserCategoryAplication, UserCategoryAplication>();
            services.AddScoped<IUserCompanyAplication, UserCompanyAplication>();
            services.AddScoped<ICompanyTagAplication, CompanyTagAplication>();
            services.AddScoped<ICompanyBusinessTypeAplication, CompanyBusinessTypeAplication>();
            services.AddScoped<IBusinessTypeAplication, BusinessTypeAplication>();
            services.AddScoped<IUserAddressAplication, UserAddressAplication>();
            services.AddScoped<IStreetAplication, StreetAplication>();
            services.AddScoped<IProvinceAplication, ProvinceAplication>();
            services.AddScoped<IProvinceAplication, ProvinceAplication>();
            services.AddScoped<ICityAplication, CityAplication>();
            services.AddScoped<ICoordinatesAplication, CoordinatesAplication>();
            services.AddScoped<INetworkAplication, NetworkAplication>();
            services.AddScoped<INetworkTypeAplication, NetworkTypeAplication>();
        }

        private static void LoadModulesInfrastructureData(IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<Park_CustomerContext>(
               options => options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 21)))
               );

            services.AddTransient<IDbConnection>(db =>
                new MySqlConnection(connection));

            #region Repositories
            services.AddScoped(typeof(IBaseRepository<,,>), typeof(BaseRepository<,,>));
            #endregion

            #region Mappers
            //services.AddScoped<ICustomerMap, CustomerMap>();
            #endregion
        }

        private static void LoadModulesInfrastructure(IServiceCollection services, IConfiguration configuration)
        {
            // Añadir otros módulos de infraestructura si es necesario
        }
    }
}
