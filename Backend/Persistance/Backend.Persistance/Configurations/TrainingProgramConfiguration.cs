using Backend.Domain.Entities.TrainingProgramMaker;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations
{
    public class TrainingProgramConfiguration : IEntityTypeConfiguration<TrainingProgram>
    {
        public void Configure(EntityTypeBuilder<TrainingProgram> builder)
        {
            builder
                .HasMany(x => x.Users)
                .WithOne(x => x.TrainingProgram)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.TrainingBlocks)
                .WithOne(x => x.TrainingProgram)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    public class TrainingProgramUserConfiguration : IEntityTypeConfiguration<TrainingProgramUser>
    {
        public void Configure(EntityTypeBuilder<TrainingProgramUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.StartedOn).HasDefaultValueSql("getutcdate()");

            builder.HasOne(x => x.TrainingProgram)
                .WithMany(x => x.Users)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.User)
                .WithMany(x => x.TrainingPrograms)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.ApplicationUserId);
            builder.HasIndex(x => x.TrainingProgramId);
        }
    }
    public class TrainingBlockConfiguration : IEntityTypeConfiguration<TrainingBlock>
    {
        public void Configure(EntityTypeBuilder<TrainingBlock> builder)
        {
            builder
                .HasMany(x => x.Days)
                .WithOne(x => x.TrainingBlock)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    public class TrainingBlockDayConfiguration : IEntityTypeConfiguration<TrainingBlockDay>
    {
        public void Configure(EntityTypeBuilder<TrainingBlockDay> builder)
        {
            builder
                .HasOne(x => x.TrainingBlock)
                .WithMany(x => x.Days)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.Trainings)
                .WithOne(x => x.TrainingBlockDay)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
