using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfSharingTypeDal : EfEntityRepositoryBase<SharingType, ApplicationDbContext>, ISharingTypeDal
    {
        public EfSharingTypeDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
