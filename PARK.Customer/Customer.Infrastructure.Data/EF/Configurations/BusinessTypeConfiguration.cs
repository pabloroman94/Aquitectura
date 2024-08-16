using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class BusinessTypeConfiguration : BaseCrudEntityConfiguration<BusinessType, Guid>
    {
        public override void Configure(EntityTypeBuilder<BusinessType> builder)
        {
            base.Configure("BusinessType", builder);

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

       
            builder.Property(e => e.TypeName)
                   .HasColumnName("TypeName")
                   .IsRequired();
            
            builder.Property(e => e.CategoryID)
                   .HasColumnName("CategoryID")
                   .IsRequired();



            //builder.HasOne(bt => bt.Category)
            //  .WithMany(c => c.BusinessTypes)
            //  .HasForeignKey(bt => bt.CategoryID);

            //builder.HasMany(bt => bt.CompanyBusinessTypes)
            //       .WithOne(cbt => cbt.BusinessType)
            //       .HasForeignKey(cbt => cbt.BusinessTypeID);
        }
    }
}
