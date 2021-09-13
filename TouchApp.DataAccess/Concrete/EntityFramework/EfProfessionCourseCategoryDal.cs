using System;
using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfProfessionCourseCategoryDal : EfEntityRepositoryBase<ProfessionCourseCategory, ApplicationDbContext>, IProfessionCourseCategoryDal
    {
        public EfProfessionCourseCategoryDal(ApplicationDbContext context):base(context)
        {

        }
        public ProfessionCourseCategory GetProfessionCourseCategoryById(long ProfessionCourseCategoryId)
        {
            throw new NotImplementedException();
        }

        public List<ProfessionCourseCategory> GetProfessionCourseCategoryList(int page, int count, string key)
        {
            throw new NotImplementedException();
        }

        public List<ProfessionCourseCategory> GetParentProfessionCourseCategory()
        {
            throw new NotImplementedException();
        }

        public List<ProfessionCourseCategory> GetSubCategories(int parentId)
        {
            throw new NotImplementedException();
        }
    }
}