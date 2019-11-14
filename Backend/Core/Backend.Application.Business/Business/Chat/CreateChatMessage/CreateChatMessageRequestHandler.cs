using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.Chat;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Chat.CreateChatMessage
{
    public class CreateChatMessageRequestHandler : AsyncRequestHandler<CreateChatMessageRequest>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateChatMessageRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected override async Task Handle(CreateChatMessageRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var newChatMessage = _mapper.Map<CreateChatMessageRequest, ChatMessage>(request);

                _context.ChatMessages.Add(newChatMessage);

                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(ChatMessage), e);
            }
        }
    }
}
