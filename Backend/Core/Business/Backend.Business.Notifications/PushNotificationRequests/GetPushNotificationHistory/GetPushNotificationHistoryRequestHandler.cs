﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain;
using Backend.Domain.Entities.Notification;
using Backend.Infrastructure.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business.Notifications.PushNotificationRequests.GetPushNotificationHistory
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
                        .Include(x => x.Sender)
                        .Where(x => x.ReceiverId == request.UserId)
                        .OrderByDescending(x => x.SentAt)
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