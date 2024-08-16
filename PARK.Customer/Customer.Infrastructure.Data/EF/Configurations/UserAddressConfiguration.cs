using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class UserAddressConfiguration : BaseCrudEntityConfiguration<UserAddress, Guid>
    {
        public override void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            base.Configure("UserAddress", builder);

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(e => e.UserID)
                   .HasColumnName("UserID")
                   .IsRequired();
            builder.Property(e => e.StreetID)
                   .HasColumnName("StreetID")
                   .IsRequired();
            builder.Property(e => e.CityID)
                   .HasColumnName("CityID")
                   .IsRequired();
            builder.Property(e => e.CountryID)
                   .HasColumnName("CountryID")
                   .IsRequired();
            builder.Property(e => e.CoordinateID)
                   .HasColumnName("CoordinateID")
                   .IsRequired();


            //agregame las Configuración de las relaciones
            //builder.HasOne(e => e.User)
            //      .WithMany(u => u.UserAddresses)
            //      .HasForeignKey(e => e.UserID)
            //      .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(e => e.Street)
            //       .WithMany(s => s.UserAddresses)
            //       .HasForeignKey(e => e.StreetID)
            //       .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(e => e.City)
            //       .WithMany(c => c.UserAddresses)
            //       .HasForeignKey(e => e.CityID)
            //       .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(e => e.Province)
            //       .WithMany(p => p.UserAddresses)
            //       .HasForeignKey(e => e.ProvinceID)
            //       .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(e => e.Country)
            //       .WithMany(c => c.UserAddresses)
            //       .HasForeignKey(e => e.CountryID)
            //       .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(e => e.Coordinates)
            //       .WithOne(c => c.UserAddress)
            //       .HasForeignKey<UserAddress>(e => e.CoordinateID)
            //       .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

