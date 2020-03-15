using Backend.Library.ImageProcessing.Interfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using System.IO;
using System.Threading.Tasks;

namespace Backend.Library.ImageProcessing
{
    public class ImageProcessingService : IImageProcessingService
    {
        public async Task<Stream> Compress(Stream stream, int quality = 10)
        {
            using (Image image = Image.Load(stream))
            {
                var encoder = new JpegEncoder()
                {
                    Quality = quality,
                };

                var result = new MemoryStream();
                image.SaveAsJpeg(result, encoder);

                result.Seek(0, SeekOrigin.Begin);
                return await Task.FromResult(result);
            }
        }
    }
}