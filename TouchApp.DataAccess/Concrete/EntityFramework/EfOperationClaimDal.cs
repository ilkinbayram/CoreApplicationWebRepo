using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfOperationClaimDal : EfEntityRepositoryBase<OperationClaim, ApplicationDbContext>, IOperationClaimDal
    {
        public EfOperationClaimDal(ApplicationDbContext context):base(context)
        {
        }
    }
}
