using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class PersonProfessionConfiguration : BaseCrudEntityConfiguration<PersonProfession, Guid>
    {
        public override void Configure(EntityTypeBuilder<PersonProfession> builder)
        {
            base.Configure("PERSONPROFESSION", builder);

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(e => e.PersonID)
                   .HasColumnName("PersonID")
                   .IsRequired();

            builder.Property(e => e.ProfessionID)
                   .HasColumnName("ProfessionID")
                   .IsRequired();

            // Relación con Person
            builder.HasOne(pp => pp.UserPerson)
                   .WithMany(p => p.PersonProfessions)
                   .HasForeignKey(pp => pp.PersonID)
                   .OnDelete(DeleteBehavior.Cascade);

            // Relación con Profession
            builder.HasOne(pp => pp.Profession)
                   .WithMany(p => p.PersonProfessions)
                   .HasForeignKey(pp => pp.ProfessionID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
