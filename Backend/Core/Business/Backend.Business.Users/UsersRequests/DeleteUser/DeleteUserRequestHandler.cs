using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.Users.UsersRequests.DeleteUser
{
    public class DeleteUserRequestHandler : IRequestHandler<DeleteUserRequest, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteUserRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<Unit> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                switch (request.AccountType)
                {
                    case AccountType.Coach:

                        DeleteCoach(request);
                        break;

                    case AccountType.Athlete:

                        DeleteAthlete(request);
                        break;

                    case AccountType.SoloAthlete:

                        DeleteSoloAthlete(request);
                        break;

                    default:
                        throw new NotImplementedException($"This account type does not exist: {request.AccountType}");
                }

                return Task.FromResult(Unit.Value);
            }
            catch (Exception e)
            {
                throw new DeleteFailureException(nameof(ApplicationUser), request.Id, e);
            }
        }

        private async void DeleteCoach(DeleteUserRequest request)
        {
            var coach = await _context.Coaches.SingleAsync(u => u.Id == request.Id);

            _context.Coaches.Remove(coach);

            await _context.SaveChangesAsync();
        }

        private async void DeleteAthlete(DeleteUserRequest request)
        {
            // get athlete and it's coach
            var athlete = await _context
                .Athletes
                .Include(x => x.Coach)
                .SingleAsync(x => x.Id == request.Id);

            var coach = athlete.Coach;

            // remove athlete from coach, then remove athlete completely
            coach.Athletes.Remove(athlete);
            _context.Athletes.Remove(athlete);

            await _context.SaveChangesAsync();
        }

        private async void DeleteSoloAthlete(DeleteUserRequest request)
        {
            // get athlete and it's coach
            var soloAthlete = await _context
                .SoloAthletes
                .SingleAsync(x => x.Id == request.Id);

            _context.SoloAthletes.Remove(soloAthlete);

            await _context.SaveChangesAsync();
        }
    }
}