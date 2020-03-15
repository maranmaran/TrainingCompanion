using AutoMapper;
using Backend.Common;
using Backend.Domain;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Library.AmazonS3.Interfaces;

namespace Backend.Business.Users.UsersRequests.GetAllUsers
{
    public class GetAllUsersRequestHandler : IRequestHandler<GetAllUsersRequest, IEnumerable<ApplicationUser>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IS3Service _s3Service;

        public GetAllUsersRequestHandler(IApplicationDbContext context, IMapper mapper, IS3Service s3Service)
        {
            _context = context;
            _mapper = mapper;
            _s3Service = s3Service;
        }

        public async Task<IEnumerable<ApplicationUser>> Handle(GetAllUsersRequest request, CancellationToken cancellationToken)
        {
            try
            {
                switch (request.AccountType)
                {
                    case AccountType.Coach:

                        return await RefreshAvatars(GetAllCoaches(), cancellationToken);

                    case AccountType.Athlete:

                        return await RefreshAvatars(GetAllAthletes(request.CoachId), cancellationToken);

                    case AccountType.SoloAthlete:

                        return await RefreshAvatars(GetAllSoloAthletes(), cancellationToken);

                    default:
                        throw new NotImplementedException($"This account type does not exist: {request.AccountType}");
                }
            }
            catch (Exception e)
            {
                throw new NotFoundException(nameof(ApplicationUser), "Something went wrong fetching users", e);
            }
        }

        private async Task<IEnumerable<ApplicationUser>> RefreshAvatars(IQueryable<ApplicationUser> response, CancellationToken cancellationToken = default)
        {
            var list = await response.ToListAsync(cancellationToken);

            var s3Avatars = list.Where(x => GenericAvatarConstructor.IsGenericAvatar(x.Avatar) == false); // must be s3 then if not generic
            foreach (var s3Avatar in s3Avatars)
            {
                s3Avatar.Avatar = await _s3Service.GetPresignedUrlAsync(s3Avatar.Avatar);
            }

            return list;
        }

        private IQueryable<ApplicationUser> GetAllCoaches()
        {
            return _context.Coaches;
        }

        private IQueryable<ApplicationUser> GetAllSoloAthletes()
        {
            return _context.SoloAthletes;
        }

        private IQueryable<ApplicationUser> GetAllAthletes(Guid coachId)
        {
            var athletes = _context.Athletes;

            if (coachId != Guid.Empty)
            {
                return athletes.Where(x => x.CoachId == coachId);
            }

            return athletes;
        }
    }
}