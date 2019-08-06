using Backend.Domain.Entities;
using Backend.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Backend.Persistance.Configurations
{

    public class AthleteConfiguration : IEntityTypeConfiguration<Athlete>
    {
        public void Configure(EntityTypeBuilder<Athlete> builder)
        {
            builder.Property(x => x.AccountType)
                .HasDefaultValue(AccountType.Athlete)
                .HasConversion(
                    v => v.ToString(),
                    v => (AccountType)Enum.Parse(typeof(AccountType), v));

            builder
                .HasOne(x => x.Coach)
                .WithMany(x => x.Athletes)
                .HasForeignKey(x => x.CoachId);
        }
    }
}
