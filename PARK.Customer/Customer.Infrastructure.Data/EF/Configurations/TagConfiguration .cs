using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class TagConfiguration : BaseCrudEntityConfiguration<Tag, Guid>
    {
        public override void Configure(EntityTypeBuilder<Tag> builder)
        {
            base.Configure("TAG", builder);

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(t => t.TagName)
                .HasColumnName("TagName")
                .IsRequired()
                .HasMaxLength(255);

            // Relaciones
            builder.HasMany(t => t.PersonTags)
                   .WithOne(pt => pt.Tag)
                   .HasForeignKey(pt => pt.TagID)
                   .OnDelete(DeleteBehavior.Cascade);// Eliminación en cascada si se elimina la etiqueta

            builder.HasMany(t => t.CompanyTags)
                   .WithOne(pt => pt.Tag)
                   .HasForeignKey(pt => pt.TagID)
                   .OnDelete(DeleteBehavior.Cascade);// Eliminación en cascada si se elimina la etiqueta
        }
    }
}