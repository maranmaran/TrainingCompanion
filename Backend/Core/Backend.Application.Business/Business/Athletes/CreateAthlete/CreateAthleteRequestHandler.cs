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
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Backend.Application.Business.Business.Users.CreateUser;

namespace Backend.Application.Business.Business.Athletes.CreateAthlete
{
    public class CreateAthleteRequestHandler : IRequestHandler<CreateAthleteRequest, CreateAthleteRequestResponse>
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

        public async Task<CreateAthleteRequestResponse> Handle(CreateAthleteRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // map and save user
                var athlete = _mapper.Map<CreateAthleteRequest, Athlete>(request);
                _context.Athletes.Add(athlete);
                await _context.SaveChangesAsync(cancellationToken);

                // send mail to complete registration
                await _emailService.SendEmailAsync(GetRegistrationEmailMessage(athlete), cancellationToken);

                // return data
                return _mapper.Map<Athlete, CreateAthleteRequestResponse>(athlete);
            }
            catch (Exception e)
            {
                if (e is ExtendedException exception)
                {
                    throw exception;
                }

                throw new CreateFailureException(nameof(Athlete), e);
            }
        }

        private void Validate(CreateAthleteRequest request)
        {
            if (_context.Athletes.Any(x => x.Username == request.Username))
            {
                throw new ExtendedException((int)CreateUserValidationStatusCodes.UsernameExists, "This username is already taken.");
            }
            if (_context.Athletes.Any(x => x.Email == request.Email))
            {
                throw new ExtendedException((int)CreateUserValidationStatusCodes.EmailExists, "This email is already taken.");
            }
        }

        private EmailMessage GetRegistrationEmailMessage(Athlete athlete)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                       "/Assets/EmailTemplates/NewAthleteRegisterTemplate.html";
            var logoPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                           "/Assets/EmailTemplates/Images/logo.jpg";

            var bodyBuilder = new BodyBuilder();

            var logoImage = bodyBuilder.LinkedResources.Add(logoPath);
            logoImage.ContentId = MimeUtils.GenerateMessageId();

            var templateBody = File.ReadAllText(path);

            templateBody = templateBody.Replace("{{coachId}}", athlete.CoachId.ToString());
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
