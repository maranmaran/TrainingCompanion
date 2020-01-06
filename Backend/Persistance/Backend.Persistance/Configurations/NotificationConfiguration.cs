using Backend.Domain.Entities.Notification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.Property(x => x.Read).HasDefaultValue(false);
            builder.Property(x => x.SentAt).HasDefaultValueSql("getutcdate()");

            builder
                .HasOne(x => x.Sender)
                .WithMany(x => x.Notifications)
                .HasForeignKey(x => x.SenderId)
                .IsRequired(false);
        }
    }
}