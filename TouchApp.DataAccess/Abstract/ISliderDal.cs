using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface ISliderDal : IEntityRepository<Slider>, IEntityQueryableRepository<Slider>
    {
    }
}
