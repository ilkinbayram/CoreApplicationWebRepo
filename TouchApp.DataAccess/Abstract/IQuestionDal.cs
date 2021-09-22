using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface IQuestionDal : IEntityRepository<Question>, IEntityQueryableRepository<Question>
    {
    }
}
