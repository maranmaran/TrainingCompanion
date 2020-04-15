using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.Notification;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Notifications.PushNotificationRequests.CreatePushNotification
{
    public class CreatePushNotificationRequestHandler : IRequestHandler<CreatePushNotificationRequest, Notification>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreatePushNotificationRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Notification> Handle(CreatePushNotificationRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var newNotification = _mapper.Map<CreatePushNotificationRequest, Notification>(request);

                // get sender avatar if we have one                
                var avatar = string.Empty;
                if (request.SenderId.HasValue)
                    avatar = (await _context.Users.FirstOrDefaultAsync(x => x.Id == request.SenderId.Value, cancellationToken)).Avatar;
                newNotification.SenderAvatar = avatar;

                _context.Notifications.Add(newNotification);
                await _context.SaveChangesAsync(cancellationToken);

                _context.Entry(newNotification).Reference(x => x.Sender).Load();
                _context.Entry(newNotification).Reference(x => x.Receiver).Load();

                return newNotification;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Notification), e);
            }
        }
    }
}