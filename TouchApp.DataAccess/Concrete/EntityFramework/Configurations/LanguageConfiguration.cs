using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.ToTable("Languages");
            builder.HasKey(k => k.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(p => p.LanguageName).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();

            builder.HasMany(m => m.FameousPersonLanguages).WithOne(o => o.Language).IsRequired(false);
            builder.HasMany(m => m.CategoryLanguages).WithOne(o => o.Language).IsRequired(false);
            builder.HasMany(m => m.MessageLanguages).WithOne(o => o.Language).IsRequired(false);
            builder.HasMany(m => m.HomeMetaTagLanguages).WithOne(o => o.Language).IsRequired(false);
            builder.HasMany(m => m.SectionLanguages).WithOne(o => o.Language).IsRequired(false);
            builder.HasMany(m => m.FeatureValueLanguages).WithOne(o => o.Language).IsRequired(false);
            builder.HasMany(m => m.FeatureLanguages).WithOne(o => o.Language).IsRequired(false);
        }
    }
}

