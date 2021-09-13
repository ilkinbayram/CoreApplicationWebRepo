using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfSocialMediaDal : EfEntityRepositoryBase<SocialMedia, ApplicationDbContext>, ISocialMediaDal
    {
        public EfSocialMediaDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
