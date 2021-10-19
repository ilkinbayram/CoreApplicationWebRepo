using AutoMapper;
using Business.Constants;
using Business.Libs;
using Core.Entities.Concrete;
using Core.Entities.Dtos.FieUploud;
using Core.Entities.Dtos.ProfessionCourseCategory;
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
    public class ProfessionCourseCategoryManager : IProfessionCourseCategoryService
    {
        private readonly IProfessionCourseCategoryDal _professionCourseCategoryDal;
        private readonly IMapper _mapper;

        private readonly IFileManager _fileManager;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly ILocalizationDal _localizationDal;

        public ProfessionCourseCategoryManager(IProfessionCourseCategoryDal professionCourseCategoryDal, 
                                               IMapper mapper,
                                               IFileManager fileManager,
                                               ICloudinaryService cloudinaryService,
                                               ILocalizationDal localizationDal)
        {
            _professionCourseCategoryDal = professionCourseCategoryDal;
            _mapper = mapper;
            _fileManager = fileManager;
            _cloudinaryService = cloudinaryService;
            _localizationDal = localizationDal;
        }

        public IDataResult<int> Add(CreateManagementProfessionCourseCategoryDto professionCourseCategory)
        {
            try
            {
                if (professionCourseCategory.IconFile != null)
                {

                    var listFileListAdded = new List<string>();

                    var fileUploadResult = _fileManager.UploadThumbnail(professionCourseCategory.IconFile);

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

                    professionCourseCategory.IconSource = result.CdnPath;

                }

                var mappedModel = _mapper.Map<ProfessionCourseCategory>(professionCourseCategory);

                int affectedRows = _professionCourseCategoryDal.Add(mappedModel);

                var localizationList = GeneralFunctionality.ConvertModelToLocalizationList(professionCourseCategory);

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

                var deletableEntity = _professionCourseCategoryDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = _professionCourseCategoryDal.DeleteByStatus(deletableEntity);

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

                var deletableEntity = _professionCourseCategoryDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _professionCourseCategoryDal.DeletePermanently(deletableEntity);
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

        public IDataResult<ProfessionCourseCategory> Get(Expression<Func<ProfessionCourseCategory, bool>> filter)
        {
            try
            {
                var response = _professionCourseCategoryDal.Get(filter);
                var mappingResult = _mapper.Map<ProfessionCourseCategory>(response);
                return new SuccessDataResult<ProfessionCourseCategory>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<ProfessionCourseCategory>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<GetProfessionCourseCategoryDto> GetDto(Expression<Func<ProfessionCourseCategory, bool>> filter = null)
        {
            try
            {
                var response = _professionCourseCategoryDal.Get(filter);
                var mappedModel = _mapper.Map<GetProfessionCourseCategoryDto>(response);
                return new SuccessDataResult<GetProfessionCourseCategoryDto>(mappedModel);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetProfessionCourseCategoryDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<GetProfessionCourseCategoryDto>> GetListDto(Expression<Func<ProfessionCourseCategory, bool>> filter = null)
        {
            try
            {
                var dtoListResult = new List<GetProfessionCourseCategoryDto>();
                _professionCourseCategoryDal.GetList(filter).ForEach(x =>
                {
                    dtoListResult.Add(_mapper.Map<GetProfessionCourseCategoryDto>(x));
                });

                return new SuccessDataResult<List<GetProfessionCourseCategoryDto>>(dtoListResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetProfessionCourseCategoryDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<ProfessionCourseCategory>> GetList(Expression<Func<ProfessionCourseCategory, bool>> filter = null)
        {
            try
            {
                var response = _professionCourseCategoryDal.GetList(filter);
                var mappingResult = _mapper.Map<List<ProfessionCourseCategory>>(response);
                return new SuccessDataResult<List<ProfessionCourseCategory>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<ProfessionCourseCategory>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> Update(ProfessionCourseCategory professionCourseCategory)
        {
            try
            {
                int affectedRows = _professionCourseCategoryDal.Update(professionCourseCategory);
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



        public IDataResult<int> AddList(List<ProfessionCourseCategory> professionCourseCategorys)
        {
            try
            {
                int affectedRows = _professionCourseCategoryDal.Add(professionCourseCategorys);
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

        public IDataResult<int> UpdateList(List<ProfessionCourseCategory> professionCourseCategorys)
        {
            try
            {
                int affectedRows = _professionCourseCategoryDal.Update(professionCourseCategorys);
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

        public IDataResult<int> DeletePermanentlyList(List<ProfessionCourseCategory> professionCourseCategorys)
        {
            try
            {
                int affectedRows = _professionCourseCategoryDal.DeletePermanently(professionCourseCategorys);
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

        public IDataResult<int> DeleteByStatusList(List<ProfessionCourseCategory> professionCourseCategorys)
        {
            try
            {
                foreach (var professionCourseCategory in professionCourseCategorys)
                {
                    professionCourseCategory.IsActive = false;
                }

                DeleteAllEntitiesByStatusForAllRelationList(professionCourseCategorys);

                int affectedRows = _professionCourseCategoryDal.DeleteByStatus(professionCourseCategorys);

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

        private void DeleteAllEntitiesByStatusForAllRelationList(List<ProfessionCourseCategory> professionCourseCategorys)
        {
            foreach (var professionCourseCategory in professionCourseCategorys)
            {
            }
        }

        private void DeleteByStatusForAllRelation(ProfessionCourseCategory professionCourseCategory)
        {
        }



        #region Asynchronous

        public async Task<IDataResult<int>> AddAsync(ProfessionCourseCategory professionCourseCategory)
        {
            try
            {
                int affectedRows = await _professionCourseCategoryDal.AddAsync(professionCourseCategory);
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

                var deletableEntity = await _professionCourseCategoryDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = await _professionCourseCategoryDal.DeleteByStatusAsync(deletableEntity);

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

                var deletableEntity = await _professionCourseCategoryDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = await _professionCourseCategoryDal.DeletePermanentlyAsync(deletableEntity);
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

        public async Task<IDataResult<ProfessionCourseCategory>> GetAsync(Expression<Func<ProfessionCourseCategory, bool>> filter)
        {
            try
            {
                var response = await _professionCourseCategoryDal.GetAsync(filter);
                var mappingResult = _mapper.Map<ProfessionCourseCategory>(response);
                return new SuccessDataResult<ProfessionCourseCategory>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<ProfessionCourseCategory>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<ProfessionCourseCategory>>> GetListAsync(Expression<Func<ProfessionCourseCategory, bool>> filter = null)
        {
            try
            {
                var response = (await _professionCourseCategoryDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<ProfessionCourseCategory>>(response);
                return new SuccessDataResult<List<ProfessionCourseCategory>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<ProfessionCourseCategory>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> UpdateAsync(ProfessionCourseCategory professionCourseCategory)
        {
            try
            {
                int affectedRows = await _professionCourseCategoryDal.UpdateAsync(professionCourseCategory);
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

        public async Task<IDataResult<int>> AddListAsync(List<ProfessionCourseCategory> professionCourseCategories)
        {
            try
            {
                int affectedRows = await _professionCourseCategoryDal.AddAsync(professionCourseCategories);
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

        public async Task<IDataResult<int>> UpdateListAndSaveAsync(List<ProfessionCourseCategory> professionCourseCategories)
        {
            try
            {
                int affectedRows = await _professionCourseCategoryDal.UpdateAndSaveAsync(professionCourseCategories);
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

        public async Task<IDataResult<int>> DeletePermanentlyListAsync(List<ProfessionCourseCategory> professionCourseCategories)
        {
            try
            {
                int affectedRows = await _professionCourseCategoryDal.DeletePermanentlyAsync(professionCourseCategories);
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

        public async Task<IDataResult<GetProfessionCourseCategoryDto>> GetDtoAsync(Expression<Func<ProfessionCourseCategory, bool>> filter = null)
        {
            try
            {
                var response = await _professionCourseCategoryDal.GetAsync(filter);
                var mappingResult = _mapper.Map<GetProfessionCourseCategoryDto>(response);
                return new SuccessDataResult<GetProfessionCourseCategoryDto>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetProfessionCourseCategoryDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<GetProfessionCourseCategoryDto>>> GetDtoListAsync(Expression<Func<ProfessionCourseCategory, bool>> filter = null, int takeCount = 2000)
        {
            try
            {
                var response = (await _professionCourseCategoryDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<GetProfessionCourseCategoryDto>>(response).Take(takeCount).ToList();
                return new SuccessDataResult<List<GetProfessionCourseCategoryDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetProfessionCourseCategoryDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        
        #endregion
    }
}
