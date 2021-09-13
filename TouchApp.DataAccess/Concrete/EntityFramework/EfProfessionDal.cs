using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfProfessionDal : EfEntityRepositoryBase<Profession, ApplicationDbContext>, IProfessionDal
    {
        public EfProfessionDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
