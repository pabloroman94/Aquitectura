using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class UserCategoryConfiguration : BaseCrudEntityConfiguration<UserCategory, Guid>
    {
        public override void Configure(EntityTypeBuilder<UserCategory> builder)
        {
            base.Configure("CATEGORY", builder);

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(e => e.CategoryName)
                   .HasColumnName("CATEGORY_NAME")
                   .IsRequired();


            // Configuración de las relaciones
            builder.HasMany(c => c.Professions)
                       .WithOne(p => p.Category)
                       .HasForeignKey(p => p.CategoryID)
                       .OnDelete(DeleteBehavior.Cascade);  // Eliminación en cascada
        }
    }
}
