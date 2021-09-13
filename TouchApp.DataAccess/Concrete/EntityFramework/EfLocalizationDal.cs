using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfLocalizationDal : EfEntityRepositoryBase<Localization, ApplicationDbContext>, ILocalizationDal
    {
        public EfLocalizationDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
