using AutoMapper;
using Business.Constants;
using Business.Libs;
using Core.Entities.Concrete;
using Core.Entities.Dtos.BlogCategory;
using Core.Entities.Dtos.FieUploud;
using Core.Utilities.Results;
using Core.Utilities.Services.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;
using TouchApp.Business.BusinessHelper;
using TouchApp.DataAccess.Abstract;

namespace Business.Concrete
{
    public class BlogCategoryManager : IBlogCategoryService
    {
        private readonly IBlogCategoryDal _blogCategoryDal;
        private readonly IMapper _mapper;
        private readonly IFileManager _fileManager;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly ILocalizationDal _localizationDal;

        public BlogCategoryManager(IBlogCategoryDal blogCategoryDal,
                                   IMapper mapper,
                                   IFileManager fileManager,
                                   ICloudinaryService cloudinaryService,
                                   ILocalizationDal localizationDal)
        {
            _blogCategoryDal = blogCategoryDal;
            _mapper = mapper;
            _fileManager = fileManager;
            _cloudinaryService = cloudinaryService;
            _localizationDal = localizationDal;
        }

        public IDataResult<int> Add(CreateBlogCategoryManagementDto blogCategory)
        {
            try
            {
                if (blogCategory.IconFile != null)
                {

                    var listFileListAdded = new List<string>();

                    var fileUploadResult = _fileManager.UploadThumbnail(blogCategory.IconFile);

                    if (!fileUploadResult.Success)
                        return new ErrorDataResult<int>(-1, fileUploadResult.Message);

                    var publicId = _cloudinaryService.StoreImage(fileUploadResult.Data["thumbnailPath"]);

                    var result = new FileName()
                    {
                        FilePath = fileUploadResult.Data["thumbnailPath"],
                        CdnPath = _cloudinaryService.BuildUrl(publicId),
                        PublicId = publicId
                    };

                    _fileManager.Delete(fileUploadResult.Data["imagePath"]);
                    _fileManager.Delete(fileUploadResult.Data["thumbnailPath"]);

                    listFileListAdded.Add(publicId);

                    blogCategory.IconSource = result.CdnPath;

                }

                var mappedModel = _mapper.Map<BlogCategory>(blogCategory);

                int affectedRows = _blogCategoryDal.Add(mappedModel);

                var localizationList = GeneralFunctionality.ConvertModelToLocalizationList(blogCategory);

                foreach (var localizationOne in localizationList)
                {
                    var responseAddLocalization = _localizationDal.Add(localizationOne);
                    if (responseAddLocalization <= 0)
                        throw new Exception(Messages.ErrorMessages.NOT_ADDED_AND_ROLLED_BACK);
                }

                if (affectedRows <= 0)
                    throw new Exception(Messages.ErrorMessages.NOT_ADDED_AND_ROLLED_BACK);

                return new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> DeleteByStatus(long Id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = _blogCategoryDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = _blogCategoryDal.DeleteByStatus(deletableEntity);

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

        public IDataResult<int> DeletePermanently(long Id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = _blogCategoryDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _blogCategoryDal.DeletePermanently(deletableEntity);
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

        public IDataResult<BlogCategory> Get(Expression<Func<BlogCategory, bool>> filter)
        {
            try
            {
                var response = _blogCategoryDal.Get(filter);
                var mappingResult = _mapper.Map<BlogCategory>(response);
                return new SuccessDataResult<BlogCategory>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<BlogCategory>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<GetBlogCategoryDto> GetDto(Expression<Func<BlogCategory, bool>> filter = null)
        {
            try
            {
                var response = _blogCategoryDal.Get(filter);
                var mappedModel = _mapper.Map<GetBlogCategoryDto>(response);
                return new SuccessDataResult<GetBlogCategoryDto>(mappedModel);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetBlogCategoryDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<BlogCategory>> GetList(Expression<Func<BlogCategory, bool>> filter = null)
        {
            try
            {
                var response = _blogCategoryDal.GetList(filter);
                var mappingResult = _mapper.Map<List<BlogCategory>>(response);
                return new SuccessDataResult<List<BlogCategory>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<BlogCategory>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<GetBlogCategoryDto>> GetListDto(Expression<Func<BlogCategory, bool>> filter = null)
        {
            try
            {
                var dtoListResult = new List<GetBlogCategoryDto>();
                _blogCategoryDal.GetList(filter).ForEach(x =>
                {
                    dtoListResult.Add(_mapper.Map<GetBlogCategoryDto>(x));
                });

                return new SuccessDataResult<List<GetBlogCategoryDto>>(dtoListResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetBlogCategoryDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> Update(BlogCategory blogCategory)
        {
            try
            {
                int affectedRows = _blogCategoryDal.Update(blogCategory);
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



        public IDataResult<int> AddList(List<BlogCategory> blogCategorys)
        {
            try
            {
                int affectedRows = _blogCategoryDal.Add(blogCategorys);
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

        public IDataResult<int> UpdateList(List<BlogCategory> blogCategorys)
        {
            try
            {
                int affectedRows = _blogCategoryDal.Update(blogCategorys);
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

        public IDataResult<int> DeletePermanentlyList(List<BlogCategory> blogCategorys)
        {
            try
            {
                int affectedRows = _blogCategoryDal.DeletePermanently(blogCategorys);
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

        public IDataResult<int> DeleteByStatusList(List<BlogCategory> blogCategorys)
        {
            try
            {
                foreach (var blogCategory in blogCategorys)
                {
                    blogCategory.IsActive = false;
                }

                DeleteAllEntitiesByStatusForAllRelationList(blogCategorys);

                int affectedRows = _blogCategoryDal.DeleteByStatus(blogCategorys);

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

        private void DeleteAllEntitiesByStatusForAllRelationList(List<BlogCategory> blogCategorys)
        {
            foreach (var blogCategory in blogCategorys)
            {
            }
        }

        private void DeleteByStatusForAllRelation(BlogCategory blogCategory)
        {
        }




        #region Asynchronous

        public async Task<IDataResult<int>> AddAsync(BlogCategory blogCategory)
        {
            try
            {
                int affectedRows = await _blogCategoryDal.AddAsync(blogCategory);
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

        public async Task<IDataResult<int>> DeleteByStatusAsync(long Id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = await _blogCategoryDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = await _blogCategoryDal.DeleteByStatusAsync(deletableEntity);

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

        public async Task<IDataResult<int>> DeletePermanentlyAsync(long Id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = await _blogCategoryDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = await _blogCategoryDal.DeletePermanentlyAsync(deletableEntity);
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

        public async Task<IDataResult<BlogCategory>> GetAsync(Expression<Func<BlogCategory, bool>> filter)
        {
            try
            {
                var response = await _blogCategoryDal.GetAsync(filter);
                var mappingResult = _mapper.Map<BlogCategory>(response);
                return new SuccessDataResult<BlogCategory>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<BlogCategory>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<BlogCategory>>> GetListAsync(Expression<Func<BlogCategory, bool>> filter = null)
        {
            try
            {
                var response = (await _blogCategoryDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<BlogCategory>>(response);
                return new SuccessDataResult<List<BlogCategory>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<BlogCategory>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> UpdateAsync(BlogCategory blogCategory)
        {
            try
            {
                int affectedRows = await _blogCategoryDal.UpdateAsync(blogCategory);
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

        public async Task<IDataResult<int>> AddListAsync(List<BlogCategory> blogCategories)
        {
            try
            {
                int affectedRows = await _blogCategoryDal.AddAsync(blogCategories);
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

        public async Task<IDataResult<int>> UpdateListAndSaveAsync(List<BlogCategory> blogCategories)
        {
            try
            {
                int affectedRows = await _blogCategoryDal.UpdateAndSaveAsync(blogCategories);
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

        public async Task<IDataResult<int>> DeletePermanentlyListAsync(List<BlogCategory> blogCategories)
        {
            try
            {
                int affectedRows = await _blogCategoryDal.DeletePermanentlyAsync(blogCategories);
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

        public async Task<IDataResult<GetBlogCategoryDto>> GetDtoAsync(Expression<Func<BlogCategory, bool>> filter = null)
        {
            try
            {
                var response = await _blogCategoryDal.GetAsync(filter);
                var mappingResult = _mapper.Map<GetBlogCategoryDto>(response);
                return new SuccessDataResult<GetBlogCategoryDto>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetBlogCategoryDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<GetBlogCategoryDto>>> GetDtoListAsync(Expression<Func<BlogCategory, bool>> filter = null, int takeCount = 2000)
        {
            try
            {
                var response = (await _blogCategoryDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<GetBlogCategoryDto>>(response).Take(takeCount).ToList();
                return new SuccessDataResult<List<GetBlogCategoryDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetBlogCategoryDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }
        #endregion
    }
}
