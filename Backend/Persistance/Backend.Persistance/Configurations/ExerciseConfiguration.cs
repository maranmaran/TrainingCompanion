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
        }
    }
}