using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class CoordinatesConfiguration : BaseCrudEntityConfiguration<Coordinates, Guid>
    {
        public override void Configure(EntityTypeBuilder<Coordinates> builder)
        {
            base.Configure("Coordinates", builder);

            // Configuración de la clave primaria
            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            // Configuración de la propiedad Lng (Longitud)
            builder.Property(e => e.Lng)
                   .HasColumnName("Lng")
                   .IsRequired()
                   .HasColumnType("decimal(9,6)"); // Precisión para coordenadas geográficas

            // Configuración de la propiedad Lat (Latitud)
            builder.Property(e => e.Lat)
                   .HasColumnName("Lat")
                   .IsRequired()
                   .HasColumnType("decimal(9,6)"); // Precisión para coordenadas geográficas

            // Configuración de la propiedad GoogleMapsURL
            builder.Property(e => e.GoogleMapsURL)
                   .HasColumnName("GoogleMapsURL")
                   .IsRequired()
                   .HasMaxLength(255); // Limitar la longitud del URL

            // Configuración de la relación con UserAddress
            builder.HasOne(e => e.UserAddress)
                   .WithOne(ua => ua.Coordinates)
                   .HasForeignKey<Coordinates>(e => e.Id)
                   .OnDelete(DeleteBehavior.Cascade); // Eliminar las coordenadas si se elimina la dirección del usuario
        }
    }
}
