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

            // Configuración de la clave primaria
            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            // Configuración de la propiedad CityName
            builder.Property(e => e.CityName)
                   .HasColumnName("CityName")
                   .IsRequired()
                   .HasMaxLength(255); // Establece un límite de longitud si es necesario

            // Configuración de la propiedad PostalCode
            builder.Property(e => e.PostalCode)
                   .HasColumnName("PostalCode")
                   .IsRequired()
                   .HasMaxLength(10); // Establece un límite de longitud si es necesario

            // Configuración de la relación con Province
            builder.Property(e => e.ProvinceID)
                   .HasColumnName("ProvinceID")
                   .IsRequired();

            // Relaciones
            builder.HasOne(c => c.Province)
                   .WithMany(p => p.Cities)
                   .HasForeignKey(c => c.ProvinceID)
                   .OnDelete(DeleteBehavior.Cascade);  // Si se elimina una provincia, se eliminan sus ciudades asociadas
        }
    }
}