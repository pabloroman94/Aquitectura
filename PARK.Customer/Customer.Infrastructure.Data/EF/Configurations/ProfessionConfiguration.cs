using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class ProfessionConfiguration : BaseCrudEntityConfiguration<Profession, Guid>
    {
        public override void Configure(EntityTypeBuilder<Profession> builder)
        {
            base.Configure("PROFESSION", builder);

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();
            
            builder.Property(e => e.ProfessionName)
                          .HasColumnName("PROFESSIONNAME")
                          .IsRequired()
                          .HasMaxLength(255);

            builder.Property(e => e.CategoryID)
                   .HasColumnName("CATEGORYID")
                   .IsRequired();

            // Relación con Category
            builder.HasOne(e => e.Category)
                   .WithMany()
                   .HasForeignKey(e => e.CategoryID)
                   .OnDelete(DeleteBehavior.Cascade);

            // Relación con PersonProfession
            builder.HasMany(e => e.PersonProfessions)
                   .WithOne(pp => pp.Profession)
                   .HasForeignKey(pp => pp.ProfessionID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
