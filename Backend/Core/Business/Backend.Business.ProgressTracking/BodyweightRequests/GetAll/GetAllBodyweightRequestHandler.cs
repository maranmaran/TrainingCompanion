using Backend.Domain;
using Backend.Domain.Entities.ProgressTracking;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.ProgressTracking.BodyweightRequests.GetAll
{
    public class GetAllBodyweightRequestHandler : IRequestHandler<GetAllBodyweightRequest, IEnumerable<Bodyweight>>
    {
        private readonly IApplicationDbContext _context;


        public GetAllBodyweightRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Bodyweight>> Handle(GetAllBodyweightRequest request, CancellationToken cancellationToken)
        {

            try
            {
                var entities = _context.Bodyweights.Where(x => x.UserId == request.UserId).OrderByDescending(x => x.Date);
                return await entities.AsNoTracking().ToListAsync(cancellationToken);
            }
            catch (Exception e)
            {
                throw new FetchFailureException(nameof(GetAllBodyweightRequest), e);
            }
        }
    }
}