using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface IOperationClaimDal : IEntityRepository<OperationClaim>, IEntityQueryableRepository<OperationClaim>
    {
    }
}
