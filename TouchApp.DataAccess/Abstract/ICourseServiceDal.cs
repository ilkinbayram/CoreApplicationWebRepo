using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface ICourseServiceDal : IEntityRepository<CourseService>, IEntityQueryableRepository<CourseService>
    {
    }
}
