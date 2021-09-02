using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Entities.Dtos.BlogCategory;
using Core.Utilities.Results;

namespace TouchApp.Business.Abstract
{
    public interface IBlogCategoryService
    {
        IDataResult<List<BlogCategory>> GetList(Expression<Func<BlogCategory, bool>> filter = null);
        IDataResult<BlogCategory> Get(Expression<Func<BlogCategory, bool>> filter);
        IDataResult<int> Add(BlogCategory blogCategory);
        IDataResult<int> Update(BlogCategory blogCategory);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<BlogCategory> blogCategorys);
        IDataResult<int> UpdateList(List<BlogCategory> blogCategorys);
        IDataResult<int> DeletePermanentlyList(List<BlogCategory> blogCategorys);
        IDataResult<int> DeleteByStatusList(List<BlogCategory> blogCategorys);

        Task<IDataResult<List<GetBlogCategoryDto>>> GetDtoListAsync(Expression<Func<BlogCategory, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetBlogCategoryDto>> GetDtoAsync(Expression<Func<BlogCategory, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<BlogCategory> blogCategories);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<BlogCategory> blogCategories);
        Task<IDataResult<List<BlogCategory>>> GetListAsync(Expression<Func<BlogCategory, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<BlogCategory> blogCategories);
        Task<IDataResult<int>> UpdateAsync(BlogCategory blogCategory);
        Task<IDataResult<BlogCategory>> GetAsync(Expression<Func<BlogCategory, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(BlogCategory blogCategory);
    }
}
