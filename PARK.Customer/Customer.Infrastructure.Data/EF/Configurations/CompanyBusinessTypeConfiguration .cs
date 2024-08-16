using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class CompanyBusinessTypeConfiguration : BaseCrudEntityConfiguration<CompanyBusinessType, Guid>
    {
        public override void Configure(EntityTypeBuilder<CompanyBusinessType> builder)
        {
            base.Configure("CompanyBusinessType", builder);

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            

            builder.Property(e => e.CompanyID)
                   .HasColumnName("CompanyID")
                   .IsRequired();
            
            builder.Property(e => e.BusinessTypeID)
                   .HasColumnName("BusinessTypeID")
                   .IsRequired();

            //builder.HasOne(cbt => cbt.Company)
            //   .WithMany(c => c.CompanyBusinessTypes)
            //   .HasForeignKey(cbt => cbt.CompanyID);

            //builder.HasOne(cbt => cbt.BusinessType)
            //       .WithMany(bt => bt.CompanyBusinessTypes)
            //       .HasForeignKey(cbt => cbt.BusinessTypeID);
        }
    }
}
