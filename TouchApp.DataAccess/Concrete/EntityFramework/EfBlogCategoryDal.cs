using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfBlogCategoryDal : EfEntityRepositoryBase<BlogCategory, ApplicationDbContext>, IBlogCategoryDal
    {
        public EfBlogCategoryDal(ApplicationDbContext context) : base(context)
        {
        }

        public BlogCategory GetBlogCategoryById(long blogCategoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BlogCategory> GetBlogCategoryList(int page, int count, string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BlogCategory> GetParentBlogCategory()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BlogCategory> GetSubCategories(int parentId)
        {
            throw new NotImplementedException();
        }
    }
}
