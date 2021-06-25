using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class UserFeatureValueConfiguration : IEntityTypeConfiguration<UserFeatureValue>
    {
        public void Configure(EntityTypeBuilder<UserFeatureValue> builder)
        {
            builder.ToTable("UserFeatureValues");
            builder.HasKey(k => k.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(p => p.Value).HasColumnType("nvarchar").HasMaxLength(100).IsRequired(false);

            builder.HasOne(o => o.CategoryFeature).WithMany(m => m.UserFeatureValues).IsRequired(false);
            builder.HasOne(o => o.User).WithMany(m => m.UserFeatureValues).IsRequired(false);
            builder.HasOne(o => o.FeatureValue).WithMany(m => m.UserFeatureValues).IsRequired(false);
        }
    }
}

