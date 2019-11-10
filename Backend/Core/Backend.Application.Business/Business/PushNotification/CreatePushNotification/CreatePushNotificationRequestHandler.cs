using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.Notification;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Application.Business.Business.PushNotification.CreatePushNotification
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

                _context.Notifications.Add(newNotification);
                await _context.SaveChangesAsync(cancellationToken);

                _context.Entry(newNotification).Reference(x => x.Sender).Load();
                _context.Entry(newNotification).Reference(x => x.Receiver).Load();
                _context.Entry(newNotification.Receiver).Reference(x => x.UserSetting).Load();
                _context.Entry(newNotification.Receiver.UserSetting).Collection(x => x.NotificationSettings).Load();

                return newNotification;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Notification), e);
            }
          
        }
    }
}