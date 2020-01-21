using Backend.Domain.Entities.Chat;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations
{
    public class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
    {
        public void Configure(EntityTypeBuilder<ChatMessage> builder)
        {
            builder.Property(x => x.SentAt).HasDefaultValueSql("getutcdate()");
            builder.HasIndex(x => x.SenderId);
            builder.HasIndex(x => x.ReceiverId);

            builder.HasOne(x => x.Sender).WithMany(x => x.ChatMessages).HasForeignKey(x => x.SenderId);
        }
    }
}