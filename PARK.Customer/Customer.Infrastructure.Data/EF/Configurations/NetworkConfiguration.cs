﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class NetworkConfiguration : BaseCrudEntityConfiguration<Network, Guid>
    {
        public override void Configure(EntityTypeBuilder<Network> builder)
        {
            base.Configure("Network", builder);

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(e => e.UserID)
                   .HasColumnName("UserID")
                   .IsRequired();

            builder.Property(e => e.Description)
                   .HasColumnName("Description")
                   .IsRequired();

            builder.Property(e => e.URL)
                   .HasColumnName("URL")
                   .IsRequired();
            
            builder.Property(e => e.PhoneNumber)
                   .HasColumnName("PhoneNumber");
            
            builder.Property(e => e.NetworkTypeID)
                   .HasColumnName("NetworkTypeID")
                   .IsRequired();

            // Relaciones
            builder.HasOne(e => e.User)
                   .WithMany(u => u.Networks)
                   .HasForeignKey(e => e.UserID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.NetworkType)
                   .WithMany(nt => nt.Networks)
                   .HasForeignKey(e => e.NetworkTypeID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}