using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Business.ProgressTracking.PersonalBestRequests.GetAll
{
    public class GetAllPersonalBestRequestHandler : IRequestHandler<GetAllPersonalBestRequest, IQueryable<Domain.Entities.ProgressTracking.PersonalBest>>
    {
        private readonly IApplicationDbContext _context;


        public GetAllPersonalBestRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }


        public Task<IQueryable<Domain.Entities.ProgressTracking.PersonalBest>> Handle(GetAllPersonalBestRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var entities = _context.PBs.Where(x => x.ExerciseTypeId == request.ExerciseTypeId);
                return Task.FromResult(entities);
            }
            catch (Exception e)
            {
                throw new FetchFailureException(nameof(GetAllPersonalBestRequest), e);
            }
        }
    }
}