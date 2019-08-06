using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Athletes.GetAllAthletes
{
    public class GetAllAthletesRequestHandler : IRequestHandler<GetAllAthletesRequest, IQueryable<Athlete>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllAthletesRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Athlete>> Handle(GetAllAthletesRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.CoachId == Guid.Empty)
                {
                    return await Task.FromResult(_context.Athletes);
                }
                else
                {
                    return (await _context.Coaches.Include(x => x.Athletes).SingleAsync(x => x.Id == request.CoachId, cancellationToken)).Athletes.AsQueryable();
                }
            }
            catch (Exception e)
            {
                throw new NotFoundException("Could not get athletes.", e);
            }
        }
    }
}
