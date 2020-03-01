using Backend.Domain.Entities.User.Dashboard;
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

            builder.Property(x => x.ParamsId).IsRequired(false);

            builder
                .HasOne(x => x.Params)
                .WithOne(x => x.TrackItem)
                .IsRequired(false)
                .HasForeignKey<TrackItem>(x => x.ParamsId);

            //builder.HasIndex(x => x.Code).IsUnique();
        }
    }
}