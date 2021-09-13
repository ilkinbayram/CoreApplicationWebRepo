using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface IUserSocialMediaDal : IEntityRepository<UserSocialMedia>, IEntityQueryableRepository<UserSocialMedia>
    {
    }
}
