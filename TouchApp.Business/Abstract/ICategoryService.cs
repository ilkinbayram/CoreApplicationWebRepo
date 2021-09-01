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
    }
}
