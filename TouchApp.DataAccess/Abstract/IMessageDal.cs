using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface IMessageDal : IEntityRepository<Message>, IEntityQueryableRepository<Message>
    {
    }
}
