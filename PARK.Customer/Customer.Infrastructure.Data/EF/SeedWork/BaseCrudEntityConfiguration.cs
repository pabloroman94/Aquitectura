using Domain.Entities;
using Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF
{
    public abstract class BaseCrudEntityConfiguration<TBaseCrudEntity, TPrimaryKey> : IEntityTypeConfiguration<TBaseCrudEntity>
        where TBaseCrudEntity : BaseCrudEntity<TPrimaryKey>
    {
        protected void Configure(string tablename, EntityTypeBuilder<TBaseCrudEntity> builder)
        {
            builder.ToTable(tablename);

            builder.Property(e => e.FInsert)
                .HasColumnName("FINSERT")
                .HasColumnType("datetime");

            builder.Property(e => e.UserName)
                .HasColumnName("USERNAME")
                .HasConversion(c => c.ToUpper(), c => c)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Version)
                .HasColumnName("VERSION");

            builder.Property(e => e.FUpdate)
                .HasColumnName("FUPDATE")
                .HasColumnType("datetime");

            builder.Property(e => e.UserNameUpdate)
                .HasColumnName("USERNAMEUPDATE")
                .HasConversion(c => c.ToUpper(), c => c)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Code)
                .HasColumnName("CODE")
                .HasConversion(c => c.ToUpper(), c => c)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsRequired();

            // Cambio realizado: Ajuste de la configuración de la propiedad 'Active' para manejar correctamente los valores por defecto de 'BoolCharEnum'
            builder.Property(e => e.Active)
                .HasColumnName("ACTIVE")
                .HasMaxLength(1)
                .IsRequired()
                .HasDefaultValue(BoolCharEnum.N)
                .HasConversion(
                    v => v.ToString(),
                    v => (BoolCharEnum)Enum.Parse(typeof(BoolCharEnum), v))
                .IsUnicode(false);
        }

        public abstract void Configure(EntityTypeBuilder<TBaseCrudEntity> builder);
    }
}
