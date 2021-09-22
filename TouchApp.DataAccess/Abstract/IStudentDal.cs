using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface IStudentDal : IEntityRepository<Student>, IEntityQueryableRepository<Student>
    {
    }
}
