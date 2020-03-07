using System.IO;
using System.Threading.Tasks;

namespace Backend.Library.ImageProcessing.Interfaces
{
    public interface IImageProcessingService
    {
        Task<Stream> Compress(Stream stream, int quality = 30);
    }
}
