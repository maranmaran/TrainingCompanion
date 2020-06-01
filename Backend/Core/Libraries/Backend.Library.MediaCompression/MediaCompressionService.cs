using Backend.Domain.Enum;
using Backend.Library.MediaCompression.Interfaces;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Backend.Library.MediaCompression
{
    public class MediaCompressionService : IMediaCompressionService
    {
        public async Task<Stream> Compress(MediaType type, Stream stream)
        {
            switch (type)
            {
                case MediaType.Image:
                    return await CompressImage(stream);
                case MediaType.Video:
                    return await CompressVideo(stream);
                default:
                    throw new ArgumentException($"Media type {type} can't be compressed.");
            }
        }

        internal async Task<Stream> CompressImage(Stream stream, int quality = 10)
        {
            using var image = Image.Load(stream);
            var encoder = new JpegEncoder()
            {
                Quality = quality,
            };

            var result = new MemoryStream();
            image.SaveAsJpeg(result, encoder);

            result.Seek(0, SeekOrigin.Begin);

            return await Task.FromResult(result);
        }

        internal Task<Stream> CompressVideo(Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}