using Backend.Domain;
using Backend.Domain.Entities.ProgressTracking;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.ProgressTracking.BodyweightRequests.GetLatest
{
    public class GetLatestBodyweightRequestHandler : IRequestHandler<GetLatestBodyweightRequest, Bodyweight>
    {
        private readonly IApplicationDbContext _context;

        public GetLatestBodyweightRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Bodyweight> Handle(GetLatestBodyweightRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var bw = await _context.Bodyweights
                    .Where(x => x.UserId == request.UserId)
                    .OrderByDescending(x => x.Date)
                    .FirstOrDefaultAsync(cancellationToken);

                return bw;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(GetLatestBodyweightRequest), e);
            }
        }
    }
}