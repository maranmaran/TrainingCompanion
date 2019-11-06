
using System.IO;
using Backend.Domain;
using Backend.Domain.Entities.Chat;
using Backend.Domain.Entities.ExerciseType;
using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.Notification;
using Backend.Domain.Entities.System;
using Backend.Domain.Entities.TrainingLog;
using Backend.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

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
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<MediaFile> MediaFiles { get; set; }
        public DbSet<SystemException> SystemExceptions { get; set; }

        #region Exercise type + Properties

        public DbSet<ExerciseType> ExerciseTypes { get; set; }
        public DbSet<TagGroup> TagGroups { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ExerciseTypeTag> ExerciseTypeTags { get; set; } // JOIN TABLE


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

    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {


        public ApplicationDbContextFactory()
        {
            
        }

        //TODO: Revisit this hardcoded conn string
        // Used only for EF.NET Core CLI tools(update database / migrations etc.)
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\mssqllocaldb;Initial Catalog=api_database;Integrated Security=True");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
