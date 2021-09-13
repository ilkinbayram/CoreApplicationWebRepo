using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, ApplicationDbContext>, IUserOperationClaimDal
    {
        public EfUserOperationClaimDal(ApplicationDbContext context):base(context)
        {
        }
    }
}
