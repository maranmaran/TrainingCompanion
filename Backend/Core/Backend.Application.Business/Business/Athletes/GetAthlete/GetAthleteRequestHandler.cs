using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.Athletes.GetAthlete
{
    public class GetAthleteRequestHandler : IRequestHandler<GetAthleteRequest, Athlete>
    {
        private readonly IApplicationDbContext _context;

        public GetAthleteRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Athlete> Handle(GetAthleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var athlete = await _context.Athletes.SingleAsync(appAthlete => appAthlete.Id == request.AthleteId, cancellationToken);

                return athlete;
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(Athlete), request.AthleteId, e);
            }
        }
    }
}
