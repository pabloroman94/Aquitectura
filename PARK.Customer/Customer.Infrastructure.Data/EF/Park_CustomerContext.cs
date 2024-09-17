using Domain.Entities;
using Domain.Interfaces.Aplication;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data.EF
{
    public class Park_CustomerContext : DbContext
    {
        public Park_CustomerContext(DbContextOptions<Park_CustomerContext> options)
            : base(options)
        { }

        //public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Photo> CustomerPhotos { get; set; }
        public virtual DbSet<Mail> CustomerMails { get; set; }
        public virtual DbSet<Phone> CustomerPhones { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<Address> CustomerAddress { get; set; }
        public virtual DbSet<ContactType> ContactTypes { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<CompanyContactPerson> CustomerPersonContact { get; set; }
        
        public virtual DbSet<UserEmail> UserEmails { get; set; }
        public virtual DbSet<UserPhoto> UserPhotos { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<UserPerson> UserPeople { get; set; }
        public virtual DbSet<PersonProfession> PersonProfessions { get; set; }
        public virtual DbSet<Profession> Professions { get; set; }
        public virtual DbSet<UserCategory> UserCategories { get; set; }
        public virtual DbSet<UserCompany> UserCompanies { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<PersonTag> PersonTags { get; set; }
        public virtual DbSet<CompanyTag> CompanyTags { get; set; }
        public virtual DbSet<CompanyBusinessType> CompanyBusinessTypes { get; set; }
        public virtual DbSet<BusinessType> BusinessTypes { get; set; }
        public virtual DbSet<UserAddress> UserAddresses { get; set; }
        public virtual DbSet<Street> Streets { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Coordinates> Coordinates { get; set; }
        public virtual DbSet<Network> Networks { get; set; }
        public virtual DbSet<NetworkType> NetworkTypes { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<Classification> Classification { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
