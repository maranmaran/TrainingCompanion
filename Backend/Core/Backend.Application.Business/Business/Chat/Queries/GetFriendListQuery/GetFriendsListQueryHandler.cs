using AutoMapper;
using Backend.Domain;
using Backend.Domain.Enum;
using Backend.Service.Chat.NgChatModels;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Chat.Queries.GetFriendListQuery
{
    public class GetFriendsListQueryHandler : IRequestHandler<GetFriendsListQuery, IEnumerable<ParticipantResponseViewModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetFriendsListQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ParticipantResponseViewModel>> Handle(GetFriendsListQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users
                    .Include(x => x.Parent)
                    .Include(x => x.Subusers)
                    .AsNoTracking()
                    .SingleAsync(x => x.Id == request.UserId, cancellationToken);

                var friendList = new List<ParticipantResponseViewModel>();

                var admin = await _context.Users.SingleAsync(x => x.AccountType == AccountType.Admin, cancellationToken);

                switch (user.AccountType)
                {
                    case AccountType.Admin:
                        var adminFriends = await _context.Users
                            .Where(x => x.Id != request.UserId) // all users that are not me
                            .ToListAsync(cancellationToken);

                        friendList.AddRange(_mapper.Map<HashSet<ParticipantResponseViewModel>>(adminFriends));
                        break;
                    case AccountType.User:
                        var userFriends = await _context.Users
                            .Where(x => x.Id != request.UserId && x.ParentId == request.UserId) // only subusers that are not me + admin
                            .ToListAsync(cancellationToken);
                        userFriends.Add(admin);

                        friendList.AddRange(_mapper.Map<HashSet<ParticipantResponseViewModel>>(userFriends));
                        break;
                    case AccountType.Subuser:

                        if (user.ParentId != null)
                        {
                            friendList.Add(_mapper.Map<ParticipantResponseViewModel>(admin));
                            friendList.Add(_mapper.Map<ParticipantResponseViewModel>(user.Parent));
                        } // only my parent and admin

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