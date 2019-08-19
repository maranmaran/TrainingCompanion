using Backend.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations
{
    public class AthleteConfiguration : IEntityTypeConfiguration<Athlete>
    {
        public void Configure(EntityTypeBuilder<Athlete> builder)
        {
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
        }
    }

    public class AdminConfiguration : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
        }
    }
}
