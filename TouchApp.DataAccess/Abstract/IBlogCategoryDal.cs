using Core.DataAccess;
using Core.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Concrete.EntityFramework.Contexts;

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
