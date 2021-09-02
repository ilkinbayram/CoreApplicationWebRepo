using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface ILanguageDal : IEntityRepository<Language>, IEntityQueryableRepository<Language>
    {
    }
}
