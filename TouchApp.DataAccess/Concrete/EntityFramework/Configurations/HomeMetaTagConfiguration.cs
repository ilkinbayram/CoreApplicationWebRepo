using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class HomeMetaTagConfiguration : IEntityTypeConfiguration<HomeMetaTag>
    {
        public void Configure(EntityTypeBuilder<HomeMetaTag> builder)
        {
            builder.ToTable("HomeMetaTags");
            builder.HasKey(k => k.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(p => p.Created_by).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(p => p.Created_at).HasColumnType("smalldatetime").IsRequired();
            builder.Property(p => p.Modified_by).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(p => p.Modified_at).HasColumnType("smalldatetime").IsRequired();
            builder.Property(p => p.IsActive).IsRequired().HasDefaultValue(true);

            builder.HasMany(o => o.HomeMetaTagGalleries).WithOne(m => m.HomeMetaTag).IsRequired(false);
            builder.HasMany(o => o.HomeMetaTagLanguages).WithOne(m => m.HomeMetaTag).IsRequired(false);
            builder.HasMany(o => o.HomeMetaTagSections).WithOne(m => m.HomeMetaTag).IsRequired(false);
        }
    }
}

