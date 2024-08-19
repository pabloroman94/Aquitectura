using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class BusinessTypeConfiguration : BaseCrudEntityConfiguration<BusinessType, Guid>
    {
        public override void Configure(EntityTypeBuilder<BusinessType> builder)
        {
            base.Configure("BusinessType", builder);

            builder.Property(e => e.TypeName)
            .HasColumnName("TypeName")
            .IsRequired()
            .HasMaxLength(255); // Limitar la longitud del nombre para mayor control

            builder.Property(e => e.SubCategoryID)
                   .HasColumnName("SubCategoryID")
                   .IsRequired();

            // Configuración de relaciones
            builder.HasOne(e => e.SubCategory)
                   .WithMany(sc => sc.BusinessTypes)
                   .HasForeignKey(e => e.SubCategoryID)
                   .OnDelete(DeleteBehavior.Cascade);

            // Configurar la relación con la tabla de clasificación si es necesario
            //builder.HasMany(e => e.Classifications)
            //       .WithOne(c => c.BusinessType)
            //       .HasForeignKey(c => c.BusinessTypeID)
            //       .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
