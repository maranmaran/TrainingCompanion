using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain.Entities.Chat;

namespace Backend.Application.Business.Business.Chat.SendChatMessage
{
    public class SendChatMessageRequestHandler : IRequestHandler<SendChatMessageRequest, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SendChatMessageRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(SendChatMessageRequest request, CancellationToken cancellationToken)
        {
            try
            {
                //save to db
                await _context.ChatMessages.AddAsync(_mapper.Map<ChatMessage>(request), cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(e.Message, e);
            }
        }
    }
}