using System;
using System.Collections.Generic;
using System.Text;
using Backend.Domain.Entities.ExerciseType;
using Backend.Domain.Entities.TrainingLog;
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
        }
    }
}
