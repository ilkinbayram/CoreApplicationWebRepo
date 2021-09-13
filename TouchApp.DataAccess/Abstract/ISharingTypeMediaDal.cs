using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface ISharingTypeMediaDal : IEntityRepository<SharingTypeMedia>, IEntityQueryableRepository<SharingTypeMedia>
    {
    }
}
