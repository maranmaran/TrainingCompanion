using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Backend.Library.Email.Interfaces;
using Backend.Library.Email.Models;
using MediatR;
using MimeKit;
using MimeKit.Utils;

namespace Backend.Business.Email.Requests.NotificationEmail
{
    public class NotificationEmailRequestHandler : IRequestHandler<NotificationEmailRequest, Unit>
    {
        private readonly IEmailService _emailService;

        public NotificationEmailRequestHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task<Unit> Handle(NotificationEmailRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                           $"/Assets/EmailTemplates/Notification/NotificationTemplate.html";
                var logoPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                               "/Assets/EmailTemplates/Images/logo.jpg";

                var bodyBuilder = new BodyBuilder();

                var logoImage = bodyBuilder.LinkedResources.Add(logoPath);
                logoImage.ContentId = MimeUtils.GenerateMessageId();

                var templateBody = File.ReadAllText(path);

                templateBody = templateBody.Replace("{{type}}", request.Notification.Type.GetNotificationTypeTranslation());
                templateBody = templateBody.Replace("{{senderName}}", request.Notification.Sender.FullName);
                templateBody = templateBody.Replace("{{date}}", request.Notification.SentAt.ToString("dd/MM/yyyy"));

                bodyBuilder.HtmlBody = templateBody;

                var message = new EmailMessage()
                {
                    To = request.Notification.Receiver.Email,
                    From = request.Notification.Sender.Email,
                    Title = $"[NOTIFICATION] {request.Notification.Sender.FullName} {request.Notification.Type.GetNotificationTypeTranslation()}",
                    Body = bodyBuilder.ToMessageBody()
                };

                await _emailService.SendEmailAsync(message, cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new Exception("Could not send notification email", e);
            }
        }
    }
}