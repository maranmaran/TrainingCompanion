using Backend.Business.Dashboard.Models;
using Backend.Business.Users.UsersRequests.GetUser;
using Backend.Domain.Entities.Auditing;
using Backend.Domain.Enum;
using Backend.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Backend.Business.Dashboard
{
    public class FeedAuditCoordinator : IAuditCoordinator
    {
        private readonly IHubContext<FeedHub, IFeedHub> _hub;
        private readonly IMediator _mediator;
        public FeedAuditCoordinator(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            _hub = provider.GetService<IHubContext<FeedHub, IFeedHub>>();
            _mediator = provider.GetService<IMediator>();

        }

        public async Task Push(AuditRecord audit)
        {
            var activity = new Activity()
            {
                Date = audit.Date,
                Type = (ActivityType)Enum.Parse(typeof(ActivityType), audit.EntityType, true),
                UserId = audit.UserId,
                UserName = (await _mediator.Send(new GetUserRequest(audit.UserId, AccountType.User))).FullName
            };

            // TODO: Send only to person of interest
            await _hub.Clients.All.PushFeedActivity(activity);
        }
    }
}
