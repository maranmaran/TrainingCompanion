using Backend.Domain;
using Backend.Domain.Entities.User.Dashboard;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Dashboard.DashboardRequests.UpdateTrackItem
{

    public class UpdateTrackItemRequest : IRequest<TrackItem>
    {
        public UpdateTrackItemRequest()
        {
        }

        public UpdateTrackItemRequest(Guid trackItemId, string jsonParams)
        {
            TrackItemId = trackItemId;
            JsonParams = jsonParams;
        }

        public Guid TrackItemId { get; set; }
        public string JsonParams { get; set; }
    }

    public class UpdateTrackItemRequestValidator : AbstractValidator<UpdateTrackItemRequest>
    {
        public UpdateTrackItemRequestValidator()
        {
            RuleFor(x => x.TrackItemId).NotEmpty();
            RuleFor(x => x.JsonParams).NotEmpty();
        }
    }

    public class UpdateTrackItemRequestHandler : IRequestHandler<UpdateTrackItemRequest, TrackItem>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTrackItemRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<TrackItem> Handle(UpdateTrackItemRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var trackItem = await _context.TrackItems.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.TrackItemId, cancellationToken);

                trackItem.JsonParams = request.JsonParams;
                _context.TrackItems.Update(trackItem);

                await _context.SaveChangesAsync(cancellationToken);

                return trackItem;
            }
            catch (Exception e)
            {
                throw new Exception(nameof(UpdateTrackItemRequest), e);
            }
        }
    }

}
