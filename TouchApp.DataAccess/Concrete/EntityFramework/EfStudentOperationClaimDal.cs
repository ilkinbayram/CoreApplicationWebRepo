using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfStudentOperationClaimDal : EfEntityRepositoryBase<StudentOperationClaim, ApplicationDbContext>, IStudentOperationClaimDal
    {
        public EfStudentOperationClaimDal(ApplicationDbContext context):base(context)
        {
        }
    }
}
