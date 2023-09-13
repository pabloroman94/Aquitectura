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
    public class PhoneConfiguration : BaseCrudEntityConfiguration<Phone, Guid>
    {
        public override void Configure(EntityTypeBuilder<Phone> builder)
        {
            {
                base.Configure("PARK_CUSTOMER_PHONE", builder);

                builder.Property(e => e.Id)
                       .HasColumnName("ID")
                       .IsRequired();

                builder.Property(e => e.PhoneNumber)
                       .HasColumnName("PHONE_NUMBER")
                                    .IsRequired();

                builder.Property(e => e.CustomerId)
                       .HasColumnName("CUSTOMER_ID")
                       .IsRequired();

                builder.Property(e => e.ContactTypeId)
                       .HasColumnName("CONTACT_TYPE_ID");

                builder.HasOne(e => e.Customer)
                  .WithMany(e => e.CustomerPhones)
                  .HasForeignKey(e => e.CustomerId)
                  .OnDelete(DeleteBehavior.Cascade);

            }
        }
    }
}

