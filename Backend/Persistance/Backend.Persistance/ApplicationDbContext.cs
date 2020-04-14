using Audit.EntityFramework;
using Backend.Domain;
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
using Microsoft.EntityFrameworkCore.Design;

namespace Backend.Persistance
{
    public class ApplicationDbContext : AuditDbContext, IApplicationDbContext
    {
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Athlete> Athletes { get; set; }
        public DbSet<SoloAthlete> SoloAthletes { get; set; }
        public DbSet<UserSetting> UserSettings { get; set; }
        public DbSet<NotificationSetting> NotificationSetting { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<MediaFile> MediaFiles { get; set; }
        public DbSet<Dashboard> Dashboards { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<TrackItem> TrackItems { get; set; }
        public DbSet<SystemLog> SystemLog { get; set; }
        public DbSet<Bodyweight> Bodyweights { get; set; }
        public DbSet<PersonalBest> PBs { get; set; }
        public DbSet<AuditRecord> Audits { get; set; }

        #region Exercise type + Properties

        public DbSet<ExerciseType> ExerciseTypes { get; set; }
        public DbSet<TagGroup> TagGroups { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ExerciseTypeTag> ExerciseTypeTags { get; set; } // JOIN TABLE

        #endregion Exercise type + Properties

        #region Training log

        public DbSet<Training> Trainings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Set> Sets { get; set; } // lifts

        #endregion Training log

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // comment this if you don't want to see seed values in migrations
            //modelBuilder.Seed();

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