using Backend.Business.Notifications.Extensions;
using Backend.Business.Notifications.Interfaces;
using Backend.Domain;
using Backend.Domain.Entities.Notification;
using Backend.Domain.Entities.User;
using Backend.Library.Email.Interfaces;
using Backend.Library.Email.Models;
using Backend.Library.Logging.Interfaces;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Utils;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Notifications.PushNotificationRequests.NotifyUser
{
    public class NotifyUserNotificationHandler : INotificationHandler<NotifyUserNotification>
    {
        private readonly IHubContext<PushNotificationHub, IPushNotificationHub> _hubContext;
        private readonly IEmailService _emailService;
        private readonly ILoggingService _loggingService;
        private readonly IApplicationDbContext _context;

        public NotifyUserNotificationHandler(IHubContext<PushNotificationHub, IPushNotificationHub> hubContext, IEmailService emailService, ILoggingService loggingService, IApplicationDbContext context)
        {
            _hubContext = hubContext;
            _emailService = emailService;
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
                    var message = GetNotificationEmailTemplate(notification);
                    await _emailService.SendEmailAsync(message, cancellationToken);
                }
            }
            catch (Exception e)
            {
                await _loggingService.LogError(e, $"Could not send mail to receiver: {notification.ReceiverId}");
            }
        }

        private EmailMessage GetNotificationEmailTemplate(Notification notification)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                       $"/Assets/EmailTemplates/Notification/NotificationTemplate.html";
            var logoPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                           "/Assets/EmailTemplates/Images/logo.jpg";

            var bodyBuilder = new BodyBuilder();

            var logoImage = bodyBuilder.LinkedResources.Add(logoPath);
            logoImage.ContentId = MimeUtils.GenerateMessageId();

            var templateBody = File.ReadAllText(path);

            templateBody = templateBody.Replace("{{type}}", notification.Type.GetNotificationTypeTranslation());
            templateBody = templateBody.Replace("{{senderName}}", notification.Sender.FullName);
            templateBody = templateBody.Replace("{{date}}", notification.SentAt.ToString("dd/MM/yyyy"));

            bodyBuilder.HtmlBody = templateBody;

            return new EmailMessage()
            {
                To = notification.Receiver.Email,
                From = notification.Sender.Email,
                Title = $"[NOTIFICATION] {notification.Sender.FullName} {notification.Type.GetNotificationTypeTranslation()}",
                Body = bodyBuilder.ToMessageBody()
            };
        }

    }
}