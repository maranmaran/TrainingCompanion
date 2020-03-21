using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Users.UsersRequests.GetUser
{
    public class GetUserRequestHandler : IRequestHandler<GetUserRequest, ApplicationUser>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetUserRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApplicationUser> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            try
            {
                switch (request.AccountType)
                {
                    case AccountType.Coach:

                        return await GetCoach(request);

                    case AccountType.Athlete:

                        return await GetAthlete(request);

                    case AccountType.SoloAthlete:

                        return await GetSoloAthlete(request);

                    case AccountType.User:

                        return await GetGenericUser(request);

                    default:
                        throw new NotImplementedException($"This account type does not exist: {request.AccountType}");
                }
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(ApplicationUser), request.Id, e);
            }
        }

        private async Task<ApplicationUser> GetGenericUser(GetUserRequest request)
        {
            var coach = await _context.Users.FirstAsync(x => x.Id == request.Id);
            return _mapper.Map<ApplicationUser>(coach);
        }

        private async Task<ApplicationUser> GetCoach(GetUserRequest request)
        {
            var coach = await _context.Coaches.FirstAsync(x => x.Id == request.Id);
            return _mapper.Map<ApplicationUser>(coach);
        }

        private async Task<ApplicationUser> GetAthlete(GetUserRequest request)
        {
            var athlete = await _context.Athletes.FirstAsync(x => x.Id == request.Id);
            return _mapper.Map<ApplicationUser>(athlete);
        }

        private async Task<ApplicationUser> GetSoloAthlete(GetUserRequest request)
        {
            var soloAthlete = await _context.SoloAthletes.FirstAsync(x => x.Id == request.Id);
            return _mapper.Map<ApplicationUser>(soloAthlete);
        }
    }
}