using Core.Entities.Concrete;
using Core.Resources.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations
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
            builder.Property(x => x.CategoryId).IsRequired(false);
            builder.Property(x => x.Rate).HasPrecision(2,1).IsRequired(false);
            builder.Property(x => x.RateCount).HasDefaultValue(5).IsRequired(false);
            

            builder.HasMany(x => x.UserOperationClaims).WithOne(m => m.User as User).IsRequired(false);
            builder.HasMany(x => x.UserOrders).WithOne(m => m.User).IsRequired(false);
            builder.HasMany(x => x.FamousOrders).WithOne(m => m.FamousPerson).IsRequired(false);
            builder.HasMany(x => x.FamousRates).WithOne(m => m.FamousPerson).IsRequired(false);
            builder.HasMany(x => x.UserRates).WithOne(m => m.User).IsRequired(false);
            builder.HasMany(x => x.UserLanguages).WithOne(m => m.User).IsRequired(false);
            builder.HasMany(x => x.UserFeatureValues).WithOne(m => m.User).IsRequired(false);

            builder.HasOne(o => o.Category).WithMany(m => m.Users).IsRequired(false);

            builder.ToTable("Users");

        }
    }
}
