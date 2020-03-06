using Backend.Domain;
using Backend.Service.AmazonS3.Interfaces;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Media.MediaRequests.UploadChatMedia
{
    public class UploadChatMediaRequest : IRequest<Unit>
    {

    }

    public class UploadChatMediaRequestHandler : IRequestHandler<UploadChatMediaRequest, Unit>
    {

        private readonly IApplicationDbContext _context;
        private readonly IS3Service _s3;

        public UploadChatMediaRequestHandler(IS3Service s3, IApplicationDbContext context)
        {
            _s3 = s3;
            _context = context;
        }

        public async Task<Unit> Handle(UploadChatMediaRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(UploadChatMediaRequest), e);
            }
        }
    }
}
