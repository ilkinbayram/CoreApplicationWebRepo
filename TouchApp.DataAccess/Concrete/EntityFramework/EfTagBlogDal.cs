using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfTagBlogDal : EfEntityRepositoryBase<TagBlog, ApplicationDbContext>, ITagBlogDal
    {
        public EfTagBlogDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
