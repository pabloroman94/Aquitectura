using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class UserPersonConfiguration : BaseCrudEntityConfiguration<UserPerson, Guid>
    {
        public override void Configure(EntityTypeBuilder<UserPerson> builder)
        {
            base.Configure("PERSON", builder);

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(e => e.FirstName)
                   .HasColumnName("FIRSTNAME")
                   .IsRequired();

            builder.Property(e => e.LastName)
                   .HasColumnName("LASTNAME")
                   .IsRequired();

            builder.Property(e => e.Birthdate)
                   .HasColumnName("BIRTHDATE")
                   .IsRequired();
            
            builder.Property(e => e.Gender)
                   .HasColumnName("GENDER")
                   .IsRequired();
            
            builder.Property(e => e.ProfessionalTypeID)
                   .HasColumnName("PROFESSIONALTYPEID")
                   .IsRequired();

            //builder.HasOne(e => e.User)
            //       .WithMany(u => u.UserEmails)
            //       .HasForeignKey(e => e.UserID)
            //       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}