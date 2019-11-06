using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Application.Business.Business.PushNotification.CreatePushNotification;
using Backend.Domain.Entities.Notification;
using Backend.Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Backend.Application.Business.Business.PushNotification
{
    public interface IPushNotificationHub
    {
        Task SendNotification(Notification notification);
        Task GetHistory(IEnumerable<Notification> notifications);
    }

    [Authorize]
    public class PushNotificationHub : Hub<IPushNotificationHub>
    {
        private readonly IMediator _mediator;

        public PushNotificationHub(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task SendNotification(NotificationType type, string payload, Guid senderId, Guid receiverId)
        {

            // save to db
            var notification = await _mediator.Send(new CreatePushNotificationRequest(type, payload, senderId, receiverId));

            // send
            //await Clients.User(receiverId.ToString()).SendNotification(type, payload, senderId);
            await Clients.All.SendNotification(notification);
        }


    }
}
