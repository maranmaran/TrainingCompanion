using Backend.Domain.Entities.Media;
using Backend.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Backend.Persistance.Configurations
{
    public class MediaFileConfiguration
    {
        public void Configure(EntityTypeBuilder<MediaFile> builder)
        {
            builder.Property(x => x.DateUploaded).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.DateModified).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAddOrUpdate();

            builder.Property(x => x.Type)
                .HasDefaultValue(MediaType.File)
                .HasConversion(
                    v => v.ToString(),
                    v => (MediaType)Enum.Parse(typeof(MediaType), v));

            builder
                .HasOne(x => x.ApplicationUser)
                .WithMany(x => x.MediaFiles)
                .HasForeignKey(x => x.ApplicationUserId);

            builder
                .HasOne(x => x.Training)
                .WithMany(x => x.Media)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}