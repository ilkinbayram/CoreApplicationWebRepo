using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface IBlogDal : IEntityRepository<Blog>, IEntityQueryableRepository<Blog>
    {
    }
}
