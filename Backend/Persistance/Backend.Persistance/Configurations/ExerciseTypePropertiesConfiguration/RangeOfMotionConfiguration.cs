using Backend.Domain.Entities.ExerciseType.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations.ExerciseTypePropertiesConfiguration
{
    public class RangeOfMotionConfiguration : IEntityTypeConfiguration<RangeOfMotion>
    {
        public void Configure(EntityTypeBuilder<RangeOfMotion> builder)
        {
            builder.Property(x => x.Active).HasDefaultValue(true);
        }
    }
}