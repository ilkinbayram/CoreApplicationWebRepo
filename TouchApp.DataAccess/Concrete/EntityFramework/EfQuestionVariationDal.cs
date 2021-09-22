using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfQuestionVariationDal : EfEntityRepositoryBase<QuestionVariation, ApplicationDbContext>, IQuestionVariationDal
    {
        public EfQuestionVariationDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
