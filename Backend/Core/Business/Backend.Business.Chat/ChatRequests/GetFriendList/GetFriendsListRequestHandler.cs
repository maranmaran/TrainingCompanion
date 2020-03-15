using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Business.Chat.Models;
using Backend.Domain;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.Chat.ChatRequests.GetFriendList
{
    public class GetFriendsListRequestHandler : IRequestHandler<GetFriendsListRequest, IEnumerable<ParticipantResponseViewModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetFriendsListRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ParticipantResponseViewModel>> Handle(GetFriendsListRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var friendList = new List<ParticipantResponseViewModel>();
                var admin = await _context.Users.SingleOrDefaultAsync(x => x.AccountType == AccountType.Admin,
                    cancellationToken); // admin is available to all

                switch (request.AccountType)
                {
                    case AccountType.Admin:

                        // all users
                        var adminFriends = await _context.Users.Where(x => x.Id != request.UserId).ToListAsync(cancellationToken);

                        friendList.AddRange(_mapper.Map<HashSet<ParticipantResponseViewModel>>(adminFriends));
                        break;

                    case AccountType.Coach:

                        // only athletes are reachable to coach
                        var coachFriends = (await _context.Coaches.Include(x => x.Athletes).SingleAsync(x => x.Id == request.UserId, cancellationToken)).Athletes;

                        friendList.AddRange(_mapper.Map<HashSet<ParticipantResponseViewModel>>(coachFriends));
                        friendList.Add(_mapper.Map<ParticipantResponseViewModel>(admin));
                        break;

                    case AccountType.Athlete:

                        // only coach is reachable to athlete
                        var athleteFriend = (ApplicationUser)(await _context.Athletes.Include(x => x.Coach).SingleAsync(x => x.Id == request.UserId, cancellationToken)).Coach;

                        friendList.Add(_mapper.Map<ParticipantResponseViewModel>(athleteFriend));
                        friendList.Add(_mapper.Map<ParticipantResponseViewModel>(admin));
                        break;

                    default:
                        throw new InvalidEnumArgumentException();
                }

                return friendList;
            }
            catch (Exception e)
            {
                throw new NotFoundException("No friends were found to add to list", e);
            }
        }
    }
}