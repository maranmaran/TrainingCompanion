using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Application.Business.Business.Users.SaveUserSettings
{
    public class SaveUserSettingsRequestHandler : IRequestHandler<SaveUserSettingsRequest, Unit>
    {
        private readonly IApplicationDbContext _context;

        public SaveUserSettingsRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(SaveUserSettingsRequest request, CancellationToken cancellationToken)
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