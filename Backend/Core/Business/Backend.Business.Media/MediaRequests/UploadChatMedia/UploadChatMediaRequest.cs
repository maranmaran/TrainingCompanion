using MediatR;
using System.IO;

namespace Backend.Business.Media.MediaRequests.UploadChatMedia
{
    public class UploadChatMediaRequest : IRequest<string>
    {
        public string Key { get; set; }
        public Stream Data { get; set; }


        public UploadChatMediaRequest(string key, Stream data)
        {
            Key = key;
            Data = data;
        }
    }
}
