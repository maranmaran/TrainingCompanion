using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.Athletes.SetActiveAthlete
{
    public class SetActiveRequestHandler: IRequestHandler<SetActiveAthleteRequest, Unit>
    {
        private readonly IApplicationDbContext _context;
        public SetActiveRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SetActiveAthleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var athlete = await _context.Athletes.SingleAsync(x => x.Id == request.Id, cancellationToken);
                athlete.Active = request.Value;

                _context.Athletes.Update(athlete);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Could not set active: {request.Value} state on athlete: {request.Id}", e);
            }
        }
    }
}
