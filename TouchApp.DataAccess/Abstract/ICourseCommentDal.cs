using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface ICourseCommentDal : IEntityRepository<CourseComment>, IEntityQueryableRepository<CourseComment>
    {
    }
}
