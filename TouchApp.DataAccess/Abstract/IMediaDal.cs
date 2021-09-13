using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface IMediaDal : IEntityRepository<Media>, IEntityQueryableRepository<Media>
    {
    }
}
