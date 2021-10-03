using Backend.Domain.Enum;
using MediatR;
using System.IO;
using System.Security.AccessControl;
using Microsoft.AspNetCore.Http;

namespace Backend.Business.Media.MediaRequests.UploadChatMedia
{
    public class UploadChatMediaRequest : IRequest<string>
    {
        public string Key { get; set; }
        public MediaType Type { get; set; }
        public Stream Data { get; set; }
        
        public IFormFile File { get; set; }

        public UploadChatMediaRequest(string key, MediaType type, Stream data, IFormFile file)
        {
            Key = key;
            Type = type;
            Data = data;
            File = file;
        }
    }
}