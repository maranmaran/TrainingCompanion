using Backend.Domain.Entities;
using Backend.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Backend.Persistance.Configurations
{
    public class UserSettingsConfiguration : IEntityTypeConfiguration<UserSettings>
    {
        public void Configure(EntityTypeBuilder<UserSettings> builder)
        {
            builder.Property(x => x.Theme)
                .HasDefaultValue(Themes.Light)
                .HasConversion(
                    v => v.ToString(),
                    v => (Themes)Enum.Parse(typeof(Themes), v));

          
        }
    }
}
