using Core.DataAccess;
using Core.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace TouchApp.DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        List<Category> GetCategoryList(int page, int count,string key);
        List<Category> GetParentCategory();
        List<Category> GetSubCategories(int parentId);
        Category GetCategoryById(long categoryId);
    }
}
