using MediatR;
using Microsoft.AspNetCore.Http;
using System;

namespace Backend.Business.Media.MediaRequests.UploadUserAvatar
{
    public class UploadUserAvatarRequest : IRequest<string>
    {
        public Guid UserId { get; set; }
        public IFormFile File { get; set; }
    }
}
