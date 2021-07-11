using AutoMapper;
using Backend.Business.Chat.Models;
using Backend.Domain;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Chat.ChatRequests.GetChatHistoryPaged
{
    public class GetChatHistoryPagedRequestHandler : IRequestHandler<GetChatHistoryPagedRequest, IEnumerable<MessageViewModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetChatHistoryPagedRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MessageViewModel>> Handle(GetChatHistoryPagedRequest request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.PageSize == 0)
                    request.PageSize = 10;

                var chatMessages = (await _context
                    .ChatMessages
                    .Where(x => (x.SenderId == request.UserId && x.ReceiverId == request.ReceiverId)
                                || (x.SenderId == request.ReceiverId && x.ReceiverId == request.UserId))
                    .AsNoTracking()
                    .ToListAsync(cancellationToken))
                    .SkipLast(request.Page * request.PageSize)
                    .TakeLast(request.PageSize);

                return _mapper.Map<IEnumerable<MessageViewModel>>(chatMessages);
            }
            catch (Exception e)
            {
                throw new NotFoundException("No chat history found.", e);
            }
        }
    }
}