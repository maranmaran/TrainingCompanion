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
            builder.Property(x => x.LastModified).HasDefaultValueSql("getutcdate()").ValueGeneratedOnAddOrUpdate();
            builder.Property(x => x.TrialDuration).HasDefaultValue(15);
            builder.Property(x => x.Active).HasDefaultValue(true);
            builder.Property(x => x.Avatar).HasDefaultValue(true);


            builder.Property(x => x.AccountType)
                .HasDefaultValue(AccountType.Coach)
                .HasConversion(
                    v => v.ToString(),
                    v => (AccountType)Enum.Parse(typeof(AccountType), v));

            builder.Property(x => x.Gender)
                .HasDefaultValue(Gender.Male)
                .HasConversion(
                    v => v.ToString(),
                    v => (Gender)Enum.Parse(typeof(Gender), v));

            builder
                .HasMany(x => x.MediaFiles)
                .WithOne(x => x.ApplicationUser)
                .HasForeignKey(x => x.ApplicationUserId);

        }
    }
}
