using Backend.Domain.Entities.ExerciseType.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations.ExerciseTypePropertiesConfiguration
{
    public class TempoConfiguration : IEntityTypeConfiguration<Tempo>
    {
        public void Configure(EntityTypeBuilder<Tempo> builder)
        {
            builder.Property(x => x.Active).HasDefaultValue(true);
        }
    }
}
