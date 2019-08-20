using Backend.Domain.Entities.ExerciseType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations.ExerciseTypePropertiesConfiguration
{
    public class LoadAccomodationConfiguration : IEntityTypeConfiguration<LoadAccomodation>
    {
        public void Configure(EntityTypeBuilder<LoadAccomodation> builder)
        {
            builder.Property(x => x.Active).HasDefaultValue(true);
        }
    }
}