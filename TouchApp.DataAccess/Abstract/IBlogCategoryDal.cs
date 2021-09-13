using System.Collections.Generic;
using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface IBlogCategoryDal : IEntityRepository<BlogCategory>, IEntityQueryableRepository<BlogCategory>
    {
        List<BlogCategory> GetBlogCategoryList(int page, int count,string key);
        List<BlogCategory> GetParentBlogCategory();
        List<BlogCategory> GetSubCategories(int parentId);
        BlogCategory GetBlogCategoryById(long blogCategoryId);
    }
}
