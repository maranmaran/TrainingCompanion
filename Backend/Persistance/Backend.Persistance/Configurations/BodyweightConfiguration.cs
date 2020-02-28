using Backend.Domain.Entities.ProgressTracking.Bodyweight;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations
{

    public class BodyweightConfiguration : IEntityTypeConfiguration<Bodyweight>
    {
        public void Configure(EntityTypeBuilder<Bodyweight> builder)
        {
            builder.Property(x => x.Date).HasDefaultValueSql("getutcdate()");

            builder
                .HasOne(x => x.User)
                .WithMany(x => x.Bodyweights)
                .HasForeignKey(x => x.UserId);
        }
    }
}
