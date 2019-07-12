using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Application.Business.Business.Chat.Commands.SendChatMessageCommand
{
    public class SendChatMessageCommandHandler : IRequestHandler<SendChatMessageCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SendChatMessageCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(SendChatMessageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                //save to db
                _context.ChatMessages.Add(_mapper.Map<ChatMessage>(request));
                await _context.SaveChangesAsync(cancellationToken);

                //switch (request.Type)
                //{
                //    case MessageType.GroupChat:
                //        await _hubContext
                //            .Clients
                //            .Group(request.ChatRoomId.ToString())
                //            .SendChatMessage(request.Type.ToString(), request.Message);

                //        break;

                //    case MessageType.PrivateChat:

                //        await _hubContext
                //            .Clients
                //            .User(request.ReceiverId.ToString())
                //            .SendChatMessage(request.Type.ToString(), request.Message);

                //        break;

                //    default:
                //        throw new ArgumentOutOfRangeException();
                //}

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(e.Message, e);
            }
        }
    }
}