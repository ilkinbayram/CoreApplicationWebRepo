using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface IProfessionDal : IEntityRepository<Profession>, IEntityQueryableRepository<Profession>
    {
    }
}
