using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    internal class ContactTypeConfiguration : BaseCrudEntityConfiguration<ContactType, Guid>
    {
        public override void Configure(EntityTypeBuilder<ContactType> builder)
        {
            base.Configure("PARK_CONTACT_TYPE", builder);

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();
            builder.Property(e => e.Description)
                   .HasColumnName("DESCRIPTION")
                   .IsRequired();


            builder.HasMany(e => e.CustomerAddres)
              .WithOne(e => e.ContactTypes)
              .HasForeignKey(e => e.ContactTypeId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.CustomerMails)
              .WithOne(e => e.ContactTypes)
              .HasForeignKey(e => e.ContactTypeId)
              .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.CustomerPhones)
              .WithOne(e => e.ContactTypes)
              .HasForeignKey(e => e.ContactTypeId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
