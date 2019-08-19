using Backend.Domain.Entities.ExerciseType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace Backend.Persistance.Configurations
{
    public class ExerciseTypeConfiguration : IEntityTypeConfiguration<ExerciseType>
    {
        public void Configure(EntityTypeBuilder<ExerciseType> builder)
        {
            builder.HasOne(x => x.Athlete).WithMany(x => x.ExerciseTypes).HasForeignKey(x => x.AthleteId);
            builder.HasMany(x => x.ExerciseMaxes).WithOne(x => x.ExerciseType).HasForeignKey(x => x.ExerciseTypeId);

            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.Property(x => x.RequiresReps).HasDefaultValue(true);
            builder.Property(x => x.RequiresSets).HasDefaultValue(true);
            builder.Property(x => x.RequiresWeight).HasDefaultValue(true);
            builder.Property(x => x.RequiresBodyweight).HasDefaultValue(false);
            builder.Property(x => x.RequiresTime).HasDefaultValue(false);

            builder.HasOne(x => x.BarType).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.BarPosition).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Tempo).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.RangeOfMotion).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Grip).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Stance).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Category).WithMany().OnDelete(DeleteBehavior.Restrict);

        }
    }

    public class ExerciseTypeLoadAccomodationConfiguration : IEntityTypeConfiguration<ExerciseTypeLoadAccomodation>
    {
        public void Configure(EntityTypeBuilder<ExerciseTypeLoadAccomodation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.ExerciseType)
                    .WithMany(x => x.LoadAccomodation)
                    .HasForeignKey(x => x.ExerciseTypeId); 
        }
    }

    public class ExerciseTypeEquipmentConfiguration : IEntityTypeConfiguration<ExerciseTypeEquipment>
    {
        public void Configure(EntityTypeBuilder<ExerciseTypeEquipment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.ExerciseType)
                    .WithMany(x => x.Equipment)
                    .HasForeignKey(x => x.ExerciseTypeId); 
        }
    }
}
