using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfTeacherDal : EfEntityRepositoryBase<Teacher, ApplicationDbContext>, ITeacherDal
    {
        public EfTeacherDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
