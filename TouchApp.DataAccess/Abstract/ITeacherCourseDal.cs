using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface ITeacherCourseDal : IEntityRepository<TeacherCourse>, IEntityQueryableRepository<TeacherCourse>
    {
    }
}
