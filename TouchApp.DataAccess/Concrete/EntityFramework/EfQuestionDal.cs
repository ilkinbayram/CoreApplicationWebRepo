using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfQuestionDal : EfEntityRepositoryBase<Question, ApplicationDbContext>, IQuestionDal
    {
        public EfQuestionDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
