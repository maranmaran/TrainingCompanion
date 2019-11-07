﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities.Notification;
using Backend.Service.Infrastructure.Exceptions;
using MediatR;

namespace Backend.Application.Business.Business.PushNotification.GetPushNotificationHistory
{
    public class GetPushNotificationHistoryRequestHandler : IRequestHandler<GetPushNotificationHistoryRequest, IQueryable<Notification>>
    {
        private readonly IApplicationDbContext _context;

        public GetPushNotificationHistoryRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Notification>> Handle(GetPushNotificationHistoryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return await Task.FromResult(_context.Notifications
                        .Where(x => x.ReceiverId == request.UserId)
                        .Skip(request.Page * request.PageSize)
                        .Take(request.PageSize));
            }
            catch (Exception e)
            {
                throw new FetchFailureException(nameof(IEnumerable<Notification>), e);
            }
        }
    }
}