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
            builder.Property(x => x.HexColor).HasDefaultValue("#ffffff");

            builder.HasMany(x => x.Properties).WithOne(x => x.ExercisePropertyType)
                .HasForeignKey(x => x.ExercisePropertyTypeId);

        }
    }
}