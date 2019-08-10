using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Athletes.DeleteAthlete
{
    public class DeleteAthleteRequestHandler : IRequestHandler<DeleteAthleteRequest>
    {
        private readonly IApplicationDbContext _context;

        public DeleteAthleteRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteAthleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // get athlete and it's coach
                var athlete = await _context
                    .Athletes
                    .Include(x => x.Coach)
                    .SingleAsync(x => x.Id == request.AthleteId, cancellationToken);

                var coach = athlete.Coach;

                // remove athlete from coach, then remove athlete completely
                coach.Athletes.Remove(athlete);
                _context.Athletes.Remove(athlete);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new DeleteFailureException(nameof(Athlete), request.AthleteId, e);
            }
        }
    }
}
