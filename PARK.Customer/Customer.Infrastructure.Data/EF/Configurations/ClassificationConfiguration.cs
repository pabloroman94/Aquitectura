using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class ClassificationConfiguration : BaseCrudEntityConfiguration<Classification, Guid>
    {
        public override void Configure(EntityTypeBuilder<Classification> builder)
        {
            base.Configure("Classification", builder);

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(e => e.CompanyID)
               .HasColumnName("COMPANYID")
               .IsRequired();

            builder.Property(e => e.CategoryID)
                   .HasColumnName("CATEGORYID")
                   .IsRequired(false);  // Es opcional

            builder.Property(e => e.SubCategoryID)
                   .HasColumnName("SUBCATEGORYID")
                   .IsRequired(false);  // Es opcional

            //builder.Property(e => e.BusinessTypeID)
            //       .HasColumnName("BusinessTypeID")
            //       .IsRequired(false);

            // Relación con Company (obligatoria)
            builder.HasOne(e => e.Company)
                   .WithMany(c => c.Classifications)
                   .HasForeignKey(e => e.CompanyID)
                   .OnDelete(DeleteBehavior.Cascade);  // Si se elimina una compañía, también se eliminan sus clasificaciones

            // Relación con Category (opcional)
            builder.HasOne(e => e.Category)
                   .WithMany()
                   .HasForeignKey(e => e.CategoryID)
                   .OnDelete(DeleteBehavior.SetNull);  // Si se elimina una categoría, la clasificación se mantiene pero la referencia se establece en null

            // Relación con SubCategory (opcional)
            builder.HasOne(e => e.SubCategory)
                   .WithMany()
                   .HasForeignKey(e => e.SubCategoryID)
                   .OnDelete(DeleteBehavior.SetNull);  // Si se elimina una subcategoría, la clasificación se mantiene pero la referencia se establece en null

            // Relación con BusinessType (opcional)
            //builder.HasOne(e => e.BusinessType)
            //       .WithMany()
            //       .HasForeignKey(e => e.BusinessTypeID)
            //       .OnDelete(DeleteBehavior.SetNull);  // Si se elimina un tipo de negocio, la clasificación se mantiene pero la referencia se establece en null
        }
    }
}