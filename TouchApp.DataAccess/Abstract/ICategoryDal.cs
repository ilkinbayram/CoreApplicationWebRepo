using Core.DataAccess;
using Core.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Concrete.EntityFramework.Contexts;

namespace DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        IEnumerable<Category> GetCategoryList(int page, int count,string key);
        IEnumerable<Category> GetParentCategory();
        IEnumerable<Category> GetSubCategories(int parentId);
        Category GetCategoryById(long categoryId);
        IEnumerable<CategoryLanguage> GetHomeParentCategoryList(string acceptedLanguage);
        IEnumerable<CategoryLanguage> GetHomeChildCategoryList(int categoryId, string acceptedLanguage);
        CategoryLanguage GetCategoryById(long categoryId, string acceptedLanguage);
    }
}
