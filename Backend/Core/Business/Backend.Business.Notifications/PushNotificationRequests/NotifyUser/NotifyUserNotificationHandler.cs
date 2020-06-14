using Backend.Business.Email.Requests.NotificationEmail;
using Backend.Business.Notifications.Interfaces;
using Backend.Domain;
using Backend.Domain.Entities.Notification;
using Backend.Domain.Entities.User;
using Backend.Library.Logging.Interfaces;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Notifications.PushNotificationRequests.NotifyUser
{
    public class NotifyUserNotificationHandler : INotificationHandler<NotifyUserNotification>
    {
        private readonly IHubContext<PushNotificationHub, IPushNotificationHub> _hubContext;
        private readonly IMediator _mediator;
        private readonly ILoggingService _loggingService;
        private readonly IApplicationDbContext _context;

        public NotifyUserNotificationHandler(IHubContext<PushNotificationHub, IPushNotificationHub> hubContext, IMediator mediator, ILoggingService loggingService, IApplicationDbContext context)
        {
            _hubContext = hubContext;
            _mediator = mediator;
            _loggingService = loggingService;
            _context = context;
        }

        public async Task Handle(NotifyUserNotification request, CancellationToken cancellationToken)
        {
            var notificationSetting = (await _context.UserSettings.Include(x => x.NotificationSettings).FirstOrDefaultAsync(x => x.ApplicationUserId == request.UserId, cancellationToken)).NotificationSettings.First(x => x.NotificationType == request.Notification.Type);

            await SendMail(request.Notification, cancellationToken, notificationSetting);

            await SendNotification(request.Notification, notificationSetting);
        }


        private async Task SendNotification(Notification notification, NotificationSetting notificationSetting)
        {
            try
            {
                // send notification
                if (notificationSetting.ReceiveNotification && notification.ReceiverId.HasValue)
                {
                    await _hubContext.Clients.User(notification.ReceiverId.Value.ToString()).SendNotification(notification);
                }
            }
            catch (Exception e)
            {
                await _loggingService.LogError(e, $"Could not send notification to receiver: {notification.ReceiverId}");
            }
        }

        private async Task SendMail(Notification notification, CancellationToken cancellationToken,
            NotificationSetting notificationSetting)
        {
            try
            {
                // send mail
                if (notificationSetting.ReceiveMail)
                {
                    await _mediator.Send(new NotificationEmailRequest(notification), cancellationToken);
                }
            }
            catch (Exception e)
            {
                await _loggingService.LogError(e, $"Could not send mail to receiver: {notification.ReceiverId}");
            }
        }

    }
}