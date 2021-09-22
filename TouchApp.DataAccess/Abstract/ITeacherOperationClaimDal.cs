using Core.DataAccess;
using Core.Entities.Concrete;


namespace TouchApp.DataAccess.Abstract
{
    public interface ITeacherOperationClaimDal : IEntityRepository<TeacherOperationClaim>, IEntityQueryableRepository<TeacherOperationClaim>
    {
    }
}
