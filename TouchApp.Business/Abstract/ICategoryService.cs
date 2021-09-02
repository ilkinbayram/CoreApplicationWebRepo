using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Entities.Dtos.Category;
using Core.Utilities.Results;

namespace TouchApp.Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetList(Expression<Func<Category, bool>> filter = null);
        IDataResult<Category> Get(Expression<Func<Category, bool>> filter);
        IDataResult<int> Add(CreateCategoryDto category);
        IDataResult<int> Update(CategoryEditDto categoryEditDto);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<Category> categories);
        IDataResult<int> UpdateList(List<Category> categories);
        IDataResult<int> DeletePermanentlyList(List<Category> categories);
        IDataResult<int> DeleteByStatusList(List<Category> categories);
        IDataResult<List<CategoryListDto>> GetCategoryList(int page,int count,string key);
        IDataResult<List<ParentCategories>> GetParentCategory();
        IDataResult<List<ParentCategories>> GetSubCategories(int parentId);
        IDataResult<CategoryGetbyIdDto> GetCategoryById(long categoryId);
        IDataResult<List<CategoryLangClientDto>> GetHomeParentCategoryList(string acceptedLanguage);
        IDataResult<List<CategoryLangClientDto>> GetHomeChildCategoryList(int categoryId, string acceptedLanguage);
        IDataResult<CategoryGetLangDto> GetCategoryById(long categoryId, string acceptedLanguage);

        //Task<IDataResult<List<GetCategoryDto>>> GetDtoListAsync(Expression<Func<Category, bool>> filter = null, int takeCount = 2000);
        //Task<IDataResult<GetCategoryDto>> GetDtoAsync(Expression<Func<Category, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<Category> categories);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<Category> categories);
        Task<IDataResult<List<Category>>> GetListAsync(Expression<Func<Category, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<Category> categories);
        Task<IDataResult<int>> UpdateAsync(Category category);
        Task<IDataResult<Category>> GetAsync(Expression<Func<Category, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(Category category);
    }
}
