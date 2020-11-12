using Backend.Domain.Enum;
using MediatR;
using System.IO;

namespace Backend.Business.Media.MediaRequests.UploadChatMedia
{
    public class UploadChatMediaRequest : IRequest<string>
    {
        public string Key { get; set; }
        public MediaType Type { get; set; }
        public Stream Data { get; set; }


        public UploadChatMediaRequest(string key, MediaType type, Stream data)
        {
            Key = key;
            Type = type;
            Data = data;
        }
    }
}
