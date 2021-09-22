using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfExamDal : EfEntityRepositoryBase<Exam, ApplicationDbContext>, IExamDal
    {
        public EfExamDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
