using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain.Entities.User;
using Backend.Domain.Enum;
using Backend.Service.Email;
using Backend.Service.Email.Interfaces;
using Backend.Service.Email.Models;
using MediatR;
using MimeKit;
using MimeKit.Utils;

namespace Backend.Business.Authorization.AuthorizationRequests.SendRegistrationEmail
{
    public class SendRegistrationEmailRequestHandler : IRequestHandler<SendRegistrationEmailRequest, Unit>
    {
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly EmailSettings _emailSettings;

        public SendRegistrationEmailRequestHandler(IEmailService emailService, EmailSettings emailSettings, IMapper mapper)
        {
            _emailService = emailService;
            _emailSettings = emailSettings;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(SendRegistrationEmailRequest request, CancellationToken cancellationToken)
        {
            try
            {
                EmailMessage message;

                switch (request.AccountType)
                {
                    case AccountType.Athlete:

                        message = GetRegistrationEmailMessage(request.Athlete);
                        break;

                    case AccountType.Coach:

                        message = GetRegistrationEmailMessage(request.Coach);
                        break;

                    case AccountType.SoloAthlete:

                        message = GetRegistrationEmailMessage(request.SoloAthlete);
                        break;

                    default:
                        throw new NotImplementedException($"This account type does not exist: {request.AccountType}");
                }

                if (message == null) throw new NullReferenceException("Email message cannot be null");

                await _emailService.SendEmailAsync(message, cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Could not send registration email for {request.AccountType}", e);
            }
        }

        private EmailMessage GetRegistrationEmailMessage(Athlete athlete)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                       "/Assets/EmailTemplates/Registration/Athlete/NewAthleteRegisterTemplate - Development.html";
            var logoPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                           "/Assets/EmailTemplates/Images/logo.jpg";

            var bodyBuilder = new BodyBuilder();

            var logoImage = bodyBuilder.LinkedResources.Add(logoPath);
            logoImage.ContentId = MimeUtils.GenerateMessageId();

            var templateBody = File.ReadAllText(path);

            templateBody = templateBody.Replace("{{coachName}}", athlete.Coach.FullName);
            templateBody = templateBody.Replace("{{athleteId}}", athlete.Id.ToString());
            templateBody = templateBody.Replace("{{imageContentId}}", logoImage.ContentId);

            bodyBuilder.HtmlBody = templateBody;

            var message = new EmailMessage()
            {
                To = athlete.Email,
                Body = bodyBuilder.ToMessageBody(),
                From = _emailSettings.Username,
                Title = "Training companion welcomes you !"
            };

            return message;
        }

        private EmailMessage GetRegistrationEmailMessage(SoloAthlete soloAthlete)
        {
            //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
            //           "/Assets/EmailTemplates/NewAthleteRegisterTemplate - Development.html";
            //var logoPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
            //               "/Assets/EmailTemplates/Images/logo.jpg";

            //var bodyBuilder = new BodyBuilder();

            //var logoImage = bodyBuilder.LinkedResources.Add(logoPath);
            //logoImage.ContentId = MimeUtils.GenerateMessageId();

            //var templateBody = File.ReadAllText(path);

            //templateBody = templateBody.Replace("{{coachName}}", athlete.Coach.FullName);
            //templateBody = templateBody.Replace("{{athleteId}}", athlete.Id.ToString());
            //templateBody = templateBody.Replace("{{imageContentId}}", logoImage.ContentId);

            //bodyBuilder.HtmlBody = templateBody;

            //var message = new EmailMessage()
            //{
            //    To = athlete.Email,
            //    Body = bodyBuilder.ToMessageBody(),
            //    From = _emailSettings.Username,
            //    Title = "Training companion welcomes you !"
            //};

            return new EmailMessage();
        }

        private EmailMessage GetRegistrationEmailMessage(Coach coach)
        {
            //var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
            //           "/Assets/EmailTemplates/NewAthleteRegisterTemplate - Development.html";
            //var logoPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
            //               "/Assets/EmailTemplates/Images/logo.jpg";

            //var bodyBuilder = new BodyBuilder();

            //var logoImage = bodyBuilder.LinkedResources.Add(logoPath);
            //logoImage.ContentId = MimeUtils.GenerateMessageId();

            //var templateBody = File.ReadAllText(path);

            //templateBody = templateBody.Replace("{{coachName}}", athlete.Coach.FullName);
            //templateBody = templateBody.Replace("{{athleteId}}", athlete.Id.ToString());
            //templateBody = templateBody.Replace("{{imageContentId}}", logoImage.ContentId);

            //bodyBuilder.HtmlBody = templateBody;

            //var message = new EmailMessage()
            //{
            //    To = athlete.Email,
            //    Body = bodyBuilder.ToMessageBody(),
            //    From = _emailSettings.Username,
            //    Title = "Training companion welcomes you !"
            //};

            return new EmailMessage();
        }
    }
}