using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Service.AmazonS3.Interfaces;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediaType = Backend.Domain.Enum.MediaType;

namespace Backend.Application.Business.Business.Media
{
    public class GetUserMediaByTypeRequest : IRequest<IQueryable<MediaFile>>
    {
        public Guid UserId { get; set; }
        public MediaType MediaType { get; set; }
    }

    public class GetUserMediaByTypeRequestHandler : IRequestHandler<GetUserMediaByTypeRequest, IQueryable<MediaFile>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IS3AccessService _s3AccessService;

        public GetUserMediaByTypeRequestHandler(IApplicationDbContext context, IS3AccessService s3AccessService)
        {
            _context = context;
            _s3AccessService = s3AccessService;
        }

        public async Task<IQueryable<MediaFile>> Handle(GetUserMediaByTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var media = _context.MediaFiles
                    .Where(x => x.ApplicationUserId == request.UserId && x.Type == request.MediaType);

                return await Task.FromResult(media);
            }
            catch (Exception e)
            {
                throw new FetchFailureException($"Could not fetch list of media of type {request.MediaType} for user {request.UserId}", e);
            }
        }
    }
}
