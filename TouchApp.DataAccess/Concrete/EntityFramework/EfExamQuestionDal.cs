using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfExamQuestionDal : EfEntityRepositoryBase<ExamQuestion, ApplicationDbContext>, IExamQuestionDal
    {
        public EfExamQuestionDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
