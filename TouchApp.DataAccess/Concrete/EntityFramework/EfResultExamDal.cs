using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfResultExamDal : EfEntityRepositoryBase<ResultExam, ApplicationDbContext>, IResultExamDal
    {
        public EfResultExamDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
