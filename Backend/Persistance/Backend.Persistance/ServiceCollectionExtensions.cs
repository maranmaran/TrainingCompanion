using Audit.Core;
using Backend.Domain.Entities.Auditing;
using Backend.Domain.Entities.Exercises;
using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.ProgressTracking;
using Backend.Domain.Entities.TrainingLog;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Backend.Persistance
{
    public static partial class ServiceCollectionExtensions
    {
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
            Configuration.Setup()
                .UseEntityFramework(_ => _
                    .AuditTypeMapper(t => typeof(AuditRecord))
                    .AuditEntityAction<AuditRecord>((ev, entry, entity) =>
                    {
                        entity.Data = entry.ToJson();
                        entity.EntityType = entry.EntityType.Name;
                        entity.Date = DateTime.Now;
                        entity.User = Environment.UserName;
                        entity.PrimaryKey = entry.PrimaryKey.First().Value.ToString();
                        entity.Table = entry.Table;
                        entity.Action = entry.Action;
                        entity.Title = entity.Title;
                        entity.Date = DateTime.Now;
                    })
                    .IgnoreMatchedProperties(true));
        }
    }
}
