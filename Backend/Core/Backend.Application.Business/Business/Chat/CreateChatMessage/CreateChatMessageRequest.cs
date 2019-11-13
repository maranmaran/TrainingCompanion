using Amazon.Runtime.Internal;
using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.Chat;
using Backend.Domain.Enum;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Application.Business.Business.Chat.CreateChatMessage
{
    public class CreateChatMessageRequest: IRequest<Unit>
    {
        public string Message { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public DateTime SentAt { get; set; }
        public MessageType Type { get; set; }
        public DateTime SeenAt { get; set; }
        public string DownloadUrl { get; set; }
        public string S3Filename { get; set; }
        public string FileSizeInBytes { get; set; }
    }

    public class CreateChatMessageRequestHandler : IRequestHandler<CreateChatMessageRequest, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateChatMessageRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateChatMessageRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var newChatMessage = _mapper.Map<CreateChatMessageRequest, ChatMessage>(request);

                _context.ChatMessages.Add(newChatMessage);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(ChatMessage), e);
            }
        }
    }
}
