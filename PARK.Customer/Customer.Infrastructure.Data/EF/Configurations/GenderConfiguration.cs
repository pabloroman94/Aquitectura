using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.EF.Configurations
{
    public class GenderConfiguration : BaseCrudEntityConfiguration<Gender, Guid>
    {
        public override void Configure(EntityTypeBuilder<Gender> builder)
        {

            base.Configure("PARK_GENDER", builder);

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();
            builder.Property(e => e.Description)
                   .HasColumnName("DESCRIPTION")
                   .IsRequired();

            builder.HasMany(e => e.Persons)
              .WithOne(e => e.Gender)
              .HasForeignKey(e => e.Gender_id)
              .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
