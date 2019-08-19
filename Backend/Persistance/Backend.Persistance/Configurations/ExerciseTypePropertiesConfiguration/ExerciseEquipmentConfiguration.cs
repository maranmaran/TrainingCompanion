using Backend.Domain.Entities.ExerciseType.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations.ExerciseTypePropertiesConfiguration
{
    public class ExerciseEquipmentConfiguration : IEntityTypeConfiguration<ExerciseEquipment>
    {
        public void Configure(EntityTypeBuilder<ExerciseEquipment> builder)
        {
            builder.Property(x => x.Active).HasDefaultValue(true);
        }
    }
}