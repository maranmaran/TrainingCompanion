using Backend.Domain.Entities.Auditing;
using Backend.Domain.Entities.Chat;
using Backend.Domain.Entities.Exercises;
using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.Notification;
using Backend.Domain.Entities.ProgressTracking;
using Backend.Domain.Entities.System;
using Backend.Domain.Entities.TrainingLog;
using Backend.Domain.Entities.User;
using Backend.Domain.Entities.User.Dashboard;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Domain
{
    public interface IApplicationDbContext
    {
        DbSet<ApplicationUser> Users { get; set; }
        DbSet<Coach> Coaches { get; set; }
        DbSet<Athlete> Athletes { get; set; }
        DbSet<SoloAthlete> SoloAthletes { get; set; }
        DbSet<UserSetting> UserSettings { get; set; }
        DbSet<NotificationSetting> NotificationSetting { get; set; }
        DbSet<ChatMessage> ChatMessages { get; set; }
        DbSet<Notification> Notifications { get; set; }
        DbSet<MediaFile> MediaFiles { get; set; }
        DbSet<Dashboard> Dashboards { get; set; }
        DbSet<Track> Tracks { get; set; }
        DbSet<TrackItem> TrackItems { get; set; }
        DbSet<TrackItemParams> TrackItemParams { get; set; }
        DbSet<SystemLog> SystemLog { get; set; }
        DbSet<Bodyweight> Bodyweights { get; set; }
        DbSet<PersonalBest> PBs { get; set; }
        DbSet<AuditRecord> Audits { get; set; }



        #region Exercise type + Properties

        DbSet<ExerciseType> ExerciseTypes { get; set; }
        DbSet<TagGroup> TagGroups { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<ExerciseTypeTag> ExerciseTypeTags { get; set; } // JOIN TABLE

        #endregion Exercise type + Properties

        #region Training log

        DbSet<Training> Trainings { get; set; }
        DbSet<Exercise> Exercises { get; set; }
        DbSet<Set> Sets { get; set; } // lifts

        #endregion Training log

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}