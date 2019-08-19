using Backend.Domain.Entities.Chat;
using Backend.Domain.Entities.ExerciseType;
using Backend.Domain.Entities.ExerciseType.Properties;
using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.System;
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

        DbSet<Grip> Grips { get; set; }
        DbSet<Tempo> Tempos { get; set; }
        DbSet<Stance> Stances { get; set; }
        DbSet<LoadAccomodation> LoadAccomodations { get; set; }
        DbSet<ExerciseEquipment> ExerciseEquipments { get; set; }
        DbSet<ExerciseCategory> ExerciseCategories { get; set; }
        DbSet<BarType> BarTypes { get; set; }
        DbSet<BarPosition> BarPositions { get; set; }
        DbSet<RangeOfMotion> RangeOfMotions { get; set; }

        #endregion

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
