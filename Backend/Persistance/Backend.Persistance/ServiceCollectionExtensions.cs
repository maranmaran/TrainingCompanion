using Audit.Core;
using Audit.EntityFramework;
using Backend.Business.Dashboard;
using Backend.Business.Notifications;
using Backend.Domain.Entities.Auditing;
using Backend.Domain.Entities.Exercises;
using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.ProgressTracking;
using Backend.Domain.Entities.TrainingLog;
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
                        audit = entry.MapToAudit(ev);

                        // push feed
                        var feedAuditCoordinator = new FeedAuditCoordinator(services);
                        await feedAuditCoordinator.Push(audit);

                        // notify
                        var notificationAuditCoordinator = new NotificationsAuditCoordinator(services);
                        await notificationAuditCoordinator.Push(audit);
                    })
                    .IgnoreMatchedProperties(true));
        }

        /// <summary>
        /// Maps audit event and entry to AuditRecord entity for DB
        /// </summary>
        private static AuditRecord MapToAudit(this EventEntry entry, AuditEvent ev)
        {
            var entity = new AuditRecord();

            Guid.TryParse(ev.CustomFields["UserId"].ToString(), out var userId);
            entity.UserId = userId;
            entity.Data = entry.ToJson();
            entity.EntityType = entry.EntityType.Name;
            entity.Date = DateTime.Now;
            entity.PrimaryKey = entry.PrimaryKey.First().Value.ToString();
            entity.Table = entry.Table;
            entity.Action = entry.Action;
            entity.Date = DateTime.Now;

            return entity;
        }
    }
}
