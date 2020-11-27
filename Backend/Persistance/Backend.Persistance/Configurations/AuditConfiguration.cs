using Backend.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations
{
    public class AuditConfiguration : IEntityTypeConfiguration<AuditRecord>
    {
        public void Configure(EntityTypeBuilder<AuditRecord> builder)
        {
            builder.HasIndex(x => x.UserId);
            builder.HasIndex(x => x.PrimaryKey);

            //builder.Property(x => x.Seen).HasDefaultValue(false);

            builder.Property(x => x.Date).HasDefaultValueSql("getutcdate()");
        }
    }
}