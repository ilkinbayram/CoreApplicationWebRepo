using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfMediaDal : EfEntityRepositoryBase<Media, ApplicationDbContext>, IMediaDal
    {
        public EfMediaDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
