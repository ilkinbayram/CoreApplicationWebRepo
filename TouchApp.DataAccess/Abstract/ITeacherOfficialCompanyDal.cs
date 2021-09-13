using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface ITeacherOfficialCompanyDal : IEntityRepository<TeacherOfficialCompany>, IEntityQueryableRepository<TeacherOfficialCompany>
    {
    }
}
