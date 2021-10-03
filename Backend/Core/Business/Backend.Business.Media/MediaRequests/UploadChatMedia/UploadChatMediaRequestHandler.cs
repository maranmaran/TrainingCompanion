using Backend.Domain.Enum;
using Backend.Infrastructure.Exceptions;
using Backend.Library.AmazonS3.Interfaces;
using Backend.Library.MediaCompression.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Media.MediaRequests.UploadChatMedia
{
    // TODO: Perhaps merge upload requests for training and chat...
    // TODO: these can be just Upload media to S3
    public class UploadChatMediaRequestHandler : IRequestHandler<UploadChatMediaRequest, string>
    {
        private readonly IStorage _storage;
        private readonly IMediaCompressionService _compressionService;

        public UploadChatMediaRequestHandler(IStorage s3, IMediaCompressionService compressionService)
        {
            _storage = s3;
            _compressionService = compressionService;
        }

        public async Task<string> Handle(UploadChatMediaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var data = request.Data;

                // compress - TODO: Do this for videos also.. make compression service
                if (request.Type == MediaType.Image)
                {
                    data = await _compressionService.Compress(MediaType.Image, request.Data);
                }

                await _storage.WriteAsync(request.Key, data, request.File.ContentType, cancellationToken);

                return await _storage.GetUrlAsync(request.Key);
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(UploadChatMediaRequest), e);
            }
        }
    }
}