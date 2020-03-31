using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Business.Chat.Models;
using Backend.Domain;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.Chat.ChatRequests.GetChatHistory
{
    public class GetChatHistoryFullRequestHandler : IRequestHandler<GetChatHistoryFullRequest, IEnumerable<MessageViewModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetChatHistoryFullRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MessageViewModel>> Handle(GetChatHistoryFullRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var chatMessages = await _context
                    .ChatMessages
                    .Where(x => (x.SenderId == request.UserId && x.ReceiverId == request.ReceiverId)
                                || (x.SenderId == request.ReceiverId && x.ReceiverId == request.UserId))
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                return _mapper.Map<IEnumerable<MessageViewModel>>(chatMessages);
            }
            catch (Exception e)
            {
                throw new NotFoundException("No chat history found.", e);
            }
        }
    }
}