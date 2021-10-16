using Core.Entities.Concrete;
using Core.Entities.Dtos.Blog;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface IBlogService
    {
        IDataResult<List<GetBlogDto>> GetDtoList(Expression<Func<Blog, bool>> filter = null, int takeCount = 2000);
        IDataResult<GetBlogDto> GetDto(Expression<Func<Blog, bool>> filter = null);
        IDataResult<List<Blog>> GetList(Expression<Func<Blog, bool>> filter = null);
        Task<IDataResult<List<GetBlogDto>>> GetDtoListAsync(Expression<Func<Blog, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetBlogDto>> GetDtoAsync(Expression<Func<Blog, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<Blog> blogs);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<Blog> blogs);
        Task<IDataResult<List<Blog>>> GetListAsync(Expression<Func<Blog, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<Blog> blogs);
        Task<IDataResult<int>> UpdateAsync(Blog blog);
        Task<IDataResult<Blog>> GetAsync(Expression<Func<Blog, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(CreateManagementBlogDto blog);
        IDataResult<Blog> Get(Expression<Func<Blog, bool>> filter);
        IDataResult<int> Add(CreateManagementBlogDto blog);
        IDataResult<int> Update(Blog blog);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<Blog> blogs);
        IDataResult<int> UpdateList(List<Blog> blogs);
        IDataResult<int> DeletePermanentlyList(List<Blog> blogs);
        IDataResult<int> DeleteByStatusList(List<Blog> blogs);
        IDataResult<List<GetBlogDto>> GetRelatedBlogsByBlogCategoryId(long id, long savingId = -1);
        IDataResult<List<GetBlogDto>> GetFilteredBlogsByTagId(long id);
        IDataResult<List<GetBlogDto>> GetFilteredBlogsByBlogCategoryId(long id);
        IDataResult<List<GetBlogDto>> GetListDto(Expression<Func<Blog, bool>> filter = null);
    }
}
