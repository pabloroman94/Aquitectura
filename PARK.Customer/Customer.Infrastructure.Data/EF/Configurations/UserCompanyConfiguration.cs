using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class UserCompanyConfiguration : BaseCrudEntityConfiguration<UserCompany, Guid>
    {
        public override void Configure(EntityTypeBuilder<UserCompany> builder)
        {
            base.Configure("COMPANY", builder);  // Cambiado el nombre de la tabla base


            // Configuración del CompanyName
            builder.Property(e => e.CompanyName)
                   .HasColumnName("COMPANYNAME")
                   .IsRequired()
                   .HasMaxLength(255); // Limitar la longitud del nombre de la compañía

            // Relación uno a uno con User
            builder.HasOne<User>()
                   .WithOne()
                   .HasForeignKey<UserCompany>(e => e.Id)  // FK hacia User
                   .OnDelete(DeleteBehavior.Cascade);  // Eliminación en cascada
            
        }
    }
}
