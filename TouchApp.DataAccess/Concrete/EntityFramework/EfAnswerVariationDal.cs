using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfAnswerVariationDal : EfEntityRepositoryBase<AnswerVariation, ApplicationDbContext>, IAnswerVariationDal
    {
        public EfAnswerVariationDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
