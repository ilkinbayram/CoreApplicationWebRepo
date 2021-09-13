using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface ITeacherSocialMediaDal : IEntityRepository<TeacherSocialMedia>, IEntityQueryableRepository<TeacherSocialMedia>
    {
    }
}
