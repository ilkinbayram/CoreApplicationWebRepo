using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace TouchApp.Business.Abstract
{
    public interface IProfessionCourseCategoryService
    {
        IDataResult<List<ProfessionCourseCategory>> GetList(Expression<Func<ProfessionCourseCategory, bool>> filter = null);
        IDataResult<ProfessionCourseCategory> Get(Expression<Func<ProfessionCourseCategory, bool>> filter);
        IDataResult<int> Add(ProfessionCourseCategory professionProfessionCourseCategoryCategory);
        IDataResult<int> Update(ProfessionCourseCategory professionProfessionCourseCategoryCategory);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<ProfessionCourseCategory> professionProfessionCourseCategoryCategorys);
        IDataResult<int> UpdateList(List<ProfessionCourseCategory> professionProfessionCourseCategoryCategorys);
        IDataResult<int> DeletePermanentlyList(List<ProfessionCourseCategory> professionProfessionCourseCategoryCategorys);
        IDataResult<int> DeleteByStatusList(List<ProfessionCourseCategory> professionProfessionCourseCategoryCategorys);
    }
}
