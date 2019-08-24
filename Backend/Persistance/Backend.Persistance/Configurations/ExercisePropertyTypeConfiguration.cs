using Backend.Domain.Entities.ExerciseType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations
{
    /// <summary>
    /// EXERCISE PROPERTY TYPE
    /// </summary>
    public class ExercisePropertyTypeConfiguration : IEntityTypeConfiguration<ExercisePropertyType>
    {
        public void Configure(EntityTypeBuilder<ExercisePropertyType> builder)
        {
            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.Property(x => x.HexColor).HasDefaultValue("#616161"); // some kind of gray
            builder.Property(x => x.HexBackground).HasDefaultValue("#fef6f9"); // white

            builder.HasMany(x => x.Properties);

        }
    }
}