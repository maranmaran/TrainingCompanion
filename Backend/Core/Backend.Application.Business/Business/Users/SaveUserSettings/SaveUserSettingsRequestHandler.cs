using Backend.Domain;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain.Entities;
using Backend.Domain.Entities.User;

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