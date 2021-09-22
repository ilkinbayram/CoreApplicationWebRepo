using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface IStudyingGroupDal : IEntityRepository<StudyingGroup>, IEntityQueryableRepository<StudyingGroup>
    {
    }
}
