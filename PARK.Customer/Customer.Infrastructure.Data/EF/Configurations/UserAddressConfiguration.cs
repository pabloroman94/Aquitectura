using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class UserAddressConfiguration : BaseCrudEntityConfiguration<UserAddress, Guid>
    {
        public override void Configure(EntityTypeBuilder<UserAddress> builder)
        {
            base.Configure("UserAddress", builder);

            // Configuración de la clave primaria
            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            // Configuración de las propiedades
            builder.Property(e => e.UserID)
                   .HasColumnName("UserID")
                   .IsRequired();

            builder.Property(e => e.StreetID)
                   .HasColumnName("StreetID")
                   .IsRequired();

            builder.Property(e => e.CoordinatesID)
                   .HasColumnName("CoordinatesID")
                   .IsRequired(false);  // Opcional

            // Configuración de las relaciones

            // Relación con User
            builder.HasOne(e => e.User)
                   .WithMany(u => u.UserAddresses)
                   .HasForeignKey(e => e.UserID)
                   .OnDelete(DeleteBehavior.Cascade);  // Elimina las direcciones si se elimina el usuario

            // Relación con Street
            builder.HasOne(e => e.Street)
                   .WithMany(s => s.UserAddresses)
                   .HasForeignKey(e => e.StreetID)
                   .OnDelete(DeleteBehavior.Cascade);  // Elimina las direcciones si se elimina la calle

            // Relación con Coordinates (opcional)
            builder.HasOne(e => e.Coordinates)
                   .WithOne(c => c.UserAddress)
                   .HasForeignKey<UserAddress>(e => e.CoordinatesID)
                   .OnDelete(DeleteBehavior.Cascade);  // Elimina las coordenadas si se elimina la dirección
        }
    }
}
