using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface IQuestionResultExamDal : IEntityRepository<QuestionResultExam>, IEntityQueryableRepository<QuestionResultExam>
    {
    }
}
