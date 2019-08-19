using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Backend.Domain.Entities.Chat;
using Backend.Domain.Entities.Media;
using Backend.Domain.Entities.System;
using Backend.Domain.Entities.User;

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

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
