using System.IO;
using System.Threading.Tasks;

namespace Backend.Service.ImageProcessing.Interfaces
{
    public interface IImageProcessingService
    {
        Task<Stream> Compress(Stream stream, int quality = 30);
    }
}
