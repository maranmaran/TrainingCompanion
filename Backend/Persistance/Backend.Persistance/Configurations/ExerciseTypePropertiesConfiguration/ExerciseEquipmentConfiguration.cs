using Backend.Domain.Entities.ExerciseType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations.ExerciseTypePropertiesConfiguration
{
    public class ExerciseEquipmentConfiguration : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.Property(x => x.Active).HasDefaultValue(true);
        }
    }
}