using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Domain.Enum;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.Users.GetUser
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

                    default:
                        throw new NotImplementedException($"This account type does not exist: {request.AccountType}");
                }
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(ApplicationUser), request.Id, e);
            }
        }

        private async Task<ApplicationUser> GetCoach(GetUserRequest request)
        {
            var coach = await _context.Coaches.SingleAsync(x => x.Id == request.Id);
            return _mapper.Map<ApplicationUser>(coach);
        }

        private async Task<ApplicationUser> GetAthlete(GetUserRequest request)
        {
            var athlete = await _context.Athletes.SingleAsync(x => x.Id == request.Id);
            return _mapper.Map<ApplicationUser>(athlete);
        }

        private async Task<ApplicationUser> GetSoloAthlete(GetUserRequest request)
        {
            var soloAthlete = await _context.SoloAthletes.SingleAsync(x => x.Id == request.Id);
            return _mapper.Map<ApplicationUser>(soloAthlete);
        }
    }
}
