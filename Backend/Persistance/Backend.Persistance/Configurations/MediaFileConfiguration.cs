using Backend.Domain.Entities.Media;
using Backend.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Backend.Persistance.Configurations
{
    /// <summary>
    /// Media file configuration
    /// Required to have app user
    /// Training and exercise are not required but configured Restrict for on delete because
    /// MSSQL has limitation on multiple FK's with Cascade
    /// </summary>
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
                .HasForeignKey(x => x.ApplicationUserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.Training)
                .WithMany(x => x.Media)
                .HasForeignKey(x => x.TrainingId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Exercise)
                .WithMany(x => x.Media)
                .HasForeignKey(x => x.ExerciseId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.ApplicationUserId);
        }
    }
}