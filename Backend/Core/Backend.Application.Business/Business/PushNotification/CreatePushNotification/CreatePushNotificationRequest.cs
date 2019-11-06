using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Domain;
using Backend.Domain.Entities.Notification;
using Backend.Domain.Enum;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Application.Business.Business.PushNotification.CreatePushNotification
{
    public class CreatePushNotificationRequest: IRequest<Notification>
    {
        public NotificationType Type { get; set; }
        public string Payload { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }

        public CreatePushNotificationRequest()
        {
            
        }

        public CreatePushNotificationRequest(NotificationType type, string payload, Guid senderId, Guid receiverId)
        {
            this.Type = type;
            this.Payload = payload;
            this.SenderId = senderId;
            this.ReceiverId = receiverId;
        }

    }

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

                return newNotification;
            }
            catch (Exception e)
            {
                throw new CreateFailureException(nameof(Notification), e);
            }
          
        }
    }
}
