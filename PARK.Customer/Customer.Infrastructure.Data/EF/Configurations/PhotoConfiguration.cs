using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.EF.Configurations
{
    public class PhotoConfiguration : BaseCrudEntityConfiguration<Photo, Guid>
    {
        public override void Configure(EntityTypeBuilder<Photo> builder)
        {
            {
                base.Configure("PARK_CUSTOMERPHOTO", builder);


                builder.Property(e => e.Id)
                       .HasColumnName("ID")
                       .IsRequired();

                builder.Property(e => e.CustomerId)
                       .HasColumnName("CUSTOMER_ID")
                       .IsRequired();

                builder.Property(e => e.Description)
                       .HasColumnName("DESCRIPTION")
                       .IsRequired();

                builder.Property(e => e.Image)
                       .HasColumnName("IMAGE");

                builder.HasOne(e => e.Customer)
                  .WithMany(e => e.CustomerPhotos)
                  .HasForeignKey(e => e.CustomerId)
                  .OnDelete(DeleteBehavior.Cascade);
            }
        }
    }
}
