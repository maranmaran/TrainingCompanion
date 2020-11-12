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

        private readonly IS3Service _s3Service;
        private readonly IMediaCompressionService _compressionService;

        public UploadChatMediaRequestHandler(IS3Service s3, IMediaCompressionService compressionService)
        {
            _s3Service = s3;
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

                await _s3Service.WriteToS3(request.Key, data);

                return await _s3Service.GetPresignedUrlAsync(request.Key);
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(UploadChatMediaRequest), e);
            }
        }
    }
}