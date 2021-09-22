using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface IResultExamDal : IEntityRepository<ResultExam>, IEntityQueryableRepository<ResultExam>
    {
    }
}
