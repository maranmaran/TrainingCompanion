using Backend.Business.Chat.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Backend.Business.Chat.ChatRequests.UploadChatFile
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