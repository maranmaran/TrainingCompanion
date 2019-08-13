using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Domain.Enum;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Users.GetAllUsers
{
    public class GetAllUsersRequestHandler : IRequestHandler<GetAllUsersRequest, IQueryable<ApplicationUser>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllUsersRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<IQueryable<ApplicationUser>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            try
            {
                switch (request.AccountType)
                {
                    case AccountType.Coach:

                        return Task.FromResult(GetAllCoaches());

                    case AccountType.Athlete:

                        return Task.FromResult(GetAllAthletes(request.CoachId));

                    case AccountType.SoloAthlete:

                        return Task.FromResult(GetAllSoloAthletes());

                    default:
                        throw new NotImplementedException($"This account type does not exist: {request.AccountType}");
                }
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(ApplicationUser), "Something went wrong fetching users", e);
            }
        }

        private IQueryable<ApplicationUser> GetAllCoaches()
        {
            return _mapper.ProjectTo<ApplicationUser>(_context.Coaches);
        }

        private IQueryable<ApplicationUser> GetAllSoloAthletes()
        {
            return _mapper.ProjectTo<ApplicationUser>(_context.SoloAthletes);
        }

        private IQueryable<ApplicationUser> GetAllAthletes(Guid coachId)
        {
            if (coachId != Guid.Empty)
            {
                var athletes = _context.Athletes.Where(x => x.CoachId == coachId);
                return _mapper.ProjectTo<ApplicationUser>(athletes);
            }

            return _mapper.ProjectTo<ApplicationUser>(_context.Athletes);
        }
    }
}
