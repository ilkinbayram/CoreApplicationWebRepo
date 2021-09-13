using System.Collections.Generic;
using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>, IEntityQueryableRepository<Category>
    {
        List<Category> GetCategoryList(int page, int count,string key);
        List<Category> GetParentCategory();
        List<Category> GetSubCategories(int parentId);
        Category GetCategoryById(long categoryId);
    }
}
