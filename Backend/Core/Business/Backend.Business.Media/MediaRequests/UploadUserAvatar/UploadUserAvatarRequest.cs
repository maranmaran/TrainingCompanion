using MediatR;
using System;

namespace Backend.Business.Media.MediaRequests.UploadUserAvatar
{
    public class UploadUserAvatarRequest : IRequest<string>
    {
        public Guid UserId { get; set; }
        public string Base64 { get; set; }
    }
}