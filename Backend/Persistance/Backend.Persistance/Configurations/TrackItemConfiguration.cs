using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations
{
    public class TrackItemConfiguration : IEntityTypeConfiguration<TrackItem>
    {
        public void Configure(EntityTypeBuilder<TrackItem> builder)
        {
            builder
                .HasOne(x => x.Track)
                .WithMany(x => x.Items)
                .HasForeignKey(x => x.TrackId);

            builder
                .HasOne(x => x.Params)
                .WithOne(x => x.TrackItem)
                .HasForeignKey<TrackItemParams>(x => x.TrackItemId);

            builder.HasIndex(x => x.Code).IsUnique();
        }
    }
}