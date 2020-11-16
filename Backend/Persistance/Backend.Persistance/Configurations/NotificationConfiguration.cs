using Backend.Domain.Entities.Notification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            //builder.Property(x => x.Read).HasDefaultValue(false);
            builder.Property(x => x.SentAt).HasDefaultValueSql("getutcdate()");

            builder
                .HasOne(x => x.Sender)
                .WithMany(x => x.SentNotifications)
                .HasForeignKey(x => x.SenderId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Receiver)
                .WithMany(x => x.ReceivedNotifications)
                .HasForeignKey(x => x.ReceiverId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasIndex(x => x.SenderId)
                .IsUnique(false);

            builder
                .HasIndex(x => x.ReceiverId)
                .IsUnique(false);

        }
    }
}