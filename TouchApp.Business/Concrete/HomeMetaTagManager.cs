using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.Libs;
using Business.ValidationRules.FluentValidation.Home;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Entities.Dtos.Home;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Core.Utilities.Services.Rest;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class HomeMetaTagManager : IHomeMetaTagService
    {
        private readonly IHomeMetaTagDal _homeMetaTagDal;
        private readonly IMapper _mapper;

        private readonly IHomeMetaTagLanguageService _homeMetaTagLanguageService;
        private readonly IHomeMetaTagGalleryService _homeMetaTagGalleryService;
        private readonly IHomeMetaTagSectionService _homeMetaTagSectionService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IFileManager _fileManager;
        private readonly ICloudinaryService _cloudinaryService;

        public HomeMetaTagManager(IHomeMetaTagDal homeMetaTagDal, IMapper mapper, IHomeMetaTagLanguageService homeMetaTagLanguageService, IHomeMetaTagGalleryService homeMetaTagGalleryService, IHomeMetaTagSectionService homeMetaTagSectionService, IHttpContextAccessor httpContextAccessor, ICloudinaryService cloudinaryService, IFileManager fileManager)
        {
            _homeMetaTagDal = homeMetaTagDal;
            _mapper = mapper;
            _homeMetaTagLanguageService = homeMetaTagLanguageService;
            _homeMetaTagGalleryService = homeMetaTagGalleryService;
            _homeMetaTagSectionService = homeMetaTagSectionService;
            _httpContext = httpContextAccessor;
            _cloudinaryService = cloudinaryService;
            _fileManager = fileManager;
        }

        [ValidationAspect(typeof(CreateHomeMetaTagDtoValidator))]
        public IDataResult<int> Add(CreateHomeMetaTagDto createHomeMetaTagDto)
        {
            try
            {
                var homeMetaTag = _mapper.Map<CreateHomeMetaTagDto, HomeMetaTag>(createHomeMetaTagDto);

                homeMetaTag.Created_at = DateTime.Now;
                homeMetaTag.Modified_at = DateTime.Now;
                homeMetaTag.Created_by = _httpContext.HttpContext.User.Identity.Name;
                homeMetaTag.Modified_by = _httpContext.HttpContext.User.Identity.Name;
                homeMetaTag.IsActive = true;

                int affectedRows = _homeMetaTagDal.Add(homeMetaTag);
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
                return new ErrorDataResult<int>(-1, $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> DeleteByStatus(long Id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = _homeMetaTagDal.GetItemWithInclude(x => x.Id == Id & x.IsActive == true);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;

                int affectedRows = _homeMetaTagDal.DeleteByStatus(deletableEntity);

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
                return new ErrorDataResult<int>(-1, $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> DeletePermanently(long Id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = _homeMetaTagDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _homeMetaTagDal.DeletePermanently(deletableEntity);
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
                return new ErrorDataResult<int>(-1, $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<GetHomeMetaTagDto> Get(Expression<Func<HomeMetaTag, bool>> filter)
        {
            try
            {
                var responseDB = _homeMetaTagDal.Get(filter);

                var response = _mapper.Map<HomeMetaTag, GetHomeMetaTagDto>(responseDB);

                foreach (var currentOne in response.HomeMetaTagGalleries)
                {
                    currentOne.Url = _cloudinaryService.BuildUrl(currentOne.Url);
                }

                return new SuccessDataResult<GetHomeMetaTagDto>(response);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetHomeMetaTagDto>(null, $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<IEnumerable<HomeMetaTag>> GetList(Expression<Func<HomeMetaTag, bool>> filter = null)
        {
            try
            {
                var response = _homeMetaTagDal.GetList(filter);
                return new SuccessDataResult<IEnumerable<HomeMetaTag>>(response);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<IEnumerable<HomeMetaTag>>(null, $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> Update(EditHomeMetaTagDto editHomeMetaTagDto)
        {
            try
            {
                HomeMetaTag dbHomeMetaTag = _homeMetaTagDal.GetItemWithInclude(x => x.Id == editHomeMetaTagDto.Id);
                List<string> deletableFiles = new List<string>();

                dbHomeMetaTag.Modified_at = DateTime.Now;
                dbHomeMetaTag.Modified_by = _httpContext.HttpContext.User.Identity.Name;

                if (dbHomeMetaTag.HomeMetaTagGalleries != null)
                {
                    foreach (var currentOne in editHomeMetaTagDto.HomeMetaTagGalleries)
                    {
                        var existGalleryOne = dbHomeMetaTag.HomeMetaTagGalleries.FirstOrDefault(x => x.Id == currentOne.Id);
                        existGalleryOne.IsActive = currentOne.IsActive;
                        existGalleryOne.Order = currentOne.Order;
                        if ((currentOne.Url.Split("/").Reverse().ToList()[0] != "string" || currentOne.Url.Split("/").Reverse().ToList()[0] != string.Empty) && existGalleryOne.Url != currentOne.Url)
                        {
                            deletableFiles.Add(existGalleryOne.Url);
                        }
                    }
                }

                if (dbHomeMetaTag.HomeMetaTagLanguages != null)
                {
                    foreach (var currentOne in editHomeMetaTagDto.HomeMetaTagLanguages)
                    {
                        var existLangOne = dbHomeMetaTag.HomeMetaTagLanguages.FirstOrDefault(x => x.Id == currentOne.Id);
                        existLangOne.IsActive = currentOne.IsActive;
                        existLangOne.Keywords = currentOne.Keywords;
                        existLangOne.LanguageId = currentOne.LanguageId ?? default;
                        existLangOne.MetaDescription = currentOne.MetaDescription;
                        existLangOne.MetaTitle = currentOne.MetaTitle;
                        existLangOne.SearchKeyword = currentOne.SearchKeyword;
                        existLangOne.Tag = currentOne.Tag;
                    }
                }

                int affectedRows = _homeMetaTagDal.Commit();
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    foreach (var deletableOne in deletableFiles)
                    {
                        _cloudinaryService.Delete(deletableOne);
                    }
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
                return new ErrorDataResult<int>(-1, $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}");
            }
        }


        public IDataResult<int> UpdateList(IEnumerable<HomeMetaTag> homeMetaTags)
        {
            try
            {
                int affectedRows = _homeMetaTagDal.Update(homeMetaTags);
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
        public IDataResult<int> AddList(IEnumerable<CreateHomeMetaTagDto> createHomeMetaTagDtos)
        {
            try
            {
                var homeMetaTags = _mapper.Map<IEnumerable<CreateHomeMetaTagDto>, IEnumerable<HomeMetaTag>>(createHomeMetaTagDtos);

                foreach (var homeMetaTag in homeMetaTags)
                {
                    homeMetaTag.Created_at = DateTime.Now;
                    homeMetaTag.Modified_at = DateTime.Now;
                    homeMetaTag.Created_by = _httpContext.HttpContext.User.Identity.Name;
                    homeMetaTag.Modified_by = _httpContext.HttpContext.User.Identity.Name;
                    homeMetaTag.IsActive = true;

                    foreach (var currentOne in homeMetaTag.HomeMetaTagGalleries)
                    {
                        if (currentOne.Url != null)
                        {
                            var urlPhoto = _cloudinaryService.StoreImage(currentOne.Url);

                            _fileManager.Delete(currentOne.Url);

                            currentOne.Url = urlPhoto;
                        }
                    }
                }

                int affectedRows = _homeMetaTagDal.Add(homeMetaTags);
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
        public IDataResult<int> DeleteByStatusList(IEnumerable<HomeMetaTag> homeMetaTags)
        {
            try
            {
                foreach (var homeMetaTag in homeMetaTags)
                {
                    homeMetaTag.IsActive = false;
                }

                DeleteAllEntitiesByStatusForAllRelationList(homeMetaTags);

                int affectedRows = _homeMetaTagDal.DeleteByStatus(homeMetaTags);

                IDataResult<int> dataResult;
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
        public IDataResult<int> DeletePermanentlyList(IEnumerable<HomeMetaTag> homeMetaTags)
        {
            try
            {
                int affectedRows = _homeMetaTagDal.DeletePermanently(homeMetaTags);
                IDataResult<int> dataResult;
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

        private void DeleteAllEntitiesByStatusForAllRelationList(IEnumerable<HomeMetaTag> homeMetaTags)
        {
            foreach (var homeMetaTag in homeMetaTags)
            {
                if (homeMetaTag.HomeMetaTagGalleries != null)
                {
                    _homeMetaTagGalleryService.DeleteByStatusList(homeMetaTag.HomeMetaTagGalleries);
                }

                if (homeMetaTag.HomeMetaTagSections != null)
                {
                    _homeMetaTagSectionService.DeleteByStatusList(homeMetaTag.HomeMetaTagSections);
                }

                if (homeMetaTag.HomeMetaTagLanguages != null)
                {
                    _homeMetaTagLanguageService.DeleteByStatusList(homeMetaTag.HomeMetaTagLanguages);
                }
            }
        }

        private void DeleteByStatusForAllRelation(HomeMetaTag homeMetaTag)
        {
            if (homeMetaTag.HomeMetaTagGalleries != null)
            {
                _homeMetaTagGalleryService.DeleteByStatusList(homeMetaTag.HomeMetaTagGalleries);
            }

            if (homeMetaTag.HomeMetaTagSections != null)
            {
                _homeMetaTagSectionService.DeleteByStatusList(homeMetaTag.HomeMetaTagSections);
            }

            if (homeMetaTag.HomeMetaTagLanguages != null)
            {
                _homeMetaTagLanguageService.DeleteByStatusList(homeMetaTag.HomeMetaTagLanguages);
            }
        }

        public IDataResult<GetHomeMetaTagDto> GetItemWithInclude(Expression<Func<HomeMetaTag, bool>> filter)
        {
            try
            {
                var responseDB = _homeMetaTagDal.GetItemWithInclude(filter);

                var response = _mapper.Map<GetHomeMetaTagDto>(responseDB);

                foreach (var currentOne in response.HomeMetaTagGalleries)
                {
                    currentOne.CloudinaryUrl = _cloudinaryService.BuildUrl(currentOne.Url);
                }

                return new SuccessDataResult<GetHomeMetaTagDto>(response);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetHomeMetaTagDto>(null, $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<IEnumerable<GetHomeMetaTagDto>> GetAllItemsWithInclude(Expression<Func<HomeMetaTag, bool>> filter = null)
        {
            try
            {
                var responseDB = _homeMetaTagDal.GetAllItemsWithInclude(filter);

                var response = _mapper.Map<IEnumerable<GetHomeMetaTagDto>>(responseDB);

                foreach (var item in response)
                {
                    foreach (var gallery in item.HomeMetaTagGalleries)
                    {
                        gallery.CloudinaryUrl = _cloudinaryService.BuildUrl(gallery.Url);
                    }
                }

                return new SuccessDataResult<IEnumerable<GetHomeMetaTagDto>>(response);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<IEnumerable<GetHomeMetaTagDto>>(null, $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<IEnumerable<GetHomeMetaTagDto>> GetAllItemsWithIncludeByLang(long langID, Expression<Func<HomeMetaTag, bool>> filter = null)
        {
            try
            {
                List<GetHomeMetaTagDto> result = new List<GetHomeMetaTagDto>();
                var response = _homeMetaTagDal.GetAllItemsWithInclude(filter);

                foreach (var item in response)
                {
                    List<GetHomeMetaTagLangDto> checkLang = (List<GetHomeMetaTagLangDto>)item.HomeMetaTagLanguages.Where(x => x.LanguageId == langID);
                    var resultGetHomeDto = new GetHomeMetaTagDto
                    {
                        Id = item.Id,
                        Created_at = item.Created_at,
                        Created_by = item.Created_by,
                        HomeMetaTagGalleries = (IEnumerable<GetHomeMetaTagGalleryDto>)item.HomeMetaTagGalleries,
                        HomeMetaTagLanguages = checkLang
                    };
                    result.Add(resultGetHomeDto);
                }
                return new SuccessDataResult<IEnumerable<GetHomeMetaTagDto>>(result);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<IEnumerable<GetHomeMetaTagDto>>(null, $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<bool> CheckIsExist(long id)
        {
            bool isExist = false;

            var data = _homeMetaTagDal.Get(x => x.Id == id & x.IsActive);
            if (data != null) isExist = true;

            return new SuccessDataResult<bool>(isExist);
        }
    }
}
