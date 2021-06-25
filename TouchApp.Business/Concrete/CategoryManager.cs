using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Entities.Dtos.Category;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
        private readonly ICategoryFeatureService _categoryFeatureService;
        private readonly ICategoryLanguageService _categoryLanguageService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly ICategoryFeatureDal _categoryFeatureDal;
        private readonly ICloudinaryService _cloudinaryService;

        public CategoryManager(ICategoryDal categoryDal, 
                               IMapper mapper,
                               ICategoryFeatureService categoryFeatureService,
                               ICategoryLanguageService categoryLanguageService,
                               IHttpContextAccessor httpContextAccessor,
                               ICategoryFeatureDal categoryFeatureDal,
                               ICloudinaryService cloudinaryService)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
            _categoryFeatureService = categoryFeatureService;
            _categoryLanguageService = categoryLanguageService;
            _httpContext = httpContextAccessor;
            _categoryFeatureDal = categoryFeatureDal;
            _cloudinaryService = cloudinaryService;
        }
        [ValidationAspect(typeof(CreateCategoryDtoValidator), Priority = 1)]
        public IDataResult<int> Add(CreateCategoryDto categoryDto)
        {
            try
            {
                var activeUserName = _httpContext.HttpContext.User.GetFullName();
                Category category = _mapper.Map<CreateCategoryDto, Category>(categoryDto);
                category.Created_by = activeUserName;
                category.Modified_by = activeUserName;
                category.Created_at = DateTime.Now;
                category.Modified_at = DateTime.Now;
                category.IsActive = true;
                category.Banner = categoryDto.Banner;

                int affectedRows = _categoryDal.Add(category);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> DeleteByStatus(long id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = _categoryDal.Get(x => x.Id == id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = _categoryDal.DeleteByStatus(deletableEntity);

                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataDeleted);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, Messages.BusinessDataWasNotDeleted);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> DeletePermanently(long id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = _categoryDal.Get(x => x.Id == id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _categoryDal.DeletePermanently(deletableEntity);
                
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataDeleted);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, Messages.BusinessDataWasNotDeleted);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<Category> Get(Expression<Func<Category, bool>> filter)
        {
            try
            {
                var response = _categoryDal.Get(filter);
                var mappingResult = _mapper.Map<Category>(response);
                return new SuccessDataResult<Category>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<Category>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<IEnumerable<Category>> GetList(Expression<Func<Category, bool>> filter = null)
        {
            try
            {
                var response = _categoryDal.GetList(filter);
                var mappingResult = _mapper.Map<IEnumerable<Category>>(response);
                return new SuccessDataResult<IEnumerable<Category>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<IEnumerable<Category>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<IEnumerable<CategoryListDto>> GetCategoryList(int page,int count,string key)
        {
            try
            {
                var response = _categoryDal.GetCategoryList(page,count,key);
                var mappingResult = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryListDto>>(response);
                foreach (var category in mappingResult)
                {
                    category.Banner = category.Banner != null ? _cloudinaryService.BuildUrl(category.Banner) : "";
                }
                return new SuccessDataResult<IEnumerable<CategoryListDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<IEnumerable<CategoryListDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> Update(CategoryEditDto categoryEditDto)
        {
            try
            {
                var activeUserName = _httpContext.HttpContext.User.GetFullName();
                Category dbcategory = _categoryDal.GetCategoryById(categoryEditDto.Id);
                dbcategory.Modified_at = DateTime.Now;
                dbcategory.Modified_by = activeUserName;
                dbcategory.ParentCategoryId = categoryEditDto.ParentCategoryId;
                foreach (var categoryLang in categoryEditDto.CategoryLanguages)
                {

                    var catlang = dbcategory.CategoryLanguages.FirstOrDefault(x => x.Id == categoryLang.Id && x.LanguageId == categoryLang.LanguageId);
                    if (catlang != null)
                    {
                        catlang.Name = categoryLang.Name;
                        catlang.Description = categoryLang.Description;
                        catlang.Slug = categoryLang.Slug;
                    }
                }
                var exsitfield = dbcategory.CategoryFeatures.ToList();
                foreach (var categoryfeature in categoryEditDto.CategoryFeatures)
                {
                    if (categoryfeature.Id != 0 && categoryfeature.Id != null)
                    {
                        var feature = dbcategory.CategoryFeatures.FirstOrDefault(x => x.Id == categoryfeature.Id);

                        feature.FeatureId = categoryfeature.FeatureId ?? default;
                        exsitfield.Remove(feature);
                    }
                    else
                    {
                        categoryfeature.CategoryId = dbcategory.Id;
                        var mapCategoryFeature = _mapper.Map<CategoryFeature>(categoryfeature);
                         _categoryFeatureDal.AddCategoryFeature(mapCategoryFeature);
                    }
                }
                _categoryFeatureDal.RemoveRange(exsitfield);
                if (categoryEditDto.Banner != null && categoryEditDto.Banner == null)
                {
                    dbcategory.Banner = categoryEditDto.Banner;
                }
                else if (categoryEditDto.Banner != null && dbcategory.Banner != null)
                {
                    _cloudinaryService.Delete(dbcategory.Banner);
                    dbcategory.Banner = categoryEditDto.Banner;
                }
                int affectedRows = _categoryDal.Commit();
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataUpdated);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, Messages.BusinessDataWasNotUpdated);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<IEnumerable<ParentCategories>> GetParentCategory()
        {
            try
            {
                var response = _categoryDal.GetParentCategory();
                var mappingResult = _mapper.Map<IEnumerable<Category>, IEnumerable<ParentCategories>>(response);

                return new SuccessDataResult<IEnumerable<ParentCategories>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<IEnumerable<ParentCategories>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<IEnumerable<ParentCategories>> GetSubCategories(int parentId)
        {
            try
            {
                var response = _categoryDal.GetSubCategories(parentId);
                var mappingResult = _mapper.Map<IEnumerable<Category>, IEnumerable<ParentCategories>>(response);

                return new SuccessDataResult<IEnumerable<ParentCategories>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<IEnumerable<ParentCategories>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<CategoryGetbyIdDto> GetCategoryById(long categoryId)
        {
            try
            {
                var response = _categoryDal.GetCategoryById(categoryId);
                var mappingResult = _mapper.Map<Category,CategoryGetbyIdDto>(response);
                mappingResult.BannerCloudinaryUrl = _cloudinaryService.BuildUrl(response.Banner);

                return new SuccessDataResult<CategoryGetbyIdDto>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<CategoryGetbyIdDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }


        public IDataResult<int> AddList(IEnumerable<Category> categories)
        {
            try
            {
                int affectedRows = _categoryDal.Add(categories);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> UpdateList(IEnumerable<Category> categories)
        {
            try
            {
                int affectedRows = _categoryDal.Update(categories);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> DeletePermanentlyList(IEnumerable<Category> categories)
        {
            try
            {
                int affectedRows = _categoryDal.DeletePermanently(categories);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> DeleteByStatusList(IEnumerable<Category> categories)
        {
            try
            {
                foreach (var category in categories)
                {
                    category.IsActive = false;
                }

                DeleteAllEntitiesByStatusForAllRelationList(categories);

                int affectedRows = _categoryDal.DeleteByStatus(categories);

                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        private void DeleteAllEntitiesByStatusForAllRelationList(IEnumerable<Category> categories)
        {
            foreach (var category in categories)
            {
                if (category.CategoryFeatures != null)
                {
                    _categoryFeatureService.DeleteByStatusList(category.CategoryFeatures);
                }

                if (category.CategoryLanguages != null)
                {
                    _categoryLanguageService.DeleteByStatusList(category.CategoryLanguages);
                }
            }
        }

        private void DeleteByStatusForAllRelation(Category category)
        {
            if (category.CategoryFeatures != null)
            {
                _categoryFeatureService.DeleteByStatusList(category.CategoryFeatures);
            }

            if (category.CategoryLanguages != null)
            {
                _categoryLanguageService.DeleteByStatusList(category.CategoryLanguages);
            }
        }

        public IDataResult<IEnumerable<CategoryLangClientDto>> GetHomeParentCategoryList(string acceptedLanguage)
        {
            try
            {
                var response = _categoryDal.GetHomeParentCategoryList(acceptedLanguage);
                var mappingResult = _mapper.Map<IEnumerable<CategoryLangClientDto>>(response);
                foreach (var category in mappingResult)
                {
                    category.Banner = category.Banner != null ?  _cloudinaryService.BuildUrl(category.Banner):"";
                }
                return new SuccessDataResult<IEnumerable<CategoryLangClientDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<IEnumerable<CategoryLangClientDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<IEnumerable<CategoryLangClientDto>> GetHomeChildCategoryList(int categoryId, string acceptedLanguage)
        {
            try
            {
                var response = _categoryDal.GetHomeChildCategoryList(categoryId, acceptedLanguage);
                var mappingResult = _mapper.Map<IEnumerable<CategoryLangClientDto>>(response);
                foreach (var category in mappingResult)
                {
                    category.Banner = _cloudinaryService.BuildUrl(category.Banner);
                }
                return new SuccessDataResult<IEnumerable<CategoryLangClientDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<IEnumerable<CategoryLangClientDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<CategoryGetLangDto> GetCategoryById(long categoryId, string acceptedLanguage)
        {
            try
            {
                var response = _categoryDal.GetCategoryById(categoryId,acceptedLanguage);
                var mappingResult = _mapper.Map<CategoryLanguage, CategoryGetLangDto>(response);
                mappingResult.Category.BannerCloudinaryUrl = _cloudinaryService.BuildUrl(response.Category.Banner);

                return new SuccessDataResult<CategoryGetLangDto>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<CategoryGetLangDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }
    }
}
