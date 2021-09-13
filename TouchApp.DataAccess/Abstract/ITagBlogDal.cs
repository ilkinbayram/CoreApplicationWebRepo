using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface ITagBlogDal : IEntityRepository<TagBlog>, IEntityQueryableRepository<TagBlog>
    {
    }
}
