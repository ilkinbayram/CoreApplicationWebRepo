using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Entities.Concrete;
using Core.Entities.Dtos.Category;
using Core.Utilities.Results;

namespace TouchApp.Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<IEnumerable<Category>> GetList(Expression<Func<Category, bool>> filter = null);
        IDataResult<Category> Get(Expression<Func<Category, bool>> filter);
        IDataResult<int> Add(CreateCategoryDto category);
        IDataResult<int> Update(CategoryEditDto categoryEditDto);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<Category> categories);
        IDataResult<int> UpdateList(IEnumerable<Category> categories);
        IDataResult<int> DeletePermanentlyList(IEnumerable<Category> categories);
        IDataResult<int> DeleteByStatusList(IEnumerable<Category> categories);
        IDataResult<IEnumerable<CategoryListDto>> GetCategoryList(int page,int count,string key);
        IDataResult<IEnumerable<ParentCategories>> GetParentCategory();
        IDataResult<IEnumerable<ParentCategories>> GetSubCategories(int parentId);
        IDataResult<CategoryGetbyIdDto> GetCategoryById(long categoryId);
        IDataResult<IEnumerable<CategoryLangClientDto>> GetHomeParentCategoryList(string acceptedLanguage);
        IDataResult<IEnumerable<CategoryLangClientDto>> GetHomeChildCategoryList(int categoryId, string acceptedLanguage);
        IDataResult<CategoryGetLangDto> GetCategoryById(long categoryId, string acceptedLanguage);
    }
}
