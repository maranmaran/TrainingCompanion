using AutoMapper;
using Backend.Business.Notifications.PushNotificationRequests.CreatePushNotification;
using Backend.Business.Notifications.PushNotificationRequests.NotifyUser;
using Backend.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Notifications.PushNotificationRequests.SendPushNotification
{
    public class SendPushNotificationRequestHandler : IRequestHandler<SendPushNotificationRequest, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SendPushNotificationRequestHandler(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(SendPushNotificationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var newNotificationRequest = _mapper.Map<SendPushNotificationRequest, CreatePushNotificationRequest>(request);

                var notification = await _mediator.Send(newNotificationRequest, cancellationToken);

                await _mediator.Publish(new NotifyUserNotification(notification, notification.Receiver.Id), cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                throw new CreateFailureException($"Could not save notification", ex);
            }
        }
    }
}