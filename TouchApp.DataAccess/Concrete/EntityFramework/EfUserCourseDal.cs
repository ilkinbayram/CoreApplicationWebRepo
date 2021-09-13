using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfUserCourseDal : EfEntityRepositoryBase<UserCourse, ApplicationDbContext>, IUserCourseDal
    {
        public EfUserCourseDal(ApplicationDbContext context):base(context)
        {
        }
    }
}
