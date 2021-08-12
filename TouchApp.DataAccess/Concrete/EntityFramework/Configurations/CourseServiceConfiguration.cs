﻿using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouchApp.DataAccess.Concrete.EntityFramework.Configurations
{
    class CourseServiceConfiguration : IEntityTypeConfiguration<CourseService>
    {
        public void Configure(EntityTypeBuilder<CourseService> builder)
        {
            builder.ToTable("CourseServices");
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