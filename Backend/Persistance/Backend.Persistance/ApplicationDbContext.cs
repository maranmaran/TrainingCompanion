using Backend.Domain;
using Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<SystemException> SystemExceptions { get; set; }

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
