using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface IExamQuestionDal : IEntityRepository<ExamQuestion>, IEntityQueryableRepository<ExamQuestion>
    {
    }
}
