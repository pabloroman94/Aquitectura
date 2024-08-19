using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class SubCategoryConfiguration : BaseCrudEntityConfiguration<SubCategory, Guid>
    {
        public override void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            base.Configure("SubCategory", builder);

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();
           
            builder.Property(e => e.SubCategoryName)
                       .HasColumnName("SubCategoryName")
                       .IsRequired()
                       .HasMaxLength(255); // Limitar la longitud del nombre de la subcategoría

            builder.Property(e => e.CategoryID)
                   .HasColumnName("CategoryID")
                   .IsRequired();

            // Configuración de relaciones
            builder.HasOne(e => e.Category)
                   .WithMany(c => c.SubCategories)
                   .HasForeignKey(e => e.CategoryID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.BusinessTypes)
                   .WithOne(bt => bt.SubCategory)
                   .HasForeignKey(bt => bt.SubCategoryID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}