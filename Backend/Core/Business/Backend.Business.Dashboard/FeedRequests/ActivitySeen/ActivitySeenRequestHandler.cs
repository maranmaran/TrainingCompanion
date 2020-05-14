using Backend.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Dashboard.FeedRequests.ActivitySeen
{
    public class ActivitySeenRequestHandler : IRequestHandler<ActivitySeenRequest, Unit>
    {
        private readonly IApplicationDbContext _context;

        public ActivitySeenRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ActivitySeenRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var activity = await _context.Audits.FirstOrDefaultAsync(x => x.Id == request.ActivityId, cancellationToken);
                if (activity == null) return Unit.Value;

                activity.Seen = true;
                _context.Audits.Update(activity);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(ActivitySeenRequest), e);
            }
        }
    }
}