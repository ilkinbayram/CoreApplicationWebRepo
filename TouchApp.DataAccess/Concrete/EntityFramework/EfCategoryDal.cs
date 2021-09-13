using System;
using System.Collections.Generic;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, ApplicationDbContext>, ICategoryDal
    {
        public EfCategoryDal(ApplicationDbContext context):base(context)
        {

        }
        public Category GetCategoryById(long categoryId)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategoryList(int page, int count, string key)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetParentCategory()
        {
            throw new NotImplementedException();
        }

        public List<Category> GetSubCategories(int parentId)
        {
            throw new NotImplementedException();
        }
    }
}