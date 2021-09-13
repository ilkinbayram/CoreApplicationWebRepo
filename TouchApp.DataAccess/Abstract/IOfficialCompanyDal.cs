using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface IOfficialCompanyDal : IEntityRepository<OfficialCompany>, IEntityQueryableRepository<OfficialCompany>
    {
    }
}
