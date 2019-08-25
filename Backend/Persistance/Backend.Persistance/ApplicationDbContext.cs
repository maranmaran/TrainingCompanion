using Backend.Domain;
using Backend.Domain.Entities.Chat;
using Backend.Domain.Entities.ExerciseType;
using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.System;
using Backend.Domain.Entities.TrainingLog;
using Backend.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<SoloAthlete> SoloAthletes { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<MediaFile> MediaFiles { get; set; }
        public DbSet<SystemException> SystemExceptions { get; set; }

        #region Exercise type + Properties

        public DbSet<ExerciseType> ExerciseTypes { get; set; }
        public DbSet<ExercisePropertyType> ExercisePropertyTypes { get; set; }
        public DbSet<ExerciseProperty> ExerciseProperties { get; set; }
        public DbSet<ExerciseTypeExerciseProperty> ExerciseTypeExerciseProperties { get; set; } // JOIN TABLE


        #endregion

        #region Training log

        public DbSet<Training> Trainings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Set> Sets { get; set; } // lifts

        #endregion

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }


    }
}
