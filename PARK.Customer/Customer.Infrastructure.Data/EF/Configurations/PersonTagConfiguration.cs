using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class PersonTagConfiguration : BaseCrudEntityConfiguration<PersonTag, Guid>
    {
        public override void Configure(EntityTypeBuilder<PersonTag> builder)
        {
            base.Configure("PersonTag", builder);

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(pt => pt.PersonID)
              .HasColumnName("PersonID")
              .IsRequired();

            builder.Property(pt => pt.TagID)
                   .HasColumnName("TagID")
                   .IsRequired();


            //// Relaciones
            builder.HasOne(pt => pt.Person)
          .WithMany(p => p.PersonTags)
          .HasForeignKey(pt => pt.PersonID)
          .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pt => pt.Tag)
                   .WithMany(t => t.PersonTags)
                   .HasForeignKey(pt => pt.TagID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
