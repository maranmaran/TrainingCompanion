using System;
using System.Collections.Generic;
using System.Text;
using Backend.Domain.Entities.Chat;
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

            builder.HasOne(x => x.Receiver).WithMany(x => x.Notifications).HasForeignKey(x => x.SenderId);
        }
    }
}
