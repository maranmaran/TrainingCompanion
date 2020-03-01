using Backend.Domain.Entities.User;
using Backend.Domain.Entities.User.Dashboard;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistance.Configurations
{
    public class DashboardConfiguration : IEntityTypeConfiguration<Dashboard>
    {
        public void Configure(EntityTypeBuilder<Dashboard> builder)
        {
            builder.HasKey(x => x.Id);


            builder
                .HasOne(x => x.UserSetting)
                .WithOne(x => x.MainDashboard)
                .IsRequired(false)
                .HasForeignKey<UserSetting>(x => x.MainDashboardId);

        }
    }
}