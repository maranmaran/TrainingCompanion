using AutoMapper;
using Backend.Business.Chat.Models;
using Backend.Domain;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using Backend.Infrastructure.Exceptions;
using Backend.Library.AmazonS3.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Chat.ChatRequests.GetFriendList
{
    public class GetFriendsListRequestHandler : IRequestHandler<GetFriendsListRequest, IEnumerable<ParticipantResponseViewModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IS3Service _s3Service;
        private readonly IMediator _mediator;

        public GetFriendsListRequestHandler(IApplicationDbContext context, IMapper mapper, IS3Service s3Service, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _s3Service = s3Service;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ParticipantResponseViewModel>> Handle(GetFriendsListRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var friendList = new List<ParticipantResponseViewModel>();

                switch (request.AccountType)
                {
                    case AccountType.Admin:

                        // all users
                        var adminFriends = await _context.Users.Where(x => x.Id != request.UserId).ToListAsync(cancellationToken);

                        friendList.AddRange(_mapper.Map<HashSet<ParticipantResponseViewModel>>(adminFriends));
                        break;

                    case AccountType.Coach:

                        // only athletes are reachable to coach
                        var coachFriends = (await _context.Coaches.Include(x => x.Athletes).FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken))?.Athletes;

                        if (coachFriends != null)
                        {
                            friendList.AddRange(_mapper.Map<HashSet<ParticipantResponseViewModel>>(coachFriends));
                        }
                        break;

                    case AccountType.Athlete:

                        // only coach is reachable to athlete
                        var athleteFriend = (ApplicationUser)(await _context.Athletes.Include(x => x.Coach).FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken))?.Coach;

                        if (athleteFriend != null)
                        {
                            friendList.Add(_mapper.Map<ParticipantResponseViewModel>(athleteFriend));
                        }

                        break;

                    default:
                        throw new InvalidEnumArgumentException();
                }

                // admin is available to all
                var admin = await _context.Users.FirstOrDefaultAsync(x => x.AccountType == AccountType.Admin, cancellationToken);
                if (admin != null)
                {
                    friendList.Add(_mapper.Map<ParticipantResponseViewModel>(admin));
                }

                GetUnreadMessages(request.UserId, friendList);
                return friendList;
            }
            catch (Exception e)
            {
                throw new NotFoundException("No friends were found to add to list", e);
            }
        }

        private void GetUnreadMessages(Guid userId, IEnumerable<ParticipantResponseViewModel> friends)
        {
            foreach (var friend in friends)
            {
                friend.Metadata = new ParticipantMetadataViewModel();
                friend.Metadata.TotalUnreadMessages = _context.ChatMessages
                    .Where(x => x.ReceiverId == userId && x.SenderId == Guid.Parse(friend.Participant.Id))
                    .Count(x => x.SeenAt == null);
            }
        }
    }
}