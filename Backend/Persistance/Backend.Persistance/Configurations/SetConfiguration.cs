using Backend.Domain.Entities.TrainingLog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations
{
    public class SetConfiguration : IEntityTypeConfiguration<Set>
    {
        public void Configure(EntityTypeBuilder<Set> builder)
        {

        }
    }
}