using AutoMapper;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain.Enum;
using Microsoft.AspNetCore.SignalR;

namespace Backend.Application.Business.Business.PushNotification.SendPushNotification
{
    public class SendPushNotificationRequest : IRequest<Unit>
    {
        //public PushNotificationType Type { get; set; }
        //public string Payload { get; set; }
        //public DateTime SentAt { get; set; } = DateTime.UtcNow;

        //TODO: Expand this tought with some ids.. and participants messages etc..
        //Types... someone added new training (who, profile picture, click on message leads to impersonification of profile and viewing of training
    }

    public class SendPushNotificationRequestHandler : IRequestHandler<SendPushNotificationRequest, Unit>
    {
        private IApplicationDbContext _context;
        private IMapper _mapper;
        private IHubContext<PushNotificationHub, IPushNotificationHub> _hubContext;

        public SendPushNotificationRequestHandler(IApplicationDbContext context, IMapper mapper, IHubContext<PushNotificationHub, IPushNotificationHub> hubContext)
        {
            _context = context;
            _mapper = mapper;
            _hubContext = hubContext;
        }

        //TODO: Write this to DB
        public async Task<Unit> Handle(SendPushNotificationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                //await 
                //await _hubContext.Clients.All.SendNotification();
                //await _context.Notifications.Add();
                //await _context.SavechangesAsync();
                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new CreateFailureException($"Could not save notification", ex);
            }
        }
    }
}
