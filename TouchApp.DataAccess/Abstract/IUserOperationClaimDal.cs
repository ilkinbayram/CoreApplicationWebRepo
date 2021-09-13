using Core.DataAccess;
using Core.Entities.Concrete;


namespace TouchApp.DataAccess.Abstract
{
    public interface IUserOperationClaimDal : IEntityRepository<UserOperationClaim>, IEntityQueryableRepository<UserOperationClaim>
    {
    }
}
