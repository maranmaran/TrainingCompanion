using Backend.Domain;
using Backend.Domain.Entities.Chat;
using Backend.Domain.Entities.ExerciseType;
using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.System;
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
        public DbSet<ExerciseTypeProperty> ExerciseTypeProperties { get; set; }

        public DbSet<Grip> Grips { get; set; }
        public DbSet<Tempo> Tempos { get; set; }
        public DbSet<Stance> Stances { get; set; }
        public DbSet<LoadAccomodation> LoadAccomodations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<BarType> BarTypes { get; set; }
        public DbSet<BarPosition> BarPositions { get; set; }
        public DbSet<RangeOfMotion> RangeOfMotions { get; set; }

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
