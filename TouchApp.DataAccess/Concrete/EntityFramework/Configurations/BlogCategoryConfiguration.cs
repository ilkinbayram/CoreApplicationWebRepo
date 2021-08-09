using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TouchApp.DataAccess.Concrete.EntityFramework.Configurations
{
    class BlogCategoryConfiguration : IEntityTypeConfiguration<BlogCategory>
    {
        public void Configure(EntityTypeBuilder<BlogCategory> builder)
        {
            builder.ToTable("BlogCategories");
            builder.HasKey(k => k.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(p => p.Created_by).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(p => p.Created_at).HasColumnType("smalldatetime").IsRequired();
            builder.Property(p => p.Modified_by).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(p => p.Modified_at).HasColumnType("smalldatetime").IsRequired();
            builder.Property(p => p.IsActive).IsRequired().HasDefaultValue(true);

            //builder
            //    .HasOne(x => x.ParentCategory).WithMany(z => z.Children).HasForeignKey(x => x.ParentCategoryId).IsRequired(false);
        }
    }
}
