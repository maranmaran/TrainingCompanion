using Backend.Service.AmazonS3.Interfaces;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Media.MediaRequests.UploadChatMedia
{
    public class UploadChatMediaRequestHandler : IRequestHandler<UploadChatMediaRequest, string>
    {

        private readonly IS3Service _s3Service;

        public UploadChatMediaRequestHandler(IS3Service s3)
        {
            _s3Service = s3;
        }

        public async Task<string> Handle(UploadChatMediaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _s3Service.WriteToS3(request.Key, request.Data);

                return await _s3Service.GetPresignedUrlAsync(request.Key);
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(UploadChatMediaRequest), e);
            }
        }
    }
}