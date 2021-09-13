using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface ISharingTypeDal : IEntityRepository<SharingType>, IEntityQueryableRepository<SharingType>
    {
    }
}
