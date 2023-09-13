using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class PersonConfiguration : BaseCrudEntityConfiguration<Person, Guid>
    {
        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            {
                base.Configure("PARK_PERSON", builder);


                builder.Property(e => e.Name)
                       .HasColumnName("NAME")
                       .IsRequired();

                builder.Property(e => e.Lastname)
                       .HasColumnName("LASTNAME")
                       .IsRequired();
                builder.Property(e => e.Gender_id)
                       .HasColumnName("GENDER_ID");

                builder.Property(e => e.Birthday)
                       .HasColumnName("BIRTHDAY");

                builder.HasOne(e => e.Gender)
                   .WithMany(e => e.Persons)
                   .HasForeignKey(e => e.Gender_id);

            }
        }

    }
}
