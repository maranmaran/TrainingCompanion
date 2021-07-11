using Backend.Domain.Enum;
using System;

namespace Backend.Business.Chat.ChatRequests.CreateChatMessage
{
    public class CreateChatMessageRequest : MediatR.IRequest
    {
        public string Message { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public DateTime SentAt { get; set; }
        public MessageType Type { get; set; }
        public DateTime SeenAt { get; set; }
        public string DownloadUrl { get; set; }
        public string S3Filename { get; set; }
        public string FileSizeInBytes { get; set; }
    }
}