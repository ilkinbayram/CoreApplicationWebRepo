using AutoMapper;
using Business.Constants;
using Business.Libs;
using Core.Entities.Concrete;
using Core.Entities.Dtos.FieUploud;
using Core.Entities.Dtos.OurService;
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
    public class CourseServiceManager : ICourseServiceService
    {
        private readonly ICourseServiceDal _courseServiceDal;
        private readonly IMapper _mapper;

        private readonly IFileManager _fileManager;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly ILocalizationDal _localizationDal;

        public CourseServiceManager(ICourseServiceDal courseServiceDal,
                                    IMapper mapper,
                                    IFileManager fileManager,
                                    ICloudinaryService cloudinaryService,
                                    ILocalizationDal localizationDal)
        {
            _courseServiceDal = courseServiceDal;
            _mapper = mapper;
            _fileManager = fileManager;
            _cloudinaryService = cloudinaryService;
            _localizationDal = localizationDal;
        }

        public IDataResult<int> Add(CreateManagementCourseServiceDto courseService)
        {
            try
            {
                var fileUploadResult = _fileManager.UploadSaveDictionary(courseService.IconSourceFile);

                if (!fileUploadResult.Success)
                    return new ErrorDataResult<int>(-1, fileUploadResult.Message);

                var publicId = _cloudinaryService.StoreImage(fileUploadResult.Data["imagePath"]);

                var result = new FileName()
                {
                    FilePath = fileUploadResult.Data["imagePath"],
                    CdnPath = _cloudinaryService.BuildUrl(publicId),
                    PublicId = publicId
                };

                _fileManager.Delete(fileUploadResult.Data["imagePath"]);

                courseService.IconSource = result.CdnPath;

                var mappedModel = _mapper.Map<CourseService>(courseService);

                int affectedRows = _courseServiceDal.Add(mappedModel);

                var localizationList = GeneralFunctionality.ConvertModelToLocalizationList(courseService);

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
                return new ErrorDataResult<int>(-500, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> DeleteByStatus(long Id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = _courseServiceDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = _courseServiceDal.DeleteByStatus(deletableEntity);

                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataDeleted);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotDeleted);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> DeletePermanently(long Id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = _courseServiceDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _courseServiceDal.DeletePermanently(deletableEntity);
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataDeleted);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotDeleted);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<CourseService> Get(Expression<Func<CourseService, bool>> filter)
        {
            try
            {
                var response = _courseServiceDal.Get(filter);
                var mappingResult = _mapper.Map<CourseService>(response);
                return new SuccessDataResult<CourseService>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<CourseService>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<CourseService>> GetList(Expression<Func<CourseService, bool>> filter = null)
        {
            try
            {
                var response = _courseServiceDal.GetList(filter);
                var mappingResult = _mapper.Map<List<CourseService>>(response);
                return new SuccessDataResult<List<CourseService>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<CourseService>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> Update(CourseService courseService)
        {
            try
            {
                int affectedRows = _courseServiceDal.Update(courseService);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataUpdated);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotUpdated);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }



        public IDataResult<int> AddList(List<CourseService> courseServices)
        {
            try
            {
                int affectedRows = _courseServiceDal.Add(courseServices);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> UpdateList(List<CourseService> courseServices)
        {
            try
            {
                int affectedRows = _courseServiceDal.Update(courseServices);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> DeletePermanentlyList(List<CourseService> courseServices)
        {
            try
            {
                int affectedRows = _courseServiceDal.DeletePermanently(courseServices);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> DeleteByStatusList(List<CourseService> courseServices)
        {
            try
            {
                foreach (var courseService in courseServices)
                {
                    courseService.IsActive = false;
                }

                DeleteAllEntitiesByStatusForAllRelationList(courseServices);

                int affectedRows = _courseServiceDal.DeleteByStatus(courseServices);

                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        private void DeleteAllEntitiesByStatusForAllRelationList(List<CourseService> courseServices)
        {
            foreach (var courseService in courseServices)
            {
            }
        }

        private void DeleteByStatusForAllRelation(CourseService courseService)
        {
        }

        public IDataResult<GetCourseServiceDto> GetDto(Expression<Func<CourseService, bool>> filter = null)
        {
            try
            {
                var response = _courseServiceDal.Get(filter);
                var mappedModel = _mapper.Map<GetCourseServiceDto>(response);
                return new SuccessDataResult<GetCourseServiceDto>(mappedModel);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetCourseServiceDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<GetCourseServiceDto>> GetDtoList(Expression<Func<CourseService, bool>> filter = null, int takeCount = 2000)
        {
            try
            {
                var dtoListResult = new List<GetCourseServiceDto>();
                _courseServiceDal.GetList(filter).Take(takeCount).ToList().ForEach(x =>
                {
                    dtoListResult.Add(_mapper.Map<GetCourseServiceDto>(x));
                });

                return new SuccessDataResult<List<GetCourseServiceDto>>(dtoListResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetCourseServiceDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        #region Asynchronous

        public async Task<IDataResult<int>> AddAsync(CourseService courseService)
        {
            try
            {
                int affectedRows = await _courseServiceDal.AddAsync(courseService);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> DeleteByStatusAsync(long Id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = await _courseServiceDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = await _courseServiceDal.DeleteByStatusAsync(deletableEntity);

                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataDeleted);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotDeleted);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> DeletePermanentlyAsync(long Id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = await _courseServiceDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = await _courseServiceDal.DeletePermanentlyAsync(deletableEntity);
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataDeleted);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotDeleted);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<CourseService>> GetAsync(Expression<Func<CourseService, bool>> filter)
        {
            try
            {
                var response = await _courseServiceDal.GetAsync(filter);
                var mappingResult = _mapper.Map<CourseService>(response);
                return new SuccessDataResult<CourseService>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<CourseService>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<CourseService>>> GetListAsync(Expression<Func<CourseService, bool>> filter = null)
        {
            try
            {
                var response = (await _courseServiceDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<CourseService>>(response);
                return new SuccessDataResult<List<CourseService>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<CourseService>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> UpdateAsync(CourseService courseService)
        {
            try
            {
                int affectedRows = await _courseServiceDal.UpdateAsync(courseService);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataUpdated);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotUpdated);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> AddListAsync(List<CourseService> courseServices)
        {
            try
            {
                int affectedRows = await _courseServiceDal.AddAsync(courseServices);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> UpdateListAndSaveAsync(List<CourseService> courseServices)
        {
            try
            {
                int affectedRows = await _courseServiceDal.UpdateAndSaveAsync(courseServices);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> DeletePermanentlyListAsync(List<CourseService> courseServices)
        {
            try
            {
                int affectedRows = await _courseServiceDal.DeletePermanentlyAsync(courseServices);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<GetCourseServiceDto>> GetDtoAsync(Expression<Func<CourseService, bool>> filter = null)
        {
            try
            {
                var response = await _courseServiceDal.GetAsync(filter);
                var mappingResult = _mapper.Map<GetCourseServiceDto>(response);
                return new SuccessDataResult<GetCourseServiceDto>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetCourseServiceDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<GetCourseServiceDto>>> GetDtoListAsync(Expression<Func<CourseService, bool>> filter = null, int takeCount = 2000)
        {
            try
            {
                var response = (await _courseServiceDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<GetCourseServiceDto>>(response).Take(takeCount).ToList();
                return new SuccessDataResult<List<GetCourseServiceDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetCourseServiceDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        #endregion
    }
}
