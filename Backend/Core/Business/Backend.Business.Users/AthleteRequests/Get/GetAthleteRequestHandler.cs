using Backend.Domain;
using Backend.Domain.Entities.User;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Users.AthleteRequests.Get
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
                var athlete = await _context.Athletes.Include(x => x.Coach).FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

                if (athlete == null)
                    throw new NotFoundException("Athlete not found", request.UserId);

                return athlete;
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(GetAthleteRequest), e);
            }
        }
    }
}