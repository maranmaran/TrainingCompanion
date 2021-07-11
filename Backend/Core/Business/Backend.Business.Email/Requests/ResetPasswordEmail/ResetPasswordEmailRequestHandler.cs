using Backend.Library.Email;
using Backend.Library.Email.Interfaces;
using Backend.Library.Email.Models;
using MediatR;
using MimeKit;
using MimeKit.Utils;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Email.Requests.ResetPasswordEmail
{
    public class ResetPasswordEmailRequestHandler : IRequestHandler<ResetPasswordEmailRequest, Unit>
    {
        private readonly IEmailService _emailService;
        private readonly EmailSettings _emailSettings;

        public ResetPasswordEmailRequestHandler(IEmailService emailService, EmailSettings emailSettings)
        {
            _emailService = emailService;
            _emailSettings = emailSettings;
        }

        public async Task<Unit> Handle(ResetPasswordEmailRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                           "/Assets/EmailTemplates/Reset/ResetPassword.html";
                var logoPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                               "/Assets/EmailTemplates/Images/logo.jpg";

                var bodyBuilder = new BodyBuilder();

                var logoImage = bodyBuilder.LinkedResources.Add(logoPath);
                logoImage.ContentId = MimeUtils.GenerateMessageId();

                var templateBody = File.ReadAllText(path);

                templateBody = templateBody.Replace("{{userName}}", request.User.FullName);
                templateBody = templateBody.Replace("{{userId}}", request.User.Id.ToString());
                templateBody = templateBody.Replace("{{imageContentId}}", logoImage.ContentId);

                bodyBuilder.HtmlBody = templateBody;

                var message = new EmailMessage()
                {
                    To = request.User.Email,
                    Body = bodyBuilder.ToMessageBody(),
                    From = _emailSettings.Username,
                    Title = "Training companion - Reset password"
                };

                await _emailService.SendEmailAsync(message, cancellationToken);
                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new Exception("Could not send reset password email", e);
            }
        }
    }
}