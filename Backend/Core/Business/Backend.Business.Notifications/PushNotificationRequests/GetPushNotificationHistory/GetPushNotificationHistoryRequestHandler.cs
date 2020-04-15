using Backend.Common;
using Backend.Domain;
using Backend.Domain.Entities.Notification;
using Backend.Infrastructure.Exceptions;
using Backend.Library.AmazonS3.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Business.Notifications.PushNotificationRequests.GetPushNotificationHistory
{
    public class GetPushNotificationHistoryRequestHandler : IRequestHandler<GetPushNotificationHistoryRequest, IEnumerable<Notification>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IS3Service _s3Service;

        public GetPushNotificationHistoryRequestHandler(IApplicationDbContext context, IS3Service s3Service)
        {
            _context = context;
            _s3Service = s3Service;
        }

        public async Task<IEnumerable<Notification>> Handle(GetPushNotificationHistoryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var notifications = await _context.Notifications
                        .Include(x => x.Sender)
                        .Where(x => x.ReceiverId == request.UserId)
                        .OrderByDescending(x => x.SentAt)
                        .Skip(request.Page * request.PageSize)
                        .Take(request.PageSize).ToListAsync(cancellationToken);

                return await RefreshAvatars(notifications);
            }
            catch (Exception e)
            {
                throw new FetchFailureException(nameof(IEnumerable<Notification>), e);
            }
        }

        private async Task<IEnumerable<Notification>> RefreshAvatars(IEnumerable<Notification> notifications)
        {
            try
            {
                var list = notifications.ToList();
                var s3Avatars = list.Where(x => !string.IsNullOrWhiteSpace(x.SenderAvatar) && !GenericAvatarConstructor.IsGenericAvatar(x.SenderAvatar)); // must be s3 then if not generic
                foreach (var s3Avatar in s3Avatars)
                {
                    s3Avatar.SenderAvatar = await _s3Service.GetPresignedUrlAsync(s3Avatar.SenderAvatar);
                }

                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Could not refresh notification sender avatar", e);
            }
        }
    }
}