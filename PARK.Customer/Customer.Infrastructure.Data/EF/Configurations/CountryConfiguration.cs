using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class CountryConfiguration : BaseCrudEntityConfiguration<Country, Guid>
    {
        public override void Configure(EntityTypeBuilder<Country> builder)
        {
            base.Configure("COUNTRY", builder); // Asigna el nombre de la tabla

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(e => e.CountryName)
                   .HasColumnName("COUNTRYNAME")
                   .IsRequired()
                   .HasMaxLength(255); // Limita la longitud del nombre del país

            // Configuración de la relación con Provinces
            builder.HasMany(e => e.Provinces)
                   .WithOne(p => p.Country)
                   .HasForeignKey(p => p.CountryID)
                   .OnDelete(DeleteBehavior.Cascade); // Si se elimina un país, también se eliminan sus provincias
        }
    }
}
