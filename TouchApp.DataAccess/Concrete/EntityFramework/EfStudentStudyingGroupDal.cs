using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfStudentStudyingGroupDal : EfEntityRepositoryBase<StudentStudyingGroup, ApplicationDbContext>, IStudentStudyingGroupDal
    {
        public EfStudentStudyingGroupDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
