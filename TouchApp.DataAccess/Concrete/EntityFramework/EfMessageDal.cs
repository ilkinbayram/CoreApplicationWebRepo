using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfMessageDal : EfEntityRepositoryBase<Message, ApplicationDbContext>, IMessageDal
    {
        public EfMessageDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
