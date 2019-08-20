using Backend.Domain.Entities.ExerciseType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations.ExerciseTypePropertiesConfiguration
{
    public class BarPositionConfiguration : IEntityTypeConfiguration<BarPosition>
    {
        public void Configure(EntityTypeBuilder<BarPosition> builder)
        {
            builder.Property(x => x.Active).HasDefaultValue(true);
        }
    }
}