using System;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities.Notification;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Business.Business.PushNotification.ReadNotification
{
    public class ReadNotificationRequestHandler: IRequestHandler<ReadNotificationRequest, Unit>
    {

        private readonly IApplicationDbContext _context;

        public ReadNotificationRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ReadNotificationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var notification = await _context.Notifications.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
                
                if(notification == null) throw new NotFoundException(nameof(Notification), request.Id);

                notification.Read = true;
                _context.Notifications.Update(notification);
                
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception e)
            {
                throw new UpdateFailureException(nameof(ReadNotificationRequest), request.Id, e);
            }
        }
    }
}