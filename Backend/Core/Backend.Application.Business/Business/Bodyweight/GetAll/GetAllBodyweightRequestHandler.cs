using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Application.Business.Business.Bodyweight.GetAll
{
    public class GetAllBodyweightRequestHandler : IRequestHandler<GetAll.GetAllBodyweightRequest, IQueryable<Domain.Entities.ProgressTracking.Bodyweight.Bodyweight>>
    {
        private readonly IApplicationDbContext _context;


        public GetAllBodyweightRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }


        public Task<IQueryable<Domain.Entities.ProgressTracking.Bodyweight.Bodyweight>> Handle(GetAll.GetAllBodyweightRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var entities = _context.Bodyweights.Where(x => x.UserId == request.UserId);
                return Task.FromResult(entities);
            }
            catch (Exception e)
            {
                throw new FetchFailureException(nameof(GetAll.GetAllBodyweightRequest), e);
            }
        }
    }
}