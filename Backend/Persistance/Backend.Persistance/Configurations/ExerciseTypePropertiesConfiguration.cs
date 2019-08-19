using Backend.Domain.Entities.ExerciseType.Properties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations
{
    public class ExerciseTypePropertiesConfiguration
    {
        public void Configure(EntityTypeBuilder<Grip> builder)
        {
            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.Property(x => x.Order).ValueGeneratedOnAdd().Metadata.AfterSaveBehavior =
                PropertySaveBehavior.Throw;
        }
        public void Configure(EntityTypeBuilder<Stance> builder)
        {
            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.Property(x => x.Order).ValueGeneratedOnAdd().Metadata.AfterSaveBehavior =
                PropertySaveBehavior.Throw;
        }
        public void Configure(EntityTypeBuilder<BarType> builder)
        {
            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.Property(x => x.Order).ValueGeneratedOnAdd().Metadata.AfterSaveBehavior =
                PropertySaveBehavior.Throw;
        }
        public void Configure(EntityTypeBuilder<BarPosition> builder)
        {
            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.Property(x => x.Order).ValueGeneratedOnAdd().Metadata.AfterSaveBehavior =
                PropertySaveBehavior.Throw;
        }
        public void Configure(EntityTypeBuilder<ExerciseEquipment> builder)
        {
            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.Property(x => x.Order).ValueGeneratedOnAdd().Metadata.AfterSaveBehavior =
                PropertySaveBehavior.Throw;
        }
        public void Configure(EntityTypeBuilder<ExerciseCategory> builder)
        {
            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.Property(x => x.Order).ValueGeneratedOnAdd().Metadata.AfterSaveBehavior =
                PropertySaveBehavior.Throw;
        }
        public void Configure(EntityTypeBuilder<RangeOfMotion> builder)
        {
            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.Property(x => x.Order).ValueGeneratedOnAdd().Metadata.AfterSaveBehavior =
                PropertySaveBehavior.Throw;
        }
        public void Configure(EntityTypeBuilder<LoadAccomodation> builder)
        {
            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.Property(x => x.Order).ValueGeneratedOnAdd().Metadata.AfterSaveBehavior =
                PropertySaveBehavior.Throw;
        }
        public void Configure(EntityTypeBuilder<Tempo> builder)
        {
            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.Property(x => x.Order).ValueGeneratedOnAdd().Metadata.AfterSaveBehavior =
                PropertySaveBehavior.Throw;
        }
    }
}
