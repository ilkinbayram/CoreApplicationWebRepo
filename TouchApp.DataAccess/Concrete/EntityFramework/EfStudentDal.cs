using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfStudentDal : EfEntityRepositoryBase<Student, ApplicationDbContext>, IStudentDal
    {
        public EfStudentDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
