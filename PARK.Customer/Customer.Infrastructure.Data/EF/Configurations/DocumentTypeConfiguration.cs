using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class DocumentTypeConfiguration : BaseCrudEntityConfiguration<DocumentType, Guid>
    {
        public override void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            base.Configure("PARK_DOCUMENT_TYPE", builder);


            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(e => e.Description)
                   .HasColumnName("DESCRIPTION")
                   .IsRequired();

            builder.Property(e => e.CustomerType)
                   .HasColumnName("CUSTOMER_TYPE")
                   .IsRequired();


            builder.HasMany(e => e.Customers)
                  .WithOne(e => e.DocumentType)
                  .HasForeignKey(e => e.DocumentTypeId)
                  .OnDelete(DeleteBehavior.Cascade);

            

        }
    }
}