using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities.User;
using Backend.Service.Email;
using Backend.Service.Email.Interfaces;
using Backend.Service.Email.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Utils;

namespace Backend.Business.Authorization.AuthorizationRequests.ResetPassword
{
    public class ResetPasswordRequestHandler : IRequestHandler<ResetPasswordRequest, Unit>
    {
        private readonly IEmailService _emailService;
        private readonly IApplicationDbContext _context;
        private readonly EmailSettings _emailSettings;

        public ResetPasswordRequestHandler(IEmailService emailService, IApplicationDbContext context, EmailSettings emailSettings)
        {
            _emailService = emailService;
            _context = context;
            _emailSettings = emailSettings;
        }

        public async Task<Unit> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _context.Users.SingleAsync(x => x.Email == request.Email, cancellationToken);
                await _emailService.SendEmailAsync(GetResetPasswordEmail(user), cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Could not send reset password email to user with email {request.Email}", e);
            }
        }

        private EmailMessage GetResetPasswordEmail(ApplicationUser user)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                       "/Assets/EmailTemplates/ResetPasswordTemplate - Development.html";
            var logoPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                           "/Assets/EmailTemplates/Images/logo.jpg";

            var bodyBuilder = new BodyBuilder();

            var logoImage = bodyBuilder.LinkedResources.Add(logoPath);
            logoImage.ContentId = MimeUtils.GenerateMessageId();

            var templateBody = File.ReadAllText(path);

            templateBody = templateBody.Replace("{{userName}}", user.FullName);
            templateBody = templateBody.Replace("{{userId}}", user.Id.ToString());
            templateBody = templateBody.Replace("{{imageContentId}}", logoImage.ContentId);

            bodyBuilder.HtmlBody = templateBody;

            var message = new EmailMessage()
            {
                To = user.Email,
                Body = bodyBuilder.ToMessageBody(),
                From = _emailSettings.Username,
                Title = "Training companion - Reset password"
            };

            return message;
        }
    }
}