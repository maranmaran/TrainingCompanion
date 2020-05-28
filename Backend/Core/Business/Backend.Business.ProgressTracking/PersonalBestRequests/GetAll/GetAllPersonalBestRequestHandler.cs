using Backend.Domain;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.ProgressTracking.PersonalBestRequests.GetAll
{
    public class GetAllPersonalBestRequestHandler : IRequestHandler<GetAllPersonalBestRequest, IEnumerable<Domain.Entities.ProgressTracking.PersonalBest>>
    {
        private readonly IApplicationDbContext _context;


        public GetAllPersonalBestRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Domain.Entities.ProgressTracking.PersonalBest>> Handle(GetAllPersonalBestRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var entities = _context.PBs.Where(x => x.ExerciseTypeId == request.ExerciseTypeId);

                if (request.LowerRepRange.HasValue && request.UpperRepRange.HasValue)
                {
                    entities = entities.Where(x => x.Reps >= request.LowerRepRange && x.Reps <= request.UpperRepRange);
                }

                return await entities.ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                throw new FetchFailureException(nameof(GetAllPersonalBestRequest), e);
            }
        }
    }
}