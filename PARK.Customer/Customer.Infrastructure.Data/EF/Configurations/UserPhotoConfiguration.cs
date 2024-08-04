using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.Data.EF.Configurations
{
    public class UserPhotoConfiguration : BaseCrudEntityConfiguration<UserPhoto, Guid>
    {
        public override void Configure(EntityTypeBuilder<UserPhoto> builder)
        {
            base.Configure("USER_PHOTO", builder);

            builder.Property(e => e.Id)
                   .HasColumnName("ID")
                   .IsRequired();

            builder.Property(e => e.UserID)
                   .HasColumnName("USER_ID")
                   .IsRequired();

            builder.Property(e => e.Description)
                   .HasColumnName("DESCRIPTION")
                   .IsRequired(false);

            builder.Property(e => e.ImageUrl)
                   .HasColumnName("IMAGE_URL")
                   .IsRequired();

            // Uncomment this if you have a navigation property in UserPhotoModel
            // builder.HasOne(e => e.User)
            //        .WithMany(u => u.UserPhotos)
            //        .HasForeignKey(e => e.UserID)
            //        .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
