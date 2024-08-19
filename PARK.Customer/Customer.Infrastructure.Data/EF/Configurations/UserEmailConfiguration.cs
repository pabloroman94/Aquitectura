using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class UserMailConfiguration : BaseCrudEntityConfiguration<Coordinates, Guid>
    {
        public override void Configure(EntityTypeBuilder<Coordinates> builder)
        {
            base.Configure("Coordinates", builder);

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            //builder.Property(e => e.UserAddressID)
            //       .HasColumnName("UserAddressID")
            //       .IsRequired();

            builder.Property(e => e.Lng)
                   .HasColumnName("Lng")
                   .IsRequired();

            builder.Property(e => e.Lat)
                   .HasColumnName("Lat")
                   .IsRequired();
              builder.Property(e => e.GoogleMapsURL)
                   .HasColumnName("GoogleMapsURL")
                   .IsRequired();

            //builder.HasOne(c => c.UserAddress)
            //   .WithOne(ua => ua.Coordinates)
            //   .HasForeignKey<Coordinates>(c => c.UserAddressID)
            //   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}