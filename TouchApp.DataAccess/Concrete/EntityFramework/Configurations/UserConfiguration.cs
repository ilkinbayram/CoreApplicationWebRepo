using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities.Concrete;
using Core.Resources.Enums;


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

            builder.Property(x => x.PasswordHash).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.PasswordSalt).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.PhoneNumber).IsRequired(false).HasMaxLength(250);
            builder.Property(x => x.PhoneNumberPrefix).IsRequired(false).HasMaxLength(10);

            builder.ToTable("Users");

        }
    }
}
