using Backend.Domain.Entities;
using Backend.Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Backend.Persistance.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.CreatedOn).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.LastModified).HasDefaultValueSql("getutcdate()");
            builder.Property(x => x.TrialDuration).HasDefaultValue(15);
            builder.Property(x => x.Active).HasDefaultValue(true);
            //TODO Add fullname default value..

            builder.Property(x => x.AccountStatus)
                .HasDefaultValue(AccountStatus.Active)
                .HasConversion(
                    v => v.ToString(),
                    v => (AccountStatus)Enum.Parse(typeof(AccountStatus), v));

            builder
                .HasMany(x => x.MediaFiles)
                .WithOne(x => x.ApplicationUser)
                .HasForeignKey(x => x.ApplicationUserId);

        }
    }
}
