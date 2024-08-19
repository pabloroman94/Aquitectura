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

            // Configuración de la clave primaria
            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            // Configuración de la relación con Country
            builder.Property(e => e.CountryID)
                   .HasColumnName("CountryID")
                   .IsRequired();

            // Configuración de la propiedad ProvinceName
            builder.Property(e => e.ProvinceName)
                   .HasColumnName("ProvinceName")
                   .IsRequired()
                   .HasMaxLength(255);  // Establece un límite de longitud si es necesario

            // Relaciones
            builder.HasOne(p => p.Country)
                   .WithMany(c => c.Provinces)
                   .HasForeignKey(p => p.CountryID)
                   .OnDelete(DeleteBehavior.Cascade);  // Si se elimina un país, se eliminan sus provincias asociadas
        }
    }
}
