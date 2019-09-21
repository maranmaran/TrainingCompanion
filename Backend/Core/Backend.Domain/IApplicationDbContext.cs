﻿using Backend.Domain.Entities.Chat;
using Backend.Domain.Entities.ExerciseType;
using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.System;
using Backend.Domain.Entities.TrainingLog;
using Backend.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
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
        DbSet<UserSettings> UserSettings { get; set; }
        DbSet<ChatMessage> ChatMessages { get; set; }
        DbSet<MediaFile> MediaFiles { get; set; }
        DbSet<SystemException> SystemExceptions { get; set; }

        #region Exercise type + Properties

        DbSet<ExerciseType> ExerciseTypes { get; set; }
        DbSet<TagGroup> TagGroups { get; set; }
        DbSet<Tag> ExerciseProperties { get; set; }
        DbSet<ExerciseTypeTag> ExerciseTypeExerciseProperties { get; set; } // JOIN TABLE

        #endregion

        #region Training log

        DbSet<Training> Trainings { get; set; }
        DbSet<Exercise> Exercises { get; set; }
        DbSet<Set> Sets { get; set; } // lifts

        #endregion

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
