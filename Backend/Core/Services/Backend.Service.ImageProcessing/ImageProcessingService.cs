using Backend.Service.ImageProcessing.Interfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using System.IO;
using System.Threading.Tasks;

namespace Backend.Service.ImageProcessing
{
    public class ImageProcessingService : IImageProcessingService
    {
        public async Task<Stream> Compress(Stream stream, int quality = 30)
        {
            using (Image image = Image.Load(stream))
            {
                var encoder = new JpegEncoder()
                {
                    Quality = quality,
                };

                var result = new MemoryStream();
                image.SaveAsJpeg(result, encoder);

                return await Task.FromResult(result);
            }
        }
    }
}