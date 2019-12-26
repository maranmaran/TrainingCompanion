using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using Backend.Persistance.ValueGenerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Backend.Persistance.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.CreatedOn).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.LastModified).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAddOrUpdate();
            builder.Property(x => x.TrialDuration).HasDefaultValue(15);
            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.Property(x => x.Avatar).HasValueGenerator<AvatarGenerator>();

            builder
                .HasDiscriminator(x => x.AccountType)
                .HasValue<ApplicationUser>(AccountType.User)
                .HasValue<Athlete>(AccountType.Athlete)
                .HasValue<Coach>(AccountType.Coach)
                .HasValue<SoloAthlete>(AccountType.SoloAthlete)
                .HasValue<Admin>(AccountType.Admin);

            builder.Property(x => x.AccountType)
                .HasConversion(
                    v => v.ToString(),
                    v => (AccountType)Enum.Parse(typeof(AccountType), v));

            builder.Property(x => x.Gender)
                .HasDefaultValue(Gender.Male)
                .HasConversion(
                    v => v.ToString(),
                    v => (Gender)Enum.Parse(typeof(Gender), v));

            builder
                .HasMany(x => x.MediaFiles)
                .WithOne(x => x.ApplicationUser)
                .HasForeignKey(x => x.ApplicationUserId);

            builder
                .HasMany(x => x.TagGroups)
                .WithOne(x => x.ApplicationUser)
                .HasForeignKey(x => x.ApplicationUserId);

            builder
                .HasMany(x => x.ExerciseTypes)
                .WithOne(x => x.ApplicationUser)
                .HasForeignKey(x => x.ApplicationUserId);

            builder
                .HasMany(x => x.Trainings)
                .WithOne(x => x.ApplicationUser)
                .HasForeignKey(x => x.ApplicationUserId);

            builder
                .HasOne(x => x.UserSetting)
                .WithOne(x => x.ApplicationUser)
                .HasForeignKey<UserSetting>(x => x.ApplicationUserId);
        }
    }
}