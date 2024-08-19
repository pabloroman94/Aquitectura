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

            //builder.HasOne(e => e.Company)
            //.WithMany(c => c.CompanyTags) // Asegúrate de que esta relación esté en UserCompany
            //.HasForeignKey(e => e.CompanyID)
            //.OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(e => e.BusinessType)
            //       .WithMany(bt => bt.CompanyBusinessTypes) // Asegúrate de que esta relación esté en BusinessType
            //       .HasForeignKey(e => e.BusinessTypeID)
            //       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
