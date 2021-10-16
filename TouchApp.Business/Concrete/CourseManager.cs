using AutoMapper;
using Business.Constants;
using Business.Libs;
using Core.Entities.Concrete;
using Core.Entities.Dtos.Course;
using Core.Entities.Dtos.FieUploud;
using Core.Entities.Dtos.TeacherCourse;
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
    public class CourseManager : ICourseService
    {
        private readonly ICourseDal _courseDal;
        private readonly IMediaService _mediaService;
        private readonly IMapper _mapper;

        private readonly IFileManager _fileManager;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly ILocalizationDal _localizationDal;

        public CourseManager(ICourseDal courseDal, 
                             IMapper mapper, 
                             IMediaService mediaService,
                             IFileManager fileManager,
                             ICloudinaryService cloudinaryService,
                             ILocalizationDal localizationDal)
        {
            _courseDal = courseDal;
            _mapper = mapper;
            _mediaService = mediaService;
            _localizationDal = localizationDal;
            _cloudinaryService = cloudinaryService;
            _fileManager = fileManager;
        }

        public IDataResult<int> Add(CreateManagementCourseDto course)
        {
            try
            {
                var listFileListAdded = new List<string>();

                var fileUploadResult = _fileManager.UploadSaveDictionary(course.CaptionImageFile);

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

                listFileListAdded.Add(publicId);

                course.CaptionImageSource = result.CdnPath;

                course.TeacherCourses.Add(new CreateManagementTeacherCourseDto { TeacherId = course.TeacherId});

                var addCourseModel = _mapper.Map<Course>(course);

                int affectedRows = _courseDal.Add(addCourseModel);

                var localizationList = GeneralFunctionality.ConvertModelToLocalizationList(course);

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

                var deletableEntity = _courseDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = _courseDal.DeleteByStatus(deletableEntity);

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

                var deletableEntity = _courseDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _courseDal.DeletePermanently(deletableEntity);
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

        public IDataResult<Course> Get(Expression<Func<Course, bool>> filter)
        {
            try
            {
                var response = _courseDal.Get(filter);
                var mappingResult = _mapper.Map<Course>(response);
                return new SuccessDataResult<Course>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<Course>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<Course>> GetList(Expression<Func<Course, bool>> filter = null)
        {
            try
            {
                var response = _courseDal.GetList(filter);
                var mappingResult = _mapper.Map<List<Course>>(response);
                return new SuccessDataResult<List<Course>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<Course>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> Update(Course course)
        {
            try
            {
                int affectedRows = _courseDal.Update(course);
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



        public IDataResult<int> AddList(List<Course> courses)
        {
            try
            {
                int affectedRows = _courseDal.Add(courses);
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

        public IDataResult<int> UpdateList(List<Course> courses)
        {
            try
            {
                int affectedRows = _courseDal.Update(courses);
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

        public IDataResult<int> DeletePermanentlyList(List<Course> courses)
        {
            try
            {
                int affectedRows = _courseDal.DeletePermanently(courses);
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

        public IDataResult<int> DeleteByStatusList(List<Course> courses)
        {
            try
            {
                foreach (var course in courses)
                {
                    course.IsActive = false;
                }

                DeleteAllEntitiesByStatusForAllRelationList(courses);

                int affectedRows = _courseDal.DeleteByStatus(courses);

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

        private void DeleteAllEntitiesByStatusForAllRelationList(List<Course> courses)
        {
            foreach (var course in courses)
            {
            }
        }

        private void DeleteByStatusForAllRelation(Course course)
        {
        }

        public IDataResult<GetCourseDto> GetDto(Expression<Func<Course, bool>> filter = null)
        {
            try
            {
                var response = _courseDal.GetWithRelations(filter);
                var mappedModel = _mapper.Map<GetCourseDto>(response);
                return new SuccessDataResult<GetCourseDto>(mappedModel);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetCourseDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<GetCourseDto>> GetDtoList(Expression<Func<Course, bool>> filter = null, int takeCount = 2000)
        {
            try
            {
                var dtoListResult = new List<GetCourseDto>();
                _courseDal.GetAllWithRelations(filter).Take(takeCount).ToList().ForEach(x =>
                {
                    dtoListResult.Add(_mapper.Map<GetCourseDto>(x));
                });

                return new SuccessDataResult<List<GetCourseDto>>(dtoListResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetCourseDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        #region Asynchronous

        public async Task<IDataResult<int>> AddAsync(Course course)
        {
            try
            {
                int affectedRows = await _courseDal.AddAsync(course);
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

                var deletableEntity = await _courseDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = await _courseDal.DeleteByStatusAsync(deletableEntity);

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

                var deletableEntity = await _courseDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = await _courseDal.DeletePermanentlyAsync(deletableEntity);
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

        public async Task<IDataResult<Course>> GetAsync(Expression<Func<Course, bool>> filter)
        {
            try
            {
                var response = await _courseDal.GetAsync(filter);
                var mappingResult = _mapper.Map<Course>(response);
                return new SuccessDataResult<Course>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<Course>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<Course>>> GetListAsync(Expression<Func<Course, bool>> filter = null)
        {
            try
            {
                var response = (await _courseDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<Course>>(response);
                return new SuccessDataResult<List<Course>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<Course>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> UpdateAsync(Course course)
        {
            try
            {
                int affectedRows = await _courseDal.UpdateAsync(course);
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

        public async Task<IDataResult<int>> AddListAsync(List<Course> courses)
        {
            try
            {
                int affectedRows = await _courseDal.AddAsync(courses);
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

        public async Task<IDataResult<int>> UpdateListAndSaveAsync(List<Course> courses)
        {
            try
            {
                int affectedRows = await _courseDal.UpdateAndSaveAsync(courses);
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

        public async Task<IDataResult<int>> DeletePermanentlyListAsync(List<Course> courses)
        {
            try
            {
                int affectedRows = await _courseDal.DeletePermanentlyAsync(courses);
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

        public async Task<IDataResult<GetCourseDto>> GetDtoAsync(Expression<Func<Course, bool>> filter = null)
        {
            try
            {
                var response = await _courseDal.GetAsync(filter);
                var mappingResult = _mapper.Map<GetCourseDto>(response);
                return new SuccessDataResult<GetCourseDto>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetCourseDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<GetCourseDto>>> GetDtoListAsync(Expression<Func<Course, bool>> filter = null, int takeCount = 2000)
        {
            try
            {
                var response = (await _courseDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<GetCourseDto>>(response).Take(takeCount).ToList();
                return new SuccessDataResult<List<GetCourseDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetCourseDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        #endregion
    }
}
