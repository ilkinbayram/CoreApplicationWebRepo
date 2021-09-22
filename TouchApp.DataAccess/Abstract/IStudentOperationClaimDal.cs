using Core.DataAccess;
using Core.Entities.Concrete;


namespace TouchApp.DataAccess.Abstract
{
    public interface IStudentOperationClaimDal : IEntityRepository<StudentOperationClaim>, IEntityQueryableRepository<StudentOperationClaim>
    {
    }
}
