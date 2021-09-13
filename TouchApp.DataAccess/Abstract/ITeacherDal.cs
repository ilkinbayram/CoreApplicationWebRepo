using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface ITeacherDal : IEntityRepository<Teacher>, IEntityQueryableRepository<Teacher>
    {
    }
}
