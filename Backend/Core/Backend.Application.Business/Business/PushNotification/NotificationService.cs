﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Backend.Application.Business.Extensions;
using Backend.Domain.Entities.Notification;
using Backend.Domain.Entities.User;
using Backend.Service.Email.Interfaces;
using Backend.Service.Email.Models;
using MailKit;
using Microsoft.AspNetCore.SignalR;
using MimeKit;
using MimeKit.Utils;

namespace Backend.Application.Business.Business.PushNotification
{
    public class NotificationService: INotificationService
    {
        private readonly IHubContext<PushNotificationHub, IPushNotificationHub> _hubContext;
        private readonly IEmailService _emailService;

        public NotificationService(IHubContext<PushNotificationHub, IPushNotificationHub> hubContext, IEmailService emailService)
        {
            _hubContext = hubContext;
            _emailService = emailService;
        }

        public async Task NotifyUser(Notification notification, IEnumerable<NotificationSetting> settings, CancellationToken cancellationToken)
        {
            var notificationSetting = settings.First(x => x.NotificationType == notification.Type);

            await SendMail(notification, cancellationToken, notificationSetting);

            await SendNotification(notification, notificationSetting);
        }

        private async Task SendNotification(Notification notification, NotificationSetting notificationSetting)
        {
            try
            {
                // send notification
                if (notificationSetting.ReceiveNotification)
                {
                    // TODO: Send to receiver.. not all, put cancellation token
                    await _hubContext.Clients.All.SendNotification(notification);
                }
            }
            catch (Exception e)
            {
                // log
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
                // log
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
