using Backend.Domain.Entities.ExerciseType.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations.ExerciseTypePropertiesConfiguration
{
    public class GripConfiguration : IEntityTypeConfiguration<Grip>
    {
        public void Configure(EntityTypeBuilder<Grip> builder)
        {
            builder.Property(x => x.Active).HasDefaultValue(true);

        }
    }
}