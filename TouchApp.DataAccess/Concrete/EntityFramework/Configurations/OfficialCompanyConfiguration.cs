﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities.Concrete;


namespace TouchApp.DataAccess.Concrete.EntityFramework.Configurations
{
    public class OfficialCompanyConfiguration : IEntityTypeConfiguration<OfficialCompany>
    {
        public void Configure(EntityTypeBuilder<OfficialCompany> builder)
        {
            builder.ToTable("OfficialCompanies");
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
