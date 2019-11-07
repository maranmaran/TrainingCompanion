﻿using Backend.Application.Business.Business.PushNotification.GetPushNotificationHistory;
using Backend.Application.Business.Business.PushNotification.SendPushNotification;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Backend.API.Controllers
{
    public class PushNotificationsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> SendPushNotification([FromBody] SendPushNotificationRequest request)
        {
            return Ok(await Mediator.Send(request));
        }


        //TODO: Add sieve model for paging this
        [HttpGet("{userId}/{page}/{pageSize}")]
        public async Task<IActionResult> GetPushNotificationHistory(Guid userId, int page, int pageSize)
        {
            return await GetQuery(
                async () => await Mediator.Send(new GetPushNotificationHistoryRequest(userId, page, pageSize)), 
                null
            );
        }

    }
}
