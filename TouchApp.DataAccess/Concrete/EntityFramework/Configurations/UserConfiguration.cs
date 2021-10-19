using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities.Concrete;
using Core.Resources.Enums;
using System;

namespace TouchApp.DataAccess.Concrete.EntityFramework.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.AccountType).IsRequired();
            builder.Property(x => x.Gender).IsRequired().HasDefaultValue(Gender.NotSpecified);
            builder.Property(x => x.FirstName).IsRequired().HasColumnType("nvarchar").HasMaxLength(250);
            builder.Property(x => x.LastName).IsRequired().HasColumnType("nvarchar").HasMaxLength(250);
            builder.Property(x => x.SecurityToken).IsRequired().HasColumnType("nvarchar").HasMaxLength(250);

            builder.Property(p => p.Created_by).HasColumnType("nvarchar").HasMaxLength(100).IsRequired().HasDefaultValue("System Manager");
            builder.Property(p => p.Created_at).HasColumnType("smalldatetime").IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(p => p.Modified_by).HasColumnType("nvarchar").HasMaxLength(100).IsRequired().HasDefaultValue("System Manager");
            builder.Property(p => p.Modified_at).HasColumnType("smalldatetime").IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(p => p.IsActive).IsRequired().HasDefaultValue(true);

            builder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.PasswordSalt).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.PhoneNumber).IsRequired(false).HasMaxLength(250);
            builder.Property(x => x.PhoneNumberPrefix).IsRequired(false).HasMaxLength(10);

            builder.HasMany(p => p.UserSocialMedias).WithOne(x => x.User).OnDelete(DeleteBehavior.Cascade).IsRequired(false);
            builder.HasMany(p => p.UserOperationClaims).WithOne(x => x.User).OnDelete(DeleteBehavior.Cascade).IsRequired(false);

            builder.ToTable("Users");

        }
    }
}
