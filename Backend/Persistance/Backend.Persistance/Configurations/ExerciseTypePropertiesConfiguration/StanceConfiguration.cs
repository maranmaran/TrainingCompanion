using Backend.Domain.Entities.ExerciseType.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations.ExerciseTypePropertiesConfiguration
{
    public class StanceConfiguration : IEntityTypeConfiguration<Stance>
    {
        public void Configure(EntityTypeBuilder<Stance> builder)
        {
            builder.Property(x => x.Active).HasDefaultValue(true);
        }
    }
}