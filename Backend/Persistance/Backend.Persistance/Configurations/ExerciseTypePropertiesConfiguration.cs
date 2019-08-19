using Backend.Domain.Entities.ExerciseType;
using Backend.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Backend.Persistance.Configurations
{
    public class ExerciseTypePropertyConfiguration : IEntityTypeConfiguration<ExerciseTypeProperty>
    {
        public void Configure(EntityTypeBuilder<ExerciseTypeProperty> builder)
        {
            builder.Property(x => x.Active).HasDefaultValue(true);

            builder.Property(x => x.ExerciseTypePropertyType)
                .HasConversion(
                    v => v.ToString(),
                    v => (ExerciseTypePropertyType)Enum.Parse(typeof(ExerciseTypePropertyType), v));

            builder
                .HasDiscriminator(x => x.ExerciseTypePropertyType)
                .HasValue<ExerciseTypeProperty>(ExerciseTypePropertyType.GenericProperty)
                .HasValue<Grip>(ExerciseTypePropertyType.Grip)
                .HasValue<Tempo>(ExerciseTypePropertyType.Tempo)
                .HasValue<LoadAccomodation>(ExerciseTypePropertyType.LoadAccomodation)
                .HasValue<RangeOfMotion>(ExerciseTypePropertyType.RangeOfMotion)
                .HasValue<Category>(ExerciseTypePropertyType.Category)
                .HasValue<Equipment>(ExerciseTypePropertyType.Equipment)
                .HasValue<BarPosition>(ExerciseTypePropertyType.BarPosition)
                .HasValue<BarType>(ExerciseTypePropertyType.BarType)
                .HasValue<Stance>(ExerciseTypePropertyType.Stance);
        }
    }

}
