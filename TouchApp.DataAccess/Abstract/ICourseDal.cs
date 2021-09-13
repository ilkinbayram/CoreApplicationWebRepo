using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface ICourseDal : IEntityRepository<Course>, IEntityQueryableRepository<Course>
    {
    }
}
