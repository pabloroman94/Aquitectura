using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class UserEmailConfiguration : BaseCrudEntityConfiguration<UserEmail, Guid>
    {
        public override void Configure(EntityTypeBuilder<UserEmail> builder)
        {
            base.Configure("USER_EMAIL", builder);

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(e => e.Email)
                   .HasColumnName("EMAIL")
                   .IsRequired();

            builder.Property(e => e.Preferred)
                   .HasColumnName("PREFERRED")
                   .IsRequired();

            builder.Property(e => e.UserID)
                   .HasColumnName("USER_ID")
                   .IsRequired();

            //builder.HasOne(e => e.User)
            //       .WithMany(u => u.UserEmails)
            //       .HasForeignKey(e => e.UserID)
            //       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
