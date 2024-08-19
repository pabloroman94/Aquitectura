using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class NetworkTypeConfiguration : BaseCrudEntityConfiguration<NetworkType, Guid>
    {
        public override void Configure(EntityTypeBuilder<NetworkType> builder)
        {
            base.Configure("NetworkType", builder);

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(e => e.Description)
                .HasColumnName("Description")
                .IsRequired()
                .HasMaxLength(255);  // Ejemplo para establecer la longitud máxima

            builder.Property(e => e.IconURL)
                   .HasColumnName("IconURL")
                   .IsRequired()
                   .HasMaxLength(255);

            // Relaciones
            builder.HasMany(e => e.Networks)
                   .WithOne(n => n.NetworkType)
                   .HasForeignKey(n => n.NetworkTypeID)
                   .OnDelete(DeleteBehavior.Cascade);

        }
    }
}