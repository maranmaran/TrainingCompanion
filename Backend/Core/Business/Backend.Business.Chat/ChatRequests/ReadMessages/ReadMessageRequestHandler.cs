using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities.Chat;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.Chat.ChatRequests.ReadMessages
{
    public class ReadMessageRequestHandler : AsyncRequestHandler<ReadMessagesRequest>
    {
        private readonly IApplicationDbContext _context;

        public ReadMessageRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        protected override async Task Handle(ReadMessagesRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var chatMessagesToUpdate = new List<ChatMessage>();
                foreach (var message in request.Messages)
                {
                    var chatMessageToUpdate = await _context.ChatMessages
                        .SingleOrDefaultAsync(
                            x => String.Equals(x.SenderId.ToString(), message.FromId, StringComparison.CurrentCultureIgnoreCase)
                                && String.Equals(x.ReceiverId.Value.ToString(), message.ToId, StringComparison.CurrentCultureIgnoreCase)
                                && x.SentAt.ToUniversalTime() == message.DateSent.Value.ToUniversalTime());

                    if (chatMessageToUpdate != null)
                    {
                        chatMessageToUpdate.SeenAt = DateTime.UtcNow;
                        chatMessagesToUpdate.Add(chatMessageToUpdate);
                    }
                }

                if (chatMessagesToUpdate.Count > 0)
                {
                    _context.ChatMessages.UpdateRange(chatMessagesToUpdate);
                    _context.SaveChangesAsync(CancellationToken.None).Wait();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Could not read messages", e);
            }
        }
    }
}