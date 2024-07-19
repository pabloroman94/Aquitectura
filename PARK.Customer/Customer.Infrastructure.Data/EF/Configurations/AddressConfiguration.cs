using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class AddressConfiguration : BaseCrudEntityConfiguration<Address, Guid>
    {
        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            base.Configure("PARK_CUSTOMER_ADDRESS", builder);

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(e => e.CustomerId)
                   .HasColumnName("CUSTOMER_ID")
                   .IsRequired();

            builder.Property(e => e.ContactTypeId)
                   .HasColumnName("CONTACT_TYPE_ID")
                   .IsRequired();

            builder.Property(e => e.StreetName)
                   .HasColumnName("STREETNAME")
                   .IsRequired();

            builder.Property(e => e.StreetNumber)
                   .HasColumnName("STREETNUMBER")
                   .IsRequired();

            builder.Property(e => e.Floor)
                   .HasColumnName("FLOOR")
                   .IsRequired();

            builder.Property(e => e.Dept)
                   .HasColumnName("DEPT")
                   .IsRequired();

            builder.Property(e => e.City)
                   .HasColumnName("CITY")
                   .IsRequired();

            builder.Property(e => e.PostalCode)
                   .HasColumnName("POSTALCODE")
                   .IsRequired();

            builder.Property(e => e.Country)
                   .HasColumnName("COUNTRY")
                   .IsRequired();

            builder.Property(e => e.Lng)
                   .HasColumnName("LNG")
                   .IsRequired();

            builder.Property(e => e.Lat)
                   .HasColumnName("LAT")
                   .IsRequired();

            builder.Property(e => e.AddressTypeId)
                   .HasColumnName("ADDRESS_TYPE_ID")
                   .IsRequired();

            builder.HasOne(e => e.Customer)
                   .WithMany(e => e.CustomerAddress)
                   .HasForeignKey(e => e.CustomerId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
