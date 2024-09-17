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
            
            builder.Property(e => e.ProfileImage)
                   .HasColumnName("PROFILEIMAGE")
                   .IsRequired();

            builder.Property(e => e.ProfileDescription)
                   .HasColumnName("PROFILEDESCRIPTION")
                   .IsRequired();


            // Relaciones
            builder.HasMany(e => e.Networks)  // Asumiendo que tienes una colección de Networks en User
                  .WithOne(n => n.User)
                  .HasForeignKey(n => n.UserID)
                  .OnDelete(DeleteBehavior.Cascade);  // Si se elimina un User, se eliminan sus Networks

            // Relación con UserAddresses
            builder.HasMany(e => e.UserAddresses)  // Asumiendo que tienes una colección de UserAddresses en User
                   .WithOne(ua => ua.User)
                   .HasForeignKey(ua => ua.UserID)
                   .OnDelete(DeleteBehavior.Cascade);  // Si se elimina un User, se eliminan sus direcciones
        }
    }
}
