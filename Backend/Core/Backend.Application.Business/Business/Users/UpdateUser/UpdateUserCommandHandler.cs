using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Domain.Enum;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Users.UpdateUser
{
    public class UpdateUserRequestHandler : IRequestHandler<UpdateUserRequest>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateUserRequestHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                switch (request.AccountType)
                {
                    case AccountType.Coach:
                        await UpdateCoach(request);
                        break;

                    case AccountType.Athlete:
                        await UpdateAthlete(request);
                        break;

                    case AccountType.SoloAthlete:
                        await UpdateSoloAthlete(request);
                        break;

                    default:
                        throw new NotImplementedException($"This account type does not exist: {request.AccountType}");
                }

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new UpdateFailureException(nameof(ApplicationUser), request.Id, e);
            }
        }

        private async Task UpdateCoach(UpdateUserRequest request)
        {
            var coach = await _context.Coaches.SingleAsync(x => x.Id == request.Id);

            _mapper.Map<UpdateUserRequest, Coach>(request, coach);

            _context.Coaches.Update(coach);
            await _context.SaveChangesAsync();
        }

        private async Task UpdateAthlete(UpdateUserRequest request)
        {
            var athlete = await _context.Athletes.SingleAsync(x => x.Id == request.Id);

            _mapper.Map<UpdateUserRequest, Athlete>(request, athlete);

            _context.Athletes.Update(athlete);
            await _context.SaveChangesAsync();
        }

        private async Task UpdateSoloAthlete(UpdateUserRequest request)
        {
            var soloAthlete = await _context.SoloAthletes.SingleAsync(x => x.Id == request.Id);

            _mapper.Map<UpdateUserRequest, SoloAthlete>(request, soloAthlete);

            _context.SoloAthletes.Update(soloAthlete);
            await _context.SaveChangesAsync();
        }
    }
}
