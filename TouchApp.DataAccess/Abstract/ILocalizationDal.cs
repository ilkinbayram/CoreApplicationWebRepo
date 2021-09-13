using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface ILocalizationDal : IEntityRepository<Localization>, IEntityQueryableRepository<Localization>
    {
    }
}
