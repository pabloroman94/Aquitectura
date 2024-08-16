using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class ProvinceConfiguration : BaseCrudEntityConfiguration<Province, Guid>
    {
        public override void Configure(EntityTypeBuilder<Province> builder)
        {
            base.Configure("Province", builder);

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(e => e.CountryID)
                   .HasColumnName("CountryID")
                   .IsRequired();

            builder.Property(e => e.ProvinceName)
                   .HasColumnName("ProvinceName")
                   .IsRequired();
            //builder.HasOne(p => p.Country)
            //               .WithMany(c => c.Provinces)
            //               .HasForeignKey(p => p.CountryID)
            //               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
