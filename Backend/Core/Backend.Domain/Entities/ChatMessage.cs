using Backend.Domain.Enum;
using System;

namespace Backend.Domain.Entities
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

        public Guid SenderId { get; set; }
        public virtual ApplicationUser Sender { get; set; }

        public Guid? ReceiverId { get; set; }
        //public virtual ApplicationUser Receiver { get; set; }

    }
}
