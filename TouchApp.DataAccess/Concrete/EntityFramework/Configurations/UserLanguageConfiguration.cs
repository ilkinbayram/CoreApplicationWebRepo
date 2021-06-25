using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class UserLanguageConfiguration : IEntityTypeConfiguration<UserLanguage>
    {
        public void Configure(EntityTypeBuilder<UserLanguage> builder)
        {
            builder.ToTable("UserLanguages");
            builder.HasKey(k => k.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(p => p.Description).HasColumnType("nvarchar").HasMaxLength(200).IsRequired(false);
            builder.Property(p => p.Slug).HasColumnType("nvarchar").HasMaxLength(250);

            builder.HasOne(o => o.Language).WithMany(m => m.FameousPersonLanguages).IsRequired(false);
            builder.HasOne(o => o.User).WithMany(m => m.UserLanguages).IsRequired(false);
        }
    }
}

