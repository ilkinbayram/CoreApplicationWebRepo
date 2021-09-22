using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface IStudentStudyingGroupDal : IEntityRepository<StudentStudyingGroup>, IEntityQueryableRepository<StudentStudyingGroup>
    {
    }
}