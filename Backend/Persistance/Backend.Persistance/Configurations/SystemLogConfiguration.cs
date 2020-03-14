using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemLog = Backend.Domain.Entities.System.SystemLog;

namespace Backend.Persistance.Configurations
{
    public class SystemLogConfiguration : IEntityTypeConfiguration<SystemLog>
    {
        public void Configure(EntityTypeBuilder<SystemLog> builder)
        {
            builder.Property(x => x.Date).HasDefaultValueSql("getutcdate()");


        }
    }
}