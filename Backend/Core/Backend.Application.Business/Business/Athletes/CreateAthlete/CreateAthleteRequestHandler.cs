using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities;
using Backend.Service.Email;
using Backend.Service.Email.Interfaces;
using Backend.Service.Email.Models;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using MimeKit;
using MimeKit.Utils;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Backend.Common;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.Athletes.CreateAthlete
{
    public class CreateAthleteRequestHandler : IRequestHandler<CreateAthleteRequest, Athlete>
    {
        private readonly IApplicationDbContext _context;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly EmailSettings _emailSettings;

        public CreateAthleteRequestHandler(
            IApplicationDbContext context,
            IMapper mapper,
            IEmailService emailService, EmailSettings emailSettings)
        {
            _context = context;
            _mapper = mapper;
            _emailService = emailService;
            _emailSettings = emailSettings;
        }

        public async Task<Athlete> Handle(CreateAthleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // map and save user
                var athlete = _mapper.Map<CreateAthleteRequest, Athlete>(request);

                _context.Athletes.Add(athlete);
                await _context.SaveChangesAsync(cancellationToken);

                // send mail to complete registration
                athlete.Coach = await _context.Coaches.SingleAsync(x => x.Id == athlete.CoachId, cancellationToken);
                await _emailService.SendEmailAsync(GetRegistrationEmailMessage(athlete), cancellationToken);

                // return data
                return athlete;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Athlete), e);
            }
        }

        private EmailMessage GetRegistrationEmailMessage(Athlete athlete)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                       "/Assets/EmailTemplates/NewAthleteRegisterTemplate - Development.html";
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
    }
}
