using Backend.Domain;
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

namespace Backend.Business.Email.Requests.RegistrationEmail
{
    public class RegistrationEmailRequestHandler : IRequestHandler<RegistrationEmailRequest, Unit>
    {
        private readonly IEmailService _emailService;
        private readonly EmailSettings _emailSettings;
        private readonly AppSettings _appSettings;

        public RegistrationEmailRequestHandler(IEmailService emailService, EmailSettings emailSettings, AppSettings appSettings)
        {
            _emailService = emailService;
            _emailSettings = emailSettings;
            _appSettings = appSettings;
        }

        public async Task<Unit> Handle(RegistrationEmailRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                           "/Assets/EmailTemplates/Registration/AthleteRegistrationTemplate.html";
                var logoPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                               "/Assets/EmailTemplates/Images/logo.jpg";

                var bodyBuilder = new BodyBuilder();

                var logoImage = bodyBuilder.LinkedResources.Add(logoPath);
                logoImage.ContentId = MimeUtils.GenerateMessageId();

                var templateBody = File.ReadAllText(path);

                templateBody = templateBody.Replace("{{userId}}", request.User.Id.ToString());
                templateBody = templateBody.Replace("{{imageContentId}}", logoImage.ContentId);
                templateBody = templateBody.Replace("{{frontendDomain}}", _appSettings.FrontendDomain);

                bodyBuilder.HtmlBody = templateBody;

                // TODO: Something else beside hardcoded title
                var message = new EmailMessage()
                {
                    To = request.User.Email,
                    Body = bodyBuilder.ToMessageBody(),
                    From = _emailSettings.Username,
                    Title = "Training companion welcomes you !"
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