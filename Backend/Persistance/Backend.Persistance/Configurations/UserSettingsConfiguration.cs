using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Backend.Persistance.Configurations
{
    public class UserSettingsConfiguration : IEntityTypeConfiguration<UserSetting>
    {
        public void Configure(EntityTypeBuilder<UserSetting> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Theme)
                .HasDefaultValue(Themes.Light)
                .HasConversion(
                    v => v.ToString(),
                    v => (Themes)Enum.Parse(typeof(Themes), v));

            builder.Property(x => x.UnitSystem)
                .HasDefaultValue(UnitSystem.Metric)
                .HasConversion(
                    v => v.ToString(),
                    v => (UnitSystem)Enum.Parse(typeof(UnitSystem), v));

            builder.Property(x => x.UseRpeSystem).HasDefaultValue(true);
            builder.Property(x => x.RpeSystem)
                .HasDefaultValue(RpeSystem.Rpe)
                .HasConversion(
                    v => v.ToString(),
                    v => (RpeSystem)Enum.Parse(typeof(RpeSystem), v));

            builder
                .HasMany(x => x.NotificationSettings)
                .WithOne(x => x.UserSetting)
                .HasForeignKey(x => x.UserSettingId);

            builder.HasOne(x => x.ApplicationUser).WithOne(x => x.UserSetting)
                .HasForeignKey<ApplicationUser>(x => x.UserSettingId);
        }
    }
}