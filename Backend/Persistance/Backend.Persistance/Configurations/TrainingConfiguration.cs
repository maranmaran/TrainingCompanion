using Backend.Domain.Entities.TrainingLog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations
{
    public class TrainingConfiguration : IEntityTypeConfiguration<Training>
    {
        public void Configure(EntityTypeBuilder<Training> builder)
        {
            builder.Property(x => x.DateTrained).HasDefaultValueSql("getutcdate()");
            //builder.Property(x => x.NoteRead).HasDefaultValue(false);

            builder
                .HasOne(x => x.ApplicationUser)
                .WithMany(x => x.Trainings)
                .HasForeignKey(x => x.ApplicationUserId)
                .IsRequired(false);

            builder
                .HasMany(x => x.Exercises)
                .WithOne(x => x.Training)
                .HasForeignKey(x => x.TrainingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.Media)
                .WithOne(x => x.Training)
                .HasForeignKey(x => x.TrainingId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.TrainingProgram)
                .WithMany(x => x.Trainings)
                .HasForeignKey(x => x.TrainingProgramId)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(x => x.TrainingBlockDay)
                .WithMany(x => x.Trainings)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new { x.ApplicationUserId, x.DateTrained });

        }
    }
}