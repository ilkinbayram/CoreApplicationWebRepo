using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfTeacherSocialMediaDal : EfEntityRepositoryBase<TeacherSocialMedia, ApplicationDbContext>, ITeacherSocialMediaDal
    {
        public EfTeacherSocialMediaDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
