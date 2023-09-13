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
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<Address> CustomerAddress { get; set; }
        public virtual DbSet<ContactType> ContactTypes { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<CompanyContactPerson> CustomerPersonContact { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            if (Database.IsOracle())
            {   //If you need, manually add a Schema name, if you don't need a schema name before the default, you don't need to configure it.
                //modelBuilder.HasDefaultSchema("EVMS");//If you use Oracle, you must manually add Schema, it is judged that the current database is Oracle to manually add Schema (DBA supplied database account name)

                //If you use Oracle, you must manually add Schema, it is judged that the current database is Oracle to manually add Schema (DBA supplied database account name)
                modelBuilder.HasDefaultSchema("PARK");//Notice: DBA providedDatabase account name, must be capitalized
            }

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
