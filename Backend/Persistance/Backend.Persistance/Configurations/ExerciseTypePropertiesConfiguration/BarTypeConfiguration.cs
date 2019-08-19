using Backend.Domain.Entities.ExerciseType.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations.ExerciseTypePropertiesConfiguration
{
    public class BarTypeConfiguration : IEntityTypeConfiguration<BarType>
    {
        public void Configure(EntityTypeBuilder<BarType> builder)
        {
            builder.Property(x => x.Active).HasDefaultValue(true);
        }
    }
}