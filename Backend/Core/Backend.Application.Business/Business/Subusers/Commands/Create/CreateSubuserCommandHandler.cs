using AutoMapper;
using Backend.Domain.Entities;
using Backend.Service.Email;
using MediatR;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Service.Email.Interfaces;
using Backend.Service.Email.Models;
using Backend.Service.Infrastructure.Exceptions;

namespace Backend.Application.Business.Business.Subusers.Commands.Create
{
    public class CreateSubuserCommandHandler : IRequestHandler<CreateSubuserCommand, CreateSubuserResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly EmailSettings _emailSettings;

        public CreateSubuserCommandHandler(
            IApplicationDbContext context,
            IMapper mapper,
            IEmailService emailService, EmailSettings emailSettings)
        {
            _context = context;
            _mapper = mapper;
            _emailService = emailService;
            _emailSettings = emailSettings;
        }

        public async Task<CreateSubuserResponse> Handle(CreateSubuserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // map and save user
                var user = _mapper.Map<CreateSubuserCommand, ApplicationUser>(request);
                _context.Users.Add(user);
                await _context.SaveChangesAsync(cancellationToken);

                // send mail to complete registration
                await _emailService.SendEmailAsync(GetRegistrationEmailMessage(user), cancellationToken);

                // return data
                return _mapper.Map<ApplicationUser, CreateSubuserResponse>(user);
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(ApplicationUser), e.Message);
            }
        }

        private EmailMessage GetRegistrationEmailMessage(ApplicationUser user)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                       "/Business/Subusers/Commands/Create/registrationEmailTemplate.html";

            var templateBody = File.ReadAllText(path);
            templateBody = templateBody.Replace("{{parentId}}", user.ParentId.ToString());
            templateBody = templateBody.Replace("{{subUserId}}", user.Id.ToString());

            var message = new EmailMessage()
            {
                To = user.Email,
                Body = templateBody,
                From = _emailSettings.Username,
                Title = "You have been added to application. Complete your registration !"
            };

            return message;
        }
    }
}
