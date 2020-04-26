﻿using Backend.Domain.Entities.TrainingLog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations
{
    public class TrainingConfiguration : IEntityTypeConfiguration<Training>
    {
        public void Configure(EntityTypeBuilder<Training> builder)
        {
            builder.Property(x => x.DateTrained).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.NoteRead).HasDefaultValue(false);

            builder
                .HasOne(x => x.ApplicationUser)
                .WithMany(x => x.Trainings)
                .HasForeignKey(x => x.ApplicationUserId)
                .IsRequired(false);

            builder
                .HasMany(x => x.Exercises)
                .WithOne(x => x.Training)
                .HasForeignKey(x => x.TrainingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Media)
                .WithOne(x => x.Training);
            // maybe that has one has many config ?

            builder
                .HasOne(x => x.TrainingBlockDay)
                .WithMany(x => x.Trainings)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            builder.HasIndex(x => x.ApplicationUserId);

        }
    }
}