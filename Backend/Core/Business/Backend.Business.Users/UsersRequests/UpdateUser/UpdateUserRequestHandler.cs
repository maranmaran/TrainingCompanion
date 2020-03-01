using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.Users.UsersRequests.UpdateUser
{
    public class UpdateUserRequestHandler : IRequestHandler<UpdateUserRequest, ApplicationUser>
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

        public async Task<ApplicationUser> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                switch (request.AccountType)
                {
                    case AccountType.Coach:
                        return await UpdateCoach(request);

                    case AccountType.Athlete:
                        return await UpdateAthlete(request);

                    case AccountType.SoloAthlete:
                        return await UpdateSoloAthlete(request);

                    default:
                        throw new NotImplementedException($"This account type does not exist: {request.AccountType}");
                }
            }
            catch (Exception e)
            {
                throw new UpdateFailureException(nameof(ApplicationUser), request.Id, e);
            }
        }

        private async Task<ApplicationUser> UpdateCoach(UpdateUserRequest request)
        {
            var coach = await _context.Coaches.SingleAsync(x => x.Id == request.Id);

            _mapper.Map<UpdateUserRequest, Coach>(request, coach);

            _context.Coaches.Update(coach);
            await _context.SaveChangesAsync();

            return _mapper.Map<ApplicationUser>(coach);
        }

        private async Task<ApplicationUser> UpdateAthlete(UpdateUserRequest request)
        {
            var athlete = await _context.Athletes.SingleAsync(x => x.Id == request.Id);

            _mapper.Map<UpdateUserRequest, Athlete>(request, athlete);

            _context.Athletes.Update(athlete);
            await _context.SaveChangesAsync();

            return _mapper.Map<ApplicationUser>(athlete);
        }

        private async Task<ApplicationUser> UpdateSoloAthlete(UpdateUserRequest request)
        {
            var soloAthlete = await _context.SoloAthletes.SingleAsync(x => x.Id == request.Id);

            _mapper.Map<UpdateUserRequest, SoloAthlete>(request, soloAthlete);

            _context.SoloAthletes.Update(soloAthlete);
            await _context.SaveChangesAsync();

            return _mapper.Map<ApplicationUser>(soloAthlete);
        }
    }
}