using Backend.Domain.Entities.ExerciseType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations
{
    /// <summary>
    /// JOIN TABLE FOR EXERCISE TYPE - EXERCISE PROPERTIES
    /// </summary>
    public class ExerciseTypeExercisePropertyConfiguration : IEntityTypeConfiguration<ExerciseTypeExerciseProperty>
    {
        public void Configure(EntityTypeBuilder<ExerciseTypeExerciseProperty> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Show).HasDefaultValue(true);

            builder.HasOne(x => x.ExerciseType)
                .WithMany(x => x.Properties)
                .HasForeignKey(x => x.ExerciseTypeId);
        }
    }
}