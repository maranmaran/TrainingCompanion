using AutoMapper;
using Backend.Business.Notifications.PushNotification.CreatePushNotification;
using Backend.Business.Notifications.PushNotification.SendPushNotification;
using Backend.Domain.Entities.Notification;

namespace Backend.Business.Notifications
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<CreatePushNotificationRequest, Notification>();
            CreateMap<SendPushNotificationRequest, CreatePushNotificationRequest>();
        }
    }
}
