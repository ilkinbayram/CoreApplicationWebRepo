using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfCourseDal : EfEntityRepositoryBase<Course, ApplicationDbContext>, ICourseDal
    {
        public EfCourseDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
