using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemException = Backend.Domain.Entities.SystemException;

namespace Backend.Persistance.Configurations
{
    public class SystemExceptionConfiguration : IEntityTypeConfiguration<SystemException>
    {
        public void Configure(EntityTypeBuilder<SystemException> builder)
        {
            builder.Property(x => x.Date).HasDefaultValueSql("getutcdate()");
        }
    }
}
