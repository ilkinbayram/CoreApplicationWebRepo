using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfSliderDal : EfEntityRepositoryBase<Slider, ApplicationDbContext>, ISliderDal
    {
        public EfSliderDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
