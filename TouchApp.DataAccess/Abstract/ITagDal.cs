using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface ITagDal : IEntityRepository<Tag>, IEntityQueryableRepository<Tag>
    {
    }
}
