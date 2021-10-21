using AutoMapper;
using Business.Constants;
using Business.Libs;
using Core.Entities.Concrete;
using Core.Entities.Dtos.FieUploud;
using Core.Entities.Dtos.Teacher;
using Core.Entities.Dtos.TeacherSocialMedia;
using Core.Utilities.Results;
using Core.Utilities.Services.Rest;
using Microsoft.AspNetCore.Http;
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
    public class TeacherManager : ITeacherService
    {
        private readonly ITeacherDal _teacherDal;
        private readonly IMapper _mapper;

        private readonly IFileManager _fileManager;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly ILocalizationDal _localizationDal;

        public TeacherManager(ITeacherDal TeacherDal, 
                              IMapper mapper,
                              IFileManager fileManager,
                              ICloudinaryService cloudinaryService,
                              ILocalizationDal localizationDal)
        {
            _teacherDal = TeacherDal;
            _mapper = mapper;
            _fileManager = fileManager;
            _localizationDal = localizationDal;
            _cloudinaryService = cloudinaryService;
        }

        public IDataResult<int> Add(CreateManagementTeacherDto teacher)
        {
            try
            {
                List<IFormFile> fileList = new List<IFormFile>();
                fileList.Add(teacher.CaptionFile);
                fileList.Add(teacher.ProfilePhotoFile);
                fileList.Add(teacher.WallpaperFile);

                List<FileName> fileNames = new List<FileName>();

                var fileUploadResult = _fileManager.UploadListFileSaveDictionary(fileList);

                if (!fileUploadResult.Success)
                    return new ErrorDataResult<int>(-1, false, fileUploadResult.Responses);

                for (int i = 0; i < fileList.Count; i++)
                {
                    var publicId = _cloudinaryService.StoreImage(fileUploadResult.Data["imagePath"+i.ToString()]);

                    var result = new FileName()
                    {
                        FilePath = fileUploadResult.Data["imagePath" + i.ToString()],
                        CdnPath = _cloudinaryService.BuildUrl(publicId),
                        PublicId = publicId
                    };

                    fileNames.Add(result);

                    _fileManager.Delete(fileUploadResult.Data["imagePath" + i.ToString()]);
                }

                teacher.CaptionSource = fileNames[0].CdnPath;
                teacher.ProfilePhotoPath = fileNames[1].CdnPath;
                teacher.WallpaperPath = fileNames[2].CdnPath;

                var movieUploadResult = _fileManager.UploadVideoSaveDictionary(teacher.PreviewMovieFile);

                if (!movieUploadResult.Success)
                    return new ErrorDataResult<int>(-1, false, movieUploadResult.Responses);

                var publicVideoId = _cloudinaryService.StoreVideo(movieUploadResult.Data["videoPath"]);

                var resultVideo = new FileName()
                {
                    FilePath = movieUploadResult.Data["videoPath"],
                    CdnPath = _cloudinaryService.BuildUrlVideo(publicVideoId),
                    PublicId = publicVideoId
                };

                _fileManager.Delete(movieUploadResult.Data["videoPath"]);

                teacher.PreviewMoviePath = resultVideo.CdnPath;

                teacher.TeacherSocialMedias.Where(x => string.IsNullOrEmpty(x.RedirectUrl)).ToList().ForEach(x =>
                {
                    teacher.TeacherSocialMedias.Remove(x);
                });

                var addTeacherModel = _mapper.Map<Teacher>(teacher);

                int affectedRows = _teacherDal.Add(addTeacherModel);

                var localizationList = GeneralFunctionality.ConvertModelToLocalizationList(teacher);

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

                var deletableEntity = _teacherDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = _teacherDal.DeleteByStatus(deletableEntity);

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

                var deletableEntity = _teacherDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _teacherDal.DeletePermanently(deletableEntity);
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

        public IDataResult<Teacher> Get(Expression<Func<Teacher, bool>> filter)
        {
            try
            {
                var response = _teacherDal.Get(filter);
                var mappingResult = _mapper.Map<Teacher>(response);
                return new SuccessDataResult<Teacher>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<Teacher>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<GetTeacherDto> GetDto(Expression<Func<Teacher, bool>> filter)
        {
            try
            {
                var response = _teacherDal.GetWithRelations(filter);
                var mappedModel = _mapper.Map<GetTeacherDto>(response);
                return new SuccessDataResult<GetTeacherDto>(mappedModel);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetTeacherDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<Teacher>> GetList(Expression<Func<Teacher, bool>> filter = null)
        {
            try
            {
                var response = _teacherDal.GetList(filter);
                var mappingResult = _mapper.Map<List<Teacher>>(response);
                return new SuccessDataResult<List<Teacher>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<Teacher>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> Update(Teacher Teacher)
        {
            try
            {
                int affectedRows = _teacherDal.Update(Teacher);
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



        public IDataResult<int> AddList(List<Teacher> Teachers)
        {
            try
            {
                int affectedRows = _teacherDal.Add(Teachers);
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

        public IDataResult<int> UpdateList(List<Teacher> Teachers)
        {
            try
            {
                int affectedRows = _teacherDal.Update(Teachers);
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

        public IDataResult<int> DeletePermanentlyList(List<Teacher> Teachers)
        {
            try
            {
                int affectedRows = _teacherDal.DeletePermanently(Teachers);
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

        public IDataResult<int> DeleteByStatusList(List<Teacher> Teachers)
        {
            try
            {
                foreach (var Teacher in Teachers)
                {
                    Teacher.IsActive = false;
                }

                DeleteAllEntitiesByStatusForAllRelationList(Teachers);

                int affectedRows = _teacherDal.DeleteByStatus(Teachers);

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

        private void DeleteAllEntitiesByStatusForAllRelationList(List<Teacher> Teachers)
        {
            foreach (var Teacher in Teachers)
            {
            }
        }

        private void DeleteByStatusForAllRelation(Teacher Teacher)
        {
        }

        public IDataResult<List<GetTeacherDto>> GetDtoList(Expression<Func<Teacher, bool>> filter = null, int takeCount = 2000)
        {
            try
            {
                var dtoListResult = new List<GetTeacherDto>();
                _teacherDal.GetAllWithRelations(filter).Take(takeCount).ToList().ForEach(x =>
                {
                    dtoListResult.Add(_mapper.Map<GetTeacherDto>(x));
                });

                return new SuccessDataResult<List<GetTeacherDto>>(dtoListResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetTeacherDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }




        #region Asynchronous

        public async Task<IDataResult<int>> AddAsync(CreateManagementTeacherDto teacher)
        {
            try
            {
                var dbModel = _mapper.Map<Teacher>(teacher);
                int affectedRows = await _teacherDal.AddAsync(dbModel);
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

                var deletableEntity = await _teacherDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = await _teacherDal.DeleteByStatusAsync(deletableEntity);

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

                var deletableEntity = await _teacherDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = await _teacherDal.DeletePermanentlyAsync(deletableEntity);
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

        public async Task<IDataResult<Teacher>> GetAsync(Expression<Func<Teacher, bool>> filter)
        {
            try
            {
                var response = await _teacherDal.GetAsync(filter);
                var mappingResult = _mapper.Map<Teacher>(response);
                return new SuccessDataResult<Teacher>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<Teacher>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<Teacher>>> GetListAsync(Expression<Func<Teacher, bool>> filter = null)
        {
            try
            {
                var response = (await _teacherDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<Teacher>>(response);
                return new SuccessDataResult<List<Teacher>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<Teacher>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> UpdateAsync(Teacher teacher)
        {
            try
            {
                int affectedRows = await _teacherDal.UpdateAsync(teacher);
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

        public async Task<IDataResult<int>> AddListAsync(List<Teacher> teachers)
        {
            try
            {
                int affectedRows = await _teacherDal.AddAsync(teachers);
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

        public async Task<IDataResult<int>> UpdateListAndSaveAsync(List<Teacher> teachers)
        {
            try
            {
                int affectedRows = await _teacherDal.UpdateAndSaveAsync(teachers);
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

        public async Task<IDataResult<int>> DeletePermanentlyListAsync(List<Teacher> teachers)
        {
            try
            {
                int affectedRows = await _teacherDal.DeletePermanentlyAsync(teachers);
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

        public async Task<IDataResult<GetTeacherDto>> GetDtoAsync(Expression<Func<Teacher, bool>> filter = null)
        {
            try
            {
                var response = await _teacherDal.GetAsync(filter);
                var mappingResult = _mapper.Map<GetTeacherDto>(response);
                return new SuccessDataResult<GetTeacherDto>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetTeacherDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<GetTeacherDto>>> GetDtoListAsync(Expression<Func<Teacher, bool>> filter = null, int takeCount = 2000)
        {
            try
            {
                var response = (await _teacherDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<GetTeacherDto>>(response).Take(takeCount).ToList();
                return new SuccessDataResult<List<GetTeacherDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetTeacherDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        #endregion
    }
}
