using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities.Concrete;


namespace TouchApp.DataAccess.Concrete.EntityFramework.Configurations
{
    public class TeacherOperationClaimConfiguration : IEntityTypeConfiguration<TeacherOperationClaim>
    {
        public void Configure(EntityTypeBuilder<TeacherOperationClaim> builder)
        {
            builder.ToTable("TeacherOperationClaims");
            builder.HasKey(k => k.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasOne(o => o.Teacher).WithMany(m => m.TeacherOperationClaims);
            builder.HasOne(o => o.OperationClaim).WithMany(m => m.TeacherOperationClaims);
        }
    }
}
