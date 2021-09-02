using Core.DataAccess;
using Core.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace TouchApp.DataAccess.Abstract
{
    public interface IProfessionCourseCategoryDal : IEntityRepository<ProfessionCourseCategory>, IEntityQueryableRepository<ProfessionCourseCategory>
    {
        List<ProfessionCourseCategory> GetProfessionCourseCategoryList(int page, int count,string key);
        List<ProfessionCourseCategory> GetParentProfessionCourseCategory();
        List<ProfessionCourseCategory> GetSubCategories(int parentId);
        ProfessionCourseCategory GetProfessionCourseCategoryById(long ProfessionCourseCategoryId);
    }
}
