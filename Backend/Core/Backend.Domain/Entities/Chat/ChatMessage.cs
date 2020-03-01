using System;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;

namespace Backend.Domain.Entities.Chat
{
    public class ChatMessage
    {
        public Guid Id { get; set; }

        public MessageType Type { get; set; }
        public string Message { get; set; }

        public DateTime SentAt { get; set; }
        public DateTime? SeenAt { get; set; }

        public bool ContainsMedia { get; set; }
        public string DownloadUrl { get; set; }
        public int? FileSizeInBytes { get; set; }
        public string S3Filename { get; set; }

        public Guid SenderId { get; set; }
        public virtual ApplicationUser Sender { get; set; }

        public Guid? ReceiverId { get; set; }
        //public virtual ApplicationUser Receiver { get; set; }
    }
}