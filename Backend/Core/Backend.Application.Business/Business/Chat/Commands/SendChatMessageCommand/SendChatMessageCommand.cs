using System;
using Backend.Domain.Enum;
using MediatR;

namespace Backend.Application.Business.Business.Chat.Commands.SendChatMessageCommand
{
    public class SendChatMessageCommand : IRequest<Unit>
    {
        public MessageType Type { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
        public Guid SenderId { get; set; }
        public Guid? ReceiverId { get; set; }
        public Guid? ChatRoomId { get; set; }
    }
}
