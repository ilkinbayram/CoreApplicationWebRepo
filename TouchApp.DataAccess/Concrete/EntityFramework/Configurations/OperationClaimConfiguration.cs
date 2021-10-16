﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities.Concrete;


namespace TouchApp.DataAccess.Concrete.EntityFramework.Configurations
{
    public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.ToTable("OperationClaims");
            builder.HasKey(k => k.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(p => p.Created_by).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(p => p.Created_at).HasColumnType("smalldatetime").IsRequired();
            builder.Property(p => p.Modified_by).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();
            builder.Property(p => p.Modified_at).HasColumnType("smalldatetime").IsRequired();
            builder.Property(p => p.IsActive).IsRequired().HasDefaultValue(true);

            builder.Property(p => p.Name).HasColumnType("nvarchar").HasMaxLength(100).IsRequired();

            builder.HasMany(m => m.UserOperationClaims).WithOne(o => o.OperationClaim).OnDelete(DeleteBehavior.Cascade).IsRequired(false);
            builder.HasMany(m => m.TeacherOperationClaims).WithOne(o => o.OperationClaim).OnDelete(DeleteBehavior.Cascade).IsRequired(false);
            builder.HasMany(m => m.StudentOperationClaims).WithOne(o => o.OperationClaim).OnDelete(DeleteBehavior.Cascade).IsRequired(false);

        }
    }
}
