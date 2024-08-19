using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class CompanyTagConfiguration : BaseCrudEntityConfiguration<CompanyTag, Guid>
    {
        public override void Configure(EntityTypeBuilder<CompanyTag> builder)
        {
            base.Configure("CompanyTag", builder);

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(ct => ct.CompanyID)
              .HasColumnName("CompanyID")
              .IsRequired();

            builder.Property(ct => ct.TagID)
                   .HasColumnName("TagID")
                   .IsRequired();

            // Relaciones
            builder.HasOne(ct => ct.Company)
                   .WithMany(c => c.CompanyTags)
                   .HasForeignKey(ct => ct.CompanyID)
                   .OnDelete(DeleteBehavior.Cascade);  // Eliminación en cascada

            builder.HasOne(ct => ct.Tag)
                   .WithMany(t => t.CompanyTags)
                   .HasForeignKey(ct => ct.TagID)
                   .OnDelete(DeleteBehavior.Cascade);  // Eliminación en cascada
        }
    }
}
