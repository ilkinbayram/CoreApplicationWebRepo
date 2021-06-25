using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    public class HomeMetaTagGalleryConfiguration : IEntityTypeConfiguration<HomeMetaTagGallery>
    {
        public void Configure(EntityTypeBuilder<HomeMetaTagGallery> builder)
        {
            builder.ToTable("HomeMetaTagGalleries");
            builder.HasKey(k => k.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(p => p.Url).HasColumnType("nvarchar").HasMaxLength(200).IsRequired(false);
            builder.Property(p => p.Order).IsRequired().HasDefaultValue(1);
            builder.Property(p => p.Alt).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(p => p.IsActive).IsRequired().HasDefaultValue(true);

            builder.HasOne(o => o.HomeMetaTag).WithMany(m => m.HomeMetaTagGalleries).IsRequired(false);
        }
    }
}

