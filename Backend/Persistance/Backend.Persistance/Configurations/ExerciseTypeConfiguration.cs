﻿using Backend.Domain.Entities.ExerciseType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Backend.Persistance.Configurations
{
    /// <summary>
    /// EXERCISE TYPE
    /// </summary>
    public class ExerciseTypeConfiguration : IEntityTypeConfiguration<ExerciseType>
    {
        public void Configure(EntityTypeBuilder<ExerciseType> builder)
        {
            builder
                .HasOne(x => x.ApplicationUser)
                .WithMany(x => x.ExerciseTypes)
                .HasForeignKey(x => x.ApplicationUserId);

            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.Property(x => x.Code).HasDefaultValue(Guid.NewGuid().ToString());
            builder.Property(x => x.RequiresReps).HasDefaultValue(true);
            builder.Property(x => x.RequiresSets).HasDefaultValue(true);
            builder.Property(x => x.RequiresWeight).HasDefaultValue(true);
            builder.Property(x => x.RequiresBodyweight).HasDefaultValue(false);
            builder.Property(x => x.RequiresTime).HasDefaultValue(false);

            builder.HasIndex(x => x.ApplicationUserId);
            builder.HasIndex(x => x.Code).IsUnique();

            builder
                .HasMany(x => x.Properties)
                .WithOne(x => x.ExerciseType)
                .HasForeignKey(x => x.ExerciseTypeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Exercises)
                .WithOne(x => x.ExerciseType)
                .HasForeignKey(x => x.ExerciseTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.ApplicationUserId);
        }
    }
}