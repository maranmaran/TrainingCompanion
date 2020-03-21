using Audit.Core;
using Audit.EntityFramework;
using Backend.Business.Dashboard;
using Backend.Business.Notifications;
using Backend.Business.Users.AthleteRequests.Get;
using Backend.Business.Users.UsersRequests.GetUser;
using Backend.Domain.Entities.Auditing;
using Backend.Domain.Entities.Exercises;
using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.ProgressTracking;
using Backend.Domain.Entities.TrainingLog;
using Backend.Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Configuration = Audit.Core.Configuration;

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
                    .AuditEntityAction<AuditRecord>(async (ev, entry, audit) =>
                    {
                        MapToAudit(ev, entry, audit);

                        var mediator = services.BuildServiceProvider().GetService<IMediator>();
                        var user = await mediator.Send(new GetUserRequest(audit.UserId, AccountType.User));

                        var feedAuditCoordinator = new FeedAuditCoordinator(services, mediator);
                        var notificationAuditCoordinator = new NotificationsAuditCoordinator(services);
                        if (user.AccountType == AccountType.Athlete)
                        {
                            var athlete = await mediator.Send(new GetAthleteRequest(user.Id));
                            await feedAuditCoordinator.PushToCoach(audit, athlete);
                            await notificationAuditCoordinator.PushToCoach(audit, athlete);
                        }
                    })
                    .IgnoreMatchedProperties(true));
        }

        /// <summary>
        /// Maps audit event and entry to AuditRecord entity for DB
        /// </summary>
        private static void MapToAudit(AuditEvent ev, EventEntry entry, AuditRecord audit)
        {
            Guid.TryParse(ev.CustomFields["UserId"].ToString(), out var userId);
            audit.UserId = userId;
            audit.Data = entry.ToJson();
            audit.EntityType = entry.EntityType.Name;
            audit.Date = DateTime.Now;
            audit.PrimaryKey = entry.PrimaryKey.First().Value.ToString();
            audit.Table = entry.Table;
            audit.Action = entry.Action;
            audit.Date = DateTime.Now;
        }
    }
}
