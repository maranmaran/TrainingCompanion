using Backend.Domain.Enum;
using System.IO;
using System.Threading.Tasks;

namespace Backend.Library.MediaCompression.Interfaces
{
    public interface IMediaCompressionService
    {
        Task<Stream> Compress(MediaType type, Stream stream);
    }
}
