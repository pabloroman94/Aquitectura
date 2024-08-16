using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class StreetConfiguration : BaseCrudEntityConfiguration<Street, Guid>
    {
        public override void Configure(EntityTypeBuilder<Street> builder)
        {
            base.Configure("Street", builder);

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(e => e.StreetName)
                   .HasColumnName("StreetName")
                   .IsRequired();

            builder.Property(e => e.StreetNumber)
                   .HasColumnName("StreetNumber")
                   .IsRequired();
            builder.Property(e => e.Floor)
                   .HasColumnName("Floor")
                   .IsRequired();
            builder.Property(e => e.CityID)
                   .HasColumnName("CityID")
                   .IsRequired();

            
            
            
            
            
            
            //builder.Property(s => s.StreetName)
            //  .HasMaxLength(255)
            //  .IsRequired();

            //builder.Property(s => s.StreetNumber)
            //       .HasMaxLength(10);

            //builder.Property(s => s.Floor)
            //       .HasMaxLength(10);

            //builder.HasOne(s => s.City)
            //       .WithMany(c => c.Streets)
            //       .HasForeignKey(s => s.CityID)
            //       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
