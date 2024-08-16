using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class UseConfiguration : BaseCrudEntityConfiguration<User, Guid>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure("USER", builder);

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(e => e.Username)
                   .HasColumnName("LOGINNAME")
                   .IsRequired();

            builder.Property(e => e.ProfileDescription)
                   .HasColumnName("PROFILEDESCRIPTION")
                   .IsRequired();

         

            //builder.HasOne(e => e.User)
            //       .WithMany(u => u.UserEmails)
            //       .HasForeignKey(e => e.UserID)
            //       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
