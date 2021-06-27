using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using TouchApp.Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Entities.Dtos.Category;
using Core.Utilities.Results;
using TouchApp.DataAccess.Abstract;
using Microsoft.AspNetCore.Http;
using Core.Extensions;
using Core.Aspects.Autofac.Validation;
using System.Linq;
using Business.ValidationRules.FluentValidation.Category;
using DataAccess.Concrete.EntityFramework.Contexts;
using Core.Utilities.Services.Rest;

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

        public IDataResult<int> AddList(IEnumerable<Category> categories)
        {
            throw new NotImplementedException();
        }

        public IDataResult<int> DeleteByStatus(long Id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<int> DeleteByStatusList(IEnumerable<Category> categories)
        {
            throw new NotImplementedException();
        }

        public IDataResult<int> DeletePermanently(long Id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<int> DeletePermanentlyList(IEnumerable<Category> categories)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Category> Get(Expression<Func<Category, bool>> filter)
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

        public IDataResult<IEnumerable<CategoryListDto>> GetCategoryList(int page, int count, string key)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<CategoryLangClientDto>> GetHomeChildCategoryList(int categoryId, string acceptedLanguage)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<CategoryLangClientDto>> GetHomeParentCategoryList(string acceptedLanguage)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<Category>> GetList(Expression<Func<Category, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<ParentCategories>> GetParentCategory()
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<ParentCategories>> GetSubCategories(int parentId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<int> Update(CategoryEditDto categoryEditDto)
        {
            throw new NotImplementedException();
        }

        public IDataResult<int> UpdateList(IEnumerable<Category> categories)
        {
            throw new NotImplementedException();
        }
    }
}
