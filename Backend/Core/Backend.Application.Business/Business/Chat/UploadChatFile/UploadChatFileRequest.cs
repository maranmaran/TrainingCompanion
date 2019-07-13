using Backend.Service.Chat.NgChatModels;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Backend.Application.Business.Business.Chat.UploadChatFile
{
    public class UploadChatFileRequest : IRequest<MessageViewModel>
    {
        public string UserId { get; set; }
        public IFormFile File { get; set; }

        public UploadChatFileRequest(string userId, IFormFile file)
        {
            UserId = userId;
            File = file;
        }
    }
}
