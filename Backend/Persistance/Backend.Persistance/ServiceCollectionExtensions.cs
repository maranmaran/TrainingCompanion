using Audit.Core;
using Backend.Business.Dashboard;
using Backend.Business.Dashboard.Models;
using Backend.Business.Users.UsersRequests.GetUser;
using Backend.Domain.Entities.Auditing;
using Backend.Domain.Entities.Exercises;
using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.ProgressTracking;
using Backend.Domain.Entities.TrainingLog;
using Backend.Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Backend.Persistance
{
    public static partial class ServiceCollectionExtensions
    {

        //TODO Move all this to Dashboard project..because thats BoundedContext for FEED
        public static void ConfigureAuditEfCore(this IServiceCollection services)
        {
            Audit.EntityFramework.Configuration.Setup()
                .ForContext<ApplicationDbContext>(config => config
                    .IncludeEntityObjects()
                    .AuditEventType("{context}:{database}"))
                .UseOptIn()
                .Include<Training>()
                .Include<ExerciseType>()
                .Include<MediaFile>()
                .Include<Bodyweight>()
                .Include<PersonalBest>();


            // Audit.EntityFrameworkCore offers more granulated approach
            // Special mappings and one table per entity.. Audit_TrainingLog
            // Or putting all eggs in one basket
            // For now we'll put all eggs in one basket.. (for feed)
            Configuration.AddCustomAction(ActionType.OnScopeCreated, scope =>
            {
                var serviceProvider = services.BuildServiceProvider();
                var ctxAccessor = serviceProvider.GetService<IHttpContextAccessor>();
                var userId = ctxAccessor?.HttpContext?.User?.Identity?.Name;

                scope.SetCustomField("UserId", userId);
            });

            Configuration.Setup()
                .UseEntityFramework(_ => _
                    .AuditTypeMapper(t => typeof(AuditRecord))
                    .AuditEntityAction<AuditRecord>(async (ev, entry, entity) =>
                   {
                       //TODO method for mapping

                       Guid.TryParse(ev.CustomFields["UserId"].ToString(), out var userId);
                       entity.UserId = userId;

                       entity.Data = entry.ToJson();
                       entity.EntityType = entry.EntityType.Name;
                       entity.Date = DateTime.Now;
                       entity.PrimaryKey = entry.PrimaryKey.First().Value.ToString();
                       entity.Table = entry.Table;
                       entity.Action = entry.Action;
                       entity.Date = DateTime.Now;


                       //TODO method for pushing to feed in real time
                       var provider = services.BuildServiceProvider();
                       var ctx = provider.GetService<IHttpContextAccessor>();
                       var hub = ctx.HttpContext.RequestServices.GetRequiredService<IHubContext<FeedHub, IFeedHub>>();
                       var mediator = ctx.HttpContext.RequestServices.GetRequiredService<IMediator>();

                       var activity = new Activity()
                       {
                           Date = entity.Date,
                           Type = (ActivityType)Enum.Parse(typeof(ActivityType), entity.EntityType, true),
                           UserId = entity.UserId,
                           UserName = (await mediator.Send(new GetUserRequest(entity.UserId, AccountType.Athlete))).FullName
                       };

                       await hub.Clients.All.PushFeedActivity(activity);
                   })
                    .IgnoreMatchedProperties(true));
        }
    }
}
