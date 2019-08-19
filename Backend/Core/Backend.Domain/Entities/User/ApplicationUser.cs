﻿using Backend.Domain.Entities.Chat;
using Backend.Domain.Entities.ExerciseType.Properties;
using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.TrainingLog;
using Backend.Domain.Enum;
using System;
using System.Collections.Generic;
using BarPosition = Backend.Domain.Entities.ExerciseType.Properties.BarPosition;
using BarType = Backend.Domain.Entities.ExerciseType.Properties.BarType;
using Grip = Backend.Domain.Entities.ExerciseType.Properties.Grip;
using LoadAccomodation = Backend.Domain.Entities.ExerciseType.Properties.LoadAccomodation;
using RangeOfMotion = Backend.Domain.Entities.ExerciseType.Properties.RangeOfMotion;
using Stance = Backend.Domain.Entities.ExerciseType.Properties.Stance;
using Tempo = Backend.Domain.Entities.ExerciseType.Properties.Tempo;

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

        public Guid? UserSettingsId { get; set; }
        public virtual UserSettings UserSettings { get; set; } = new UserSettings();

        public virtual ICollection<ChatMessage> ChatMessages { get; set; } = new HashSet<ChatMessage>();
        public virtual ICollection<MediaFile> MediaFiles { get; set; } = new HashSet<MediaFile>();
        public virtual ICollection<Training> Trainings { get; set; } = new HashSet<Training>();
        public virtual ICollection<ExerciseType.ExerciseType> ExerciseTypes { get; set; } = new HashSet<ExerciseType.ExerciseType>();

        /// <summary>
        /// Exercise types properties
        /// Exists and can be defined on User level
        /// TODO: Coach should be in charge of this properties for himself and his athletes (on athlete level actually).
        /// TODO: Coach athletes shouldn't really touch these.
        /// TODO: Solo athletes have full rights to edit this properties.
        /// </summary>
        public virtual ICollection<BarPosition> BarPositions { get; set; } = new HashSet<BarPosition>();
        public virtual ICollection<BarType> BarTypes { get; set; } = new HashSet<BarType>();
        public virtual ICollection<ExerciseCategory> ExerciseCategories { get; set; } = new HashSet<ExerciseCategory>();
        public virtual ICollection<ExerciseEquipment> ExerciseEquipments { get; set; } = new HashSet<ExerciseEquipment>();
        public virtual ICollection<Grip> Grips { get; set; } = new HashSet<Grip>();
        public virtual ICollection<LoadAccomodation> LoadAccomodations { get; set; } = new HashSet<LoadAccomodation>();
        public virtual ICollection<Stance> Stances { get; set; } = new HashSet<Stance>();
        public virtual ICollection<RangeOfMotion> RangeOfMotions { get; set; } = new HashSet<RangeOfMotion>();
        public virtual ICollection<Tempo> Tempos { get; set; } = new HashSet<Tempo>();
    }
}
