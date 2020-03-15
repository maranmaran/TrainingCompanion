using Backend.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Library.AmazonS3.Interfaces;
using Backend.Library.ImageProcessing.Interfaces;

namespace Backend.Business.Media.MediaRequests.UploadChatMedia
{
    public class UploadChatMediaRequestHandler : IRequestHandler<UploadChatMediaRequest, string>
    {

        private readonly IS3Service _s3Service;
        private readonly IImageProcessingService _imageProcessing;

        public UploadChatMediaRequestHandler(IS3Service s3, IImageProcessingService imageProcessing)
        {
            _s3Service = s3;
            _imageProcessing = imageProcessing;
        }

        public async Task<string> Handle(UploadChatMediaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var compressedImage = await _imageProcessing.Compress(request.Data);
                await _s3Service.WriteToS3(request.Key, compressedImage);

                return await _s3Service.GetPresignedUrlAsync(request.Key);
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(UploadChatMediaRequest), e);
            }
        }
    }
}