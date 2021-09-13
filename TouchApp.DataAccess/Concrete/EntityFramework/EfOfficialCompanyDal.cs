using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfOfficialCompanyDal : EfEntityRepositoryBase<OfficialCompany, ApplicationDbContext>, IOfficialCompanyDal
    {
        public EfOfficialCompanyDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
