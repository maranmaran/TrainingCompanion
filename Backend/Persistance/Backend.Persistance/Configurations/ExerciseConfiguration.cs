using Backend.Domain.Entities.TrainingLog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder
                .HasMany(x => x.Sets)
                .WithOne(x => x.Exercise)
                .HasForeignKey(x => x.ExerciseId);

            builder.HasOne(x => x.Training)
                .WithMany(x => x.Exercises)
                .HasForeignKey(x => x.TrainingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.ExerciseType)
                .WithMany(x => x.Exercises)
                .HasForeignKey(x => x.ExerciseTypeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Media)
                .WithOne(x => x.Exercise)
                .HasForeignKey(x => x.ExerciseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.TrainingId);
            builder.HasIndex(x => x.ExerciseTypeId);
        }
    }
}