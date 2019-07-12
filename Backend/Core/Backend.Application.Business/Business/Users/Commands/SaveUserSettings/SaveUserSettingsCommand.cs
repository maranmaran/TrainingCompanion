using Backend.Domain;
using Backend.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Service.Infrastructure.Exceptions;

namespace Backend.Application.Business.Business.Users.Commands.SaveUserSettings
{
    public class SaveUserSettingsCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public UserSettings UserSettings { get; set; }
    }

    public class SaveUserSettingsCommandHandler : IRequestHandler<SaveUserSettingsCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public SaveUserSettingsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SaveUserSettingsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _context.UserSettings.Update(request.UserSettings);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new UpdateFailureException($"Could not save user settings for user {request.Id}", e);
            }
        }
    }
}
