using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities.User;
using Backend.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Business.Users.UsersRequests.SaveUserSettings
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
                _context.UserSettings.Update(request.UserSetting);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new UpdateFailureException(nameof(UserSetting), request.UserSetting.Id, e);
            }
        }
    }
}