using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class CompanyConfiguration : BaseCrudEntityConfiguration<Company, Guid>
    {
        public override void Configure(EntityTypeBuilder<Company> builder)
        {
            base.Configure("PARK_COMPANY", builder);

            builder.Property(e => e.CompanyName)
                   .HasColumnName("COMPANY_NAME")
                   .IsRequired();

            builder.Property(e => e.CurrentName)
                   .HasColumnName("CURRENT_NAME")
                   .IsRequired();

        }
    }
}
