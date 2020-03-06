using Backend.Domain;
using Backend.Service.AmazonS3.Interfaces;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Media.MediaRequests.UploadUserAvatar
{
    public class UploadUserAvatarRequestRequest : IRequest<Unit>
    {

    }

    public class UploadUserAvatarRequestHandler : IRequestHandler<UploadUserAvatarRequestRequest, Unit>
    {

        private readonly IApplicationDbContext _context;
        private readonly IS3Service _s3;

        public UploadUserAvatarRequestHandler(IS3Service s3, IApplicationDbContext context)
        {
            _s3 = s3;
            _context = context;
        }

        public async Task<Unit> Handle(UploadUserAvatarRequestRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(UploadUserAvatarRequestRequest), e);
            }
        }
    }
}
