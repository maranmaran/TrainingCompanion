
using Backend.Domain.Entities.Chat;
using Backend.Domain.Entities.ExerciseType;
using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.System;
using Backend.Domain.Entities.TrainingLog;
using Backend.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain.Entities.Notification;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Backend.Domain
{
    public interface IApplicationDbContext
    {
        DbSet<ApplicationUser> Users { get; set; }
        DbSet<Coach> Coaches { get; set; }
        DbSet<Athlete> Athletes { get; set; }
        DbSet<SoloAthlete> SoloAthletes { get; set; }
        DbSet<UserSetting> UserSettings { get; set; }
        DbSet<NotificationSetting> NotificationSetting{ get; set; }
        DbSet<ChatMessage> ChatMessages { get; set; }
        DbSet<Notification> Notifications { get; set; }
        DbSet<MediaFile> MediaFiles { get; set; }
        DbSet<SystemException> SystemExceptions { get; set; }

        #region Exercise type + Properties

        DbSet<ExerciseType> ExerciseTypes { get; set; }
        DbSet<TagGroup> TagGroups { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<ExerciseTypeTag> ExerciseTypeTags { get; set; } // JOIN TABLE

        #endregion

        #region Training log

        DbSet<Training> Trainings { get; set; }
        DbSet<Exercise> Exercises { get; set; }
        DbSet<Set> Sets { get; set; } // lifts

        #endregion

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
