using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class MailConfiguration : BaseCrudEntityConfiguration<Mail, Guid>
    {
        public override void Configure(EntityTypeBuilder<Mail> builder)
        {
                base.Configure("PARK_CUSTOMER_MAIL", builder);

                builder.Property(e => e.Id)
                       .HasColumnName("ID")
                       .IsRequired();
            
                builder.Property(e => e.CustomerId)
                           .HasColumnName("CUSTOMER_ID")
                           .IsRequired();

                builder.Property(e => e.Preferred)
                       .HasColumnName("PREFERRED")
                       .IsRequired();

                builder.Property(e => e.Email)
                       .HasColumnName("EMAIL")
                       .IsRequired();

                builder.Property(e => e.ContactTypeId)
                       .HasColumnName("CONTACT_TYPE_ID");
                          
                builder.HasOne(e => e.Customer)
                  .WithMany(e => e.CustomerMails)
                  .HasForeignKey(e => e.CustomerId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
