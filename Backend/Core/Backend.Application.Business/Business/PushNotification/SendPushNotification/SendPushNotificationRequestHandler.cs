using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Application.Business.Business.PushNotification.CreatePushNotification;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace Backend.Application.Business.Business.PushNotification.SendPushNotification
{
    public class SendPushNotificationRequestHandler : IRequestHandler<SendPushNotificationRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IHubContext<PushNotificationHub, IPushNotificationHub> _hubContext;
        private readonly IMediator _mediator;

        public SendPushNotificationRequestHandler(IMapper mapper, IHubContext<PushNotificationHub, IPushNotificationHub> hubContext, IMediator mediator)
        {
            _mapper = mapper;
            _hubContext = hubContext;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(SendPushNotificationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var newNotificationRequest = _mapper.Map<SendPushNotificationRequest, CreatePushNotificationRequest>(request);
                
                var notification = await _mediator.Send(newNotificationRequest, cancellationToken);
                
                await _hubContext.Clients.All.SendNotification(notification);
                
                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new CreateFailureException($"Could not save notification", ex);
            }
        }
    }
}