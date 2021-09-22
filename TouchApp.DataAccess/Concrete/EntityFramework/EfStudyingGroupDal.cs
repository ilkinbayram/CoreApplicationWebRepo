using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfStudyingGroupDal : EfEntityRepositoryBase<StudyingGroup, ApplicationDbContext>, IStudyingGroupDal
    {
        public EfStudyingGroupDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
