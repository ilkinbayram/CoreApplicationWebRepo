using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities.Concrete;


namespace TouchApp.DataAccess.Concrete.EntityFramework.Configurations
{
    public class StudentOperationClaimConfiguration : IEntityTypeConfiguration<StudentOperationClaim>
    {
        public void Configure(EntityTypeBuilder<StudentOperationClaim> builder)
        {
            builder.ToTable("StudentOperationClaims");
            builder.HasKey(k => k.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasOne(o => o.Student).WithMany(m => m.StudentOperationClaims);
            builder.HasOne(o => o.OperationClaim).WithMany(m => m.StudentOperationClaims);
        }
    }
}
