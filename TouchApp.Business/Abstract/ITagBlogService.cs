using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface ITagBlogService
    {
        IDataResult<List<TagBlog>> GetList(Expression<Func<TagBlog, bool>> filter = null);
        IDataResult<TagBlog> Get(Expression<Func<TagBlog, bool>> filter);
        IDataResult<int> Add(TagBlog tagBlog);
        IDataResult<int> Update(TagBlog tagBlog);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<TagBlog> tagBlogs);
        IDataResult<int> UpdateList(List<TagBlog> tagBlogs);
        IDataResult<int> DeletePermanentlyList(List<TagBlog> tagBlogs);
        IDataResult<int> DeleteByStatusList(List<TagBlog> tagBlogs);
    }
}
