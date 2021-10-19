using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities.Concrete;
using System;

namespace TouchApp.DataAccess.Concrete.EntityFramework.Configurations
{
    class CourseServiceConfiguration : IEntityTypeConfiguration<CourseService>
    {
        public void Configure(EntityTypeBuilder<CourseService> builder)
        {
            builder.ToTable("CourseServices");
            builder.HasKey(k => k.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(p => p.Created_by).HasColumnType("nvarchar").HasMaxLength(100).IsRequired().HasDefaultValue("System Manager");
            builder.Property(p => p.Created_at).HasColumnType("smalldatetime").IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(p => p.Modified_by).HasColumnType("nvarchar").HasMaxLength(100).IsRequired().HasDefaultValue("System Manager");
            builder.Property(p => p.Modified_at).HasColumnType("smalldatetime").IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(p => p.IsActive).IsRequired().HasDefaultValue(true);

            //builder
            //    .HasOne(x => x.ParentCategory).WithMany(z => z.Children).HasForeignKey(x => x.ParentCategoryId).IsRequired(false);
        }
    }
}
