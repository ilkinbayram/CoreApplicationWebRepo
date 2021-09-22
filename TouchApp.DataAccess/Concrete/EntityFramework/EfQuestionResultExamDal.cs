using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfQuestionResultExamDal : EfEntityRepositoryBase<QuestionResultExam, ApplicationDbContext>, IQuestionResultExamDal
    {
        public EfQuestionResultExamDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
