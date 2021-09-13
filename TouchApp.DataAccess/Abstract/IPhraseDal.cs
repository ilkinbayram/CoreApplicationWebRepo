using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface IPhraseDal : IEntityRepository<Phrase>, IEntityQueryableRepository<Phrase>
    {
    }
}
