using Backend.Domain;
using Backend.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.ProgressTracking.BodyweightRequests.GetAll
{
    public class GetAllBodyweightRequestHandler : IRequestHandler<GetAllBodyweightRequest, IOrderedQueryable<Domain.Entities.ProgressTracking.Bodyweight>>
    {
        private readonly IApplicationDbContext _context;


        public GetAllBodyweightRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }


        public Task<IOrderedQueryable<Domain.Entities.ProgressTracking.Bodyweight>> Handle(GetAllBodyweightRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var entities = _context.Bodyweights.Where(x => x.UserId == request.UserId).OrderByDescending(x => x.Date);
                return Task.FromResult(entities);
            }
            catch (Exception e)
            {
                throw new FetchFailureException(nameof(GetAllBodyweightRequest), e);
            }
        }
    }
}