using Backend.Domain.Entities.Chat;
using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.ProgressTracking;
using Backend.Domain.Entities.TrainingLog;
using Backend.Domain.Enum;
using System;
using System.Collections.Generic;
using TagGroup = Backend.Domain.Entities.ExerciseType.TagGroup;

namespace Backend.Domain.Entities.User
{
    public class ApplicationUser
    {

        public Guid Id { get; set; }
        public string CustomerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public string Avatar { get; set; }
        public Gender Gender { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime LastModified { get; set; }

        public bool Active { get; set; }

        public AccountType AccountType { get; set; }
        public int TrialDuration { get; set; }

        public Guid UserSettingId { get; set; }
        public virtual UserSetting UserSetting { get; set; }

        public virtual ICollection<ChatMessage> ChatMessages { get; set; } = new HashSet<ChatMessage>();
        public virtual ICollection<Notification.Notification> SentNotifications { get; set; } = new HashSet<Notification.Notification>();
        public virtual ICollection<Notification.Notification> ReceivedNotifications { get; set; } = new HashSet<Notification.Notification>();
        public virtual ICollection<MediaFile> MediaFiles { get; set; } = new HashSet<MediaFile>();
        public virtual ICollection<ExerciseType.ExerciseType> ExerciseTypes { get; set; } = new HashSet<ExerciseType.ExerciseType>();
        public virtual ICollection<Training> Trainings { get; set; } = new HashSet<Training>();
        public virtual ICollection<Bodyweight> Bodyweights { get; set; } = new HashSet<Bodyweight>();

        /// <summary>
        /// Exercise types properties
        /// Exists and can be defined on ApplicationUser level
        /// TODO: Coach should be in charge of this properties for himself and his athletes (on athlete level actually).
        /// TODO: Coach athletes shouldn't really touch these.
        /// TODO: Solo athletes have full rights to edit this properties.
        /// </summary>
        public virtual ICollection<TagGroup> TagGroups { get; set; } = new HashSet<TagGroup>();
    }
}