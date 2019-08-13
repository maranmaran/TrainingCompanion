using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations
{
    public class AthleteConfiguration : IEntityTypeConfiguration<Athlete>
    {
        public void Configure(EntityTypeBuilder<Athlete> builder)
        {
            //builder.Property(x => x.AccountType)
            //    .HasDefaultValue(AccountType.Athlete)
            //    .HasConversion(
            //        v => v.ToString(),
            //        v => (AccountType)Enum.Parse(typeof(AccountType), v));

            builder
                .HasOne(x => x.Coach)
                .WithMany(x => x.Athletes)
                .HasForeignKey(x => x.CoachId);
        }
    }

    public class CoachConfiguration : IEntityTypeConfiguration<Coach>
    {
        public void Configure(EntityTypeBuilder<Coach> builder)
        {
            //builder.Property(x => x.AccountType)
            //    .HasDefaultValue(AccountType.Coach)
            //    .HasConversion(
            //        v => v.ToString(),
            //        v => (AccountType)Enum.Parse(typeof(AccountType), v));

            builder
                .HasMany(x => x.Athletes)
                .WithOne(x => x.Coach)
                .HasForeignKey(x => x.CoachId);

        }
    }

    public class SoloAthleteConfiguration : IEntityTypeConfiguration<SoloAthlete>
    {
        public void Configure(EntityTypeBuilder<SoloAthlete> builder)
        {
            //builder.Property(x => x.AccountType)
            //    .HasDefaultValue(AccountType.SoloAthlete)
            //    .HasConversion(
            //        v => v.ToString(),
            //        v => (AccountType)Enum.Parse(typeof(AccountType), v));

        }
    }

    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            //builder.Property(x => x.AccountType)
            //    .HasDefaultValue(AccountType.Admin)
            //    .HasConversion(
            //        v => v.ToString(),
            //        v => (AccountType)Enum.Parse(typeof(AccountType), v));

        }
    }
}
