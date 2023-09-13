using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class CompanyContactPersonConfiguration : BaseCrudEntityConfiguration<CompanyContactPerson, Guid>
    {
        public override void Configure(EntityTypeBuilder<CompanyContactPerson> builder)
        {
            base.Configure("PARK_COMPANY_PERSON_CONTACT", builder);

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(e => e.CustomerId)
                   .HasColumnName("CUSTOMER_ID")
                                .IsRequired();

            builder.Property(e => e.PersonId)
                   .HasColumnName("PERSON_ID")
                   .IsRequired();

            builder.Property(e => e.Preferred)
                   .HasColumnName("PREFERRED")
                   .IsRequired();

            builder.HasOne(e => e.Customer)
                .WithMany(e => e.CustomerPersonContacts)
                .HasForeignKey(e => e.CustomerId);

            //builder.HasOne(e => e.Person)
            //    .WithOne(e => e.CustomerPersonContact)
            //    .HasForeignKey<CompanyContactPerson>(b => b.PersonId);

            //builder.HasOne(p => p.Person_)
            //.WithMany(b => b.CustomerPersonContacts);

        }
    }
}