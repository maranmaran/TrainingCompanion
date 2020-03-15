using Backend.Domain.Entities.Auditing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations
{
    public class AuditConfiguration : IEntityTypeConfiguration<AuditRecord>
    {
        public void Configure(EntityTypeBuilder<AuditRecord> builder)
        {

        }
    }
}