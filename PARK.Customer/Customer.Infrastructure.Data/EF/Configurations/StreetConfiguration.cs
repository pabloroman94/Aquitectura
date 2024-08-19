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
            // Configuración de la clave primaria
            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            // Configuración de la propiedad StreetName
            builder.Property(e => e.StreetName)
                   .HasColumnName("StreetName")
                   .IsRequired()
                   .HasMaxLength(255); // Limitar la longitud del nombre de la calle

            // Configuración de la propiedad StreetNumber
            builder.Property(e => e.StreetNumber)
                   .HasColumnName("StreetNumber")
                   .IsRequired()
                   .HasMaxLength(10); // Limitar la longitud del número de la calle

            // Configuración de la propiedad Floor
            builder.Property(e => e.Floor)
                   .HasColumnName("Floor")
                   .HasMaxLength(10); // Limitar la longitud del número de piso

            // Configuración de la relación con City
            builder.Property(e => e.CityID)
                   .HasColumnName("CityID")
                   .IsRequired();

            // Relaciones
            builder.HasOne(s => s.City)
                   .WithMany(c => c.Streets)
                   .HasForeignKey(s => s.CityID)
                   .OnDelete(DeleteBehavior.Cascade); // Si se elimina una ciudad, se eliminan sus calles asociadas
        }
    }
}
