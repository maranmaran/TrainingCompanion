using Backend.Domain.Entities.Dashboard;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations
{
    public class TrackItemParamsConfiguration : IEntityTypeConfiguration<TrackItemParams>
    {
        public void Configure(EntityTypeBuilder<TrackItemParams> builder)
        {
            builder
                .HasOne(x => x.TrackItem)
                .WithOne(x => x.Params)
                .IsRequired(false)
                .HasForeignKey<TrackItemParams>(x => x.TrackItemId);
        }
    }
}