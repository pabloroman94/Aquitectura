using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class ProfessionConfiguration : BaseCrudEntityConfiguration<Profession, Guid>
    {
        public override void Configure(EntityTypeBuilder<Profession> builder)
        {
            base.Configure("PROFESSION", builder);

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();
            
            builder.Property(e => e.ProfessionName)
                          .HasColumnName("PROFESSIONNAME")
                          .IsRequired()
                          .HasMaxLength(255);

            builder.Property(e => e.CategoryID)
                   .HasColumnName("CATEGORYID")
                   .IsRequired();

            //builder.HasOne(e => e.User)
            //       .WithMany(u => u.UserEmails)
            //       .HasForeignKey(e => e.UserID)
            //       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
