using AutoMapper;
using Core.Entities.Concrete;
using Core.Entities.Dtos.Category;
using Core.Utilities.Results;
using Core.Utilities.Services.Rest;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;
using TouchApp.DataAccess.Abstract;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ICloudinaryService _cloudinaryService;

        public CategoryManager(ICategoryDal categoryDal, 
                               IMapper mapper,
                               IHttpContextAccessor httpContextAccessor,
                               ICloudinaryService cloudinaryService)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
            _httpContext = httpContextAccessor;
            _cloudinaryService = cloudinaryService;
        }

        public IDataResult<int> Add(CreateCategoryDto category)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<int>> AddAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public IDataResult<int> AddList(List<Category> categories)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<int>> AddListAsync(List<Category> categories)
        {
            throw new NotImplementedException();
        }

        public IDataResult<int> DeleteByStatus(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<int>> DeleteByStatusAsync(long Id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<int> DeleteByStatusList(List<Category> categories)
        {
            throw new NotImplementedException();
        }

        public IDataResult<int> DeletePermanently(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<int>> DeletePermanentlyAsync(long Id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<int> DeletePermanentlyList(List<Category> categories)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<int>> DeletePermanentlyListAsync(List<Category> categories)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Category> Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Category>> GetAsync(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IDataResult<CategoryGetbyIdDto> GetCategoryById(long categoryId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<CategoryGetLangDto> GetCategoryById(long categoryId, string acceptedLanguage)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CategoryListDto>> GetCategoryList(int page, int count, string key)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CategoryLangClientDto>> GetHomeChildCategoryList(int categoryId, string acceptedLanguage)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CategoryLangClientDto>> GetHomeParentCategoryList(string acceptedLanguage)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Category>> GetList(Expression<Func<Category, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<Category>>> GetListAsync(Expression<Func<Category, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ParentCategories>> GetParentCategory()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ParentCategories>> GetSubCategories(int parentId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<int> Update(CategoryEditDto categoryEditDto)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<int>> UpdateAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public IDataResult<int> UpdateList(List<Category> categories)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<int>> UpdateListAndSaveAsync(List<Category> categories)
        {
            throw new NotImplementedException();
        }
    }
}
