﻿using Backend.Domain.Entities.ExerciseType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations
{
    /// <summary>
    /// EXERCISE PROPERTY
    /// </summary>
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(x => x.Active).HasDefaultValue(true);

            builder
                .HasOne(x => x.TagGroup)
                .WithMany(x => x.Tags)
                .HasForeignKey(x => x.TagGroupId);

            builder
                .HasMany(x => x.ExerciseTypeTags)
                .WithOne(x => x.Tag)
                .HasForeignKey(x => x.TagId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}