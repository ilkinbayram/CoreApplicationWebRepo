using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface ISocialMediaDal : IEntityRepository<SocialMedia>, IEntityQueryableRepository<SocialMedia>
    {
    }
}
