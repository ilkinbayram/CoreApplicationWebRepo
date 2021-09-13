using Core.Entities.Concrete;
using Core.Entities.Dtos.TagBlog;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

        Task<IDataResult<List<GetTagBlogDto>>> GetDtoListAsync(Expression<Func<TagBlog, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetTagBlogDto>> GetDtoAsync(Expression<Func<TagBlog, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<TagBlog> tagBlogs);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<TagBlog> tagBlogs);
        Task<IDataResult<List<TagBlog>>> GetListAsync(Expression<Func<TagBlog, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<TagBlog> tagBlogs);
        Task<IDataResult<int>> UpdateAsync(TagBlog tagBlog);
        Task<IDataResult<TagBlog>> GetAsync(Expression<Func<TagBlog, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(TagBlog tagBlog);
    }
}
