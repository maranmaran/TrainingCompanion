using Backend.Domain.Entities.Exercises;
using Backend.Persistance.ValueGenerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            builder.Property(x => x.Code).HasValueGenerator<GuidGenerator>();

            builder.Property(x => x.Active).HasDefaultValue(true);
            //builder.Property(x => x.RequiresReps).HasDefaultValue(true);
            //builder.Property(x => x.RequiresSets).HasDefaultValue(true);
            //builder.Property(x => x.RequiresWeight).HasDefaultValue(true);
            //builder.Property(x => x.RequiresBodyweight).HasDefaultValue(false);
            //builder.Property(x => x.RequiresTime).HasDefaultValue(false);

            builder.HasIndex(x => x.ApplicationUserId);

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

            builder
                .HasMany(x => x.PBs)
                .WithOne(x => x.ExerciseType)
                .HasForeignKey(x => x.ExerciseTypeId);

            builder.HasIndex(x => x.ApplicationUserId);

            builder.HasIndex(x => new { x.ApplicationUserId, x.Code }).IsUnique();
        }
    }
}