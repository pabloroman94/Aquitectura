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
    public class CustomerConfiguration : BaseCrudEntityConfiguration<Customer, Guid>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            {
                base.Configure("PARK_CUSTOMER", builder);

                builder.HasKey(e => e.Id);
                builder.Property(e => e.Id)
                       .HasColumnName("ID")
                       .ValueGeneratedOnAdd()
                       .IsRequired();

                builder.Property(e => e.DocumentTypeId)
                       .HasColumnName("DOCUMENT_TYPE_ID")
                       .IsRequired();
                
                builder.Property(e => e.DocumentNumber)
                       .HasColumnName("DOCUMENT_NUMBER")
                       .IsRequired();
                builder.Property(e => e.InvoiceType)
                       .HasColumnName("INVOICE_TYPE");

                builder.Property(e => e.ComunityId)
                       .HasColumnName("COMUNITY_ID");

                builder.HasMany(e => e.CustomerPhotos)
                    .WithOne(e => e.Customer)
                    .HasForeignKey(e=>e.CustomerId);

                builder.HasMany(e => e.CustomerMails)
                   .WithOne(e => e.Customer)
                   .HasForeignKey(e => e.CustomerId);
                
                builder.HasMany(e => e.CustomerPhones)
                   .WithOne(e => e.Customer)
                   .HasForeignKey(e => e.CustomerId);
                
                builder.HasMany(e => e.CustomerAddress)
                   .WithOne(e => e.Customer)
                   .HasForeignKey(e => e.CustomerId);
                
                builder.HasOne(e => e.DocumentType)
                   .WithMany(e => e.Customers)
                   .HasForeignKey(e => e.DocumentTypeId);


                builder.HasMany(e => e.CustomerPersonContacts)
                   .WithOne(e => e.Customer)
                   .HasForeignKey(e => e.CustomerId);
            }
        }
    }
}
