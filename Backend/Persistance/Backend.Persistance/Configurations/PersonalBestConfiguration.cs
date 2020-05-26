using Backend.Domain.Entities.ProgressTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations
{
    public class PersonalBestConfiguration : IEntityTypeConfiguration<PersonalBest>
    {
        public void Configure(EntityTypeBuilder<PersonalBest> builder)
        {
            builder
                .HasOne(x => x.ExerciseType)
                .WithMany(x => x.PBs)
                .HasForeignKey(x => x.ExerciseTypeId);

            builder.Property(x => x.WilksScore).HasDefaultValue(null);
            builder.Property(x => x.IpfPoints).HasDefaultValue(null);
            builder.Property(x => x.Bodyweight).HasDefaultValue(null);
            builder.Property(x => x.DateAchieved).HasDefaultValueSql("getutcdate()");
        }
    }
}