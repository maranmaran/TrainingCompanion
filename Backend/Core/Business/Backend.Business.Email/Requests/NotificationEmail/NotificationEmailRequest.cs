using Backend.Domain.Entities.Notification;
using MediatR;

namespace Backend.Business.Email.Requests.NotificationEmail
{
    public class NotificationEmailRequest : IRequest<Unit>
    {
        public NotificationEmailRequest(Notification notification)
        {
            Notification = notification;
        }

        public Notification Notification { get; set; }
    }
}