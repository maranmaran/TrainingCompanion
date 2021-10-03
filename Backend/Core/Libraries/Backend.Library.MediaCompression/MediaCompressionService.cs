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
            return type switch
            {
                MediaType.Image => await CompressImage(stream),
                MediaType.Video => await CompressVideo(stream),
                MediaType.File => throw new NotImplementedException(),
                _ => throw new ArgumentException($"Media type {type} can't be compressed.")
            };
        }

        internal async Task<Stream> CompressImage(Stream stream, int quality = 10)
        {
            using var image = await Image.LoadAsync(stream);
            var encoder = new JpegEncoder()
            {
                Quality = quality,
            };

            var result = new MemoryStream();
            await image.SaveAsJpegAsync(result, encoder);

            result.Seek(0, SeekOrigin.Begin);

            return await Task.FromResult(result);
        }

        internal Task<Stream> CompressVideo(Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}