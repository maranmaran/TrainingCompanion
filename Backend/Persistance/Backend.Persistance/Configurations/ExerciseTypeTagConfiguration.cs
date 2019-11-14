using Backend.Domain.Entities.ExerciseType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations
{
    /// <summary>
    /// JOIN TABLE FOR EXERCISE TYPE - EXERCISE PROPERTIES
    /// </summary>
    public class ExerciseTypeTagConfiguration : IEntityTypeConfiguration<ExerciseTypeTag>
    {
        public void Configure(EntityTypeBuilder<ExerciseTypeTag> builder)
        {
            builder.HasKey(x => x.Id);
            //builder.Property(x => x.Show).HasDefaultValue(true);

            builder.HasOne(x => x.ExerciseType)
                .WithMany(x => x.Properties)
                .HasForeignKey(x => x.ExerciseTypeId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.HasOne(x => x.Tag)
                .WithMany(x => x.ExerciseTypeTags)
                .HasForeignKey(x => x.TagId)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}