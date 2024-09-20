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
        
            builder.Property(e => e.FirstName)
                   .HasColumnName("FIRSTNAME")
                   .HasMaxLength(255)
                   .IsUnicode(false)
                   .IsRequired();

            builder.Property(e => e.LastName)
                   .HasColumnName("LASTNAME")
                   .HasMaxLength(255)
                   .IsUnicode(false)
                   .IsRequired();

            builder.Property(e => e.Birthdate)
                   .HasColumnName("BIRTHDATE")
                   .HasColumnType("date")
                   .IsRequired();

            builder.Property(e => e.Gender)
                   .HasColumnName("GENDER")
                   .HasMaxLength(50)
                   .IsUnicode(false)
                   .IsRequired();

            builder.Ignore(e => e.Tags);
            //builder.Ignore(e => e.AddressProfile);



            // Configuración de la clave foránea hacia la tabla User
            builder.HasOne<User>()
                   .WithOne()  // Relación uno a uno
                   .HasForeignKey<UserPerson>(e => e.Id)  // FK hacia User
                   .OnDelete(DeleteBehavior.Cascade);  // Eliminación en cascada
        }
    }
}