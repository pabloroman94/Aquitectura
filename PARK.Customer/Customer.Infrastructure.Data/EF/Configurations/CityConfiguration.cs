using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class CityConfiguration : BaseCrudEntityConfiguration<City, Guid>
    {
        public override void Configure(EntityTypeBuilder<City> builder)
        {
            base.Configure("City", builder);

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(e => e.CityName)
                   .HasColumnName("CityName")
                   .IsRequired();

            builder.Property(e => e.PostalCode)
                   .HasColumnName("PostalCode")
                   .IsRequired();

            builder.Property(e => e.ProvinceID)
                   .HasColumnName("ProvinceID")
                   .IsRequired();

            //builder.HasOne(c => c.Province)
            //  .WithMany(p => p.Cities)
            //  .HasForeignKey(c => c.ProvinceID)
            //  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}