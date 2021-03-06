﻿using Backend.Domain;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Users.UsersRequests.DeleteUser
{
    public class DeleteUserRequestHandler : IRequestHandler<DeleteUserRequest, Unit>
    {
        private readonly IApplicationDbContext _context;

        public DeleteUserRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                switch (request.AccountType)
                {
                    case AccountType.Coach:

                        await DeleteCoach(request, cancellationToken);
                        break;

                    case AccountType.Athlete:

                        await DeleteAthlete(request, cancellationToken);
                        break;

                    case AccountType.SoloAthlete:

                        await DeleteSoloAthlete(request, cancellationToken);
                        break;

                    default:
                        throw new NotImplementedException($"This account type doesn't have delete implemented: {request.AccountType}");
                }

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new DeleteFailureException(nameof(ApplicationUser), request.Id, e);
            }
        }

        private async Task DeleteCoach(DeleteUserRequest request, CancellationToken cancellationToken = default)
        {
            var coach = await _context.Coaches.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            if (coach == null)
                throw new NotFoundException(nameof(Coach), request.Id);

            _context.Coaches.Remove(coach);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task DeleteAthlete(DeleteUserRequest request, CancellationToken cancellationToken = default)
        {
            // get athlete and it's coach
            var athlete = await _context
                .Athletes
                .Include(x => x.Coach)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (athlete == null)
                throw new NotFoundException(nameof(Athlete), request.Id);

            // remove athlete from coach, then remove athlete completely
            _context.Athletes.Remove(athlete);

            await _context.SaveChangesAsync(cancellationToken);
        }

        private async Task DeleteSoloAthlete(DeleteUserRequest request, CancellationToken cancellationToken = default)
        {
            // get athlete and it's coach
            var soloAthlete = await _context
                .SoloAthletes
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (soloAthlete == null)
                throw new NotFoundException(nameof(SoloAthlete), request.Id);

            _context.SoloAthletes.Remove(soloAthlete);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}