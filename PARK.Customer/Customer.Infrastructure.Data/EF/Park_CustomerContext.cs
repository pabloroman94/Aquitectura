using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Data.EF
{
    public class Park_CustomerContext : DbContext
    {
        public Park_CustomerContext(DbContextOptions<Park_CustomerContext> options)
            : base(options)
        { }

        public virtual DbSet<Customer> Customers { get; set; }
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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
