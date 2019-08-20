using Backend.Domain.Entities.ExerciseType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations
{
    /// <summary>
    /// EXERCISE PROPERTY
    /// </summary>
    public class ExercisePropertyConfiguration : IEntityTypeConfiguration<ExerciseProperty>
    {
        public void Configure(EntityTypeBuilder<ExerciseProperty> builder)
        {
            builder.Property(x => x.Active).HasDefaultValue(true);

            builder.HasOne(x => x.ExercisePropertyType).WithMany(x => x.Properties)
                .HasForeignKey(x => x.ExercisePropertyTypeId);

        }
    }
}