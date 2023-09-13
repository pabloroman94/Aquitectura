using Domain.Entities;
using Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF
{

    public abstract class BaseStampEntityConfiguration<TBaseStampEntity, TPrimaryKey> : IEntityTypeConfiguration<TBaseStampEntity>
    where TBaseStampEntity : BaseStampEntity<TPrimaryKey>
    {
        protected void Configure(string tablename, EntityTypeBuilder<TBaseStampEntity> builder)
        {
            builder.ToTable(tablename);
            //     builder.HasKey(e => e.Id);
            //     builder.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd().IsRequired();
            builder.Property(e => e.FInsert).HasColumnName("FINSERT").HasColumnType("datetime");
            builder.Property(e => e.UserName).HasColumnName("USERNAME").HasConversion(c => c.ToUpper(), c => c).HasMaxLength(50).IsUnicode(false);

            builder.Property(e => e.Version).HasColumnName("VERSION");
            builder.Property(e => e.FUpdate).HasColumnName("FUPDATE").HasColumnType("datetime");
            builder.Property(e => e.UserNameUpdate).HasColumnName("USERNAMEUPDATE").HasConversion(c => c.ToUpper(), c => c).HasMaxLength(50).IsUnicode(false);


            builder.Property(e => e.Active)
                .HasColumnName("ACTIVE")
                .HasMaxLength(1)
                .IsRequired()
                .HasDefaultValue<BoolCharEnum>()
                .HasConversion(v => v.ToString(),
                               v => (BoolCharEnum)Enum.Parse(typeof(BoolCharEnum), v))
                 .IsUnicode(false);
        }

        public abstract void Configure(EntityTypeBuilder<TBaseStampEntity> builder);
    }
}