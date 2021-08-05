using System;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using TouchApp.DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;

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

        public IEnumerable<ProfessionCourseCategory> GetProfessionCourseCategoryList(int page, int count, string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProfessionCourseCategory> GetParentProfessionCourseCategory()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProfessionCourseCategory> GetSubCategories(int parentId)
        {
            throw new NotImplementedException();
        }
    }
}