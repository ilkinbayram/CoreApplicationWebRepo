using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfPhraseDal : EfEntityRepositoryBase<Phrase, ApplicationDbContext>, IPhraseDal
    {
        public EfPhraseDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
