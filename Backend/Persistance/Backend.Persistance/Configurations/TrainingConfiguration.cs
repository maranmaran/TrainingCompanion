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

            // maybe that has one has many config ?
        }
    }
}
