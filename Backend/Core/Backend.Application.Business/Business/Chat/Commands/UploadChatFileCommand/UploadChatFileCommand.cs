using Backend.Service.Chat.NgChatModels;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Backend.Application.Business.Business.Chat.Commands.UploadChatFileCommand
{
    public class UploadChatFileCommand : IRequest<MessageViewModel>
    {
        public string UserId { get; set; }
        public IFormFile File { get; set; }

        public UploadChatFileCommand(string userId, IFormFile file)
        {
            UserId = userId;
            File = file;
        }
    }
}
