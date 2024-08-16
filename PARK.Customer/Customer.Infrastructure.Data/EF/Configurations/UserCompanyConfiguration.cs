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
            base.Configure("USER_COMPANY", builder);  // Cambiado el nombre de la tabla base

            // Configuración del ID
            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            // Configuración del CompanyName
            builder.Property(e => e.CompanyName)
                   .HasColumnName("COMPANYNAME")
                   .IsRequired();

            

            // Configuración del UserID (clave foránea)
            //builder.Property(e => e.UserID)
            //       .HasColumnName("USER_ID")
            //       .IsRequired();

            // Configuración de la relación con la entidad User
            //builder.HasOne(e => e.User)
            //       .WithMany(u => u.UserCompanies)
            //       .HasForeignKey(e => e.UserID)
            //       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
