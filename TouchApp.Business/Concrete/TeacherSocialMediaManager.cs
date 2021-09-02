using AutoMapper;
using TouchApp.Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using TouchApp.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Core.Entities.Dtos.TeacherSocialMedia;

namespace Business.Concrete
{
    public class TeacherSocialMediaManager : ITeacherSocialMediaService
    {
        private readonly ITeacherSocialMediaDal _teacherSocialMediaDal;
        private readonly IMapper _mapper;

        public TeacherSocialMediaManager(ITeacherSocialMediaDal teacherSocialMediaDal, IMapper mapper)
        {
            _teacherSocialMediaDal = teacherSocialMediaDal;
            _mapper = mapper;
        }

        public IDataResult<int> Add(TeacherSocialMedia teacherSocialMedia)
        {
            try
            {
                int affectedRows = _teacherSocialMediaDal.Add(teacherSocialMedia);
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

        public IDataResult<int> DeleteByStatus(long Id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = _teacherSocialMediaDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = _teacherSocialMediaDal.DeleteByStatus(deletableEntity);

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

                var deletableEntity = _teacherSocialMediaDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _teacherSocialMediaDal.DeletePermanently(deletableEntity);
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

        public IDataResult<TeacherSocialMedia> Get(Expression<Func<TeacherSocialMedia, bool>> filter)
        {
            try
            {
                var response = _teacherSocialMediaDal.Get(filter);
                var mappingResult = _mapper.Map<TeacherSocialMedia>(response);
                return new SuccessDataResult<TeacherSocialMedia>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<TeacherSocialMedia>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<TeacherSocialMedia>> GetList(Expression<Func<TeacherSocialMedia, bool>> filter = null)
        {
            try
            {
                var response = _teacherSocialMediaDal.GetList(filter);
                var mappingResult = _mapper.Map<List<TeacherSocialMedia>>(response);
                return new SuccessDataResult<List<TeacherSocialMedia>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<TeacherSocialMedia>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> Update(TeacherSocialMedia teacherSocialMedia)
        {
            try
            {
                int affectedRows = _teacherSocialMediaDal.Update(teacherSocialMedia);
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



        public IDataResult<int> AddList(List<TeacherSocialMedia> teacherSocialMedias)
        {
            try
            {
                int affectedRows = _teacherSocialMediaDal.Add(teacherSocialMedias);
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

        public IDataResult<int> UpdateList(List<TeacherSocialMedia> teacherSocialMedias)
        {
            try
            {
                int affectedRows = _teacherSocialMediaDal.Update(teacherSocialMedias);
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

        public IDataResult<int> DeletePermanentlyList(List<TeacherSocialMedia> teacherSocialMedias)
        {
            try
            {
                int affectedRows = _teacherSocialMediaDal.DeletePermanently(teacherSocialMedias);
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

        public IDataResult<int> DeleteByStatusList(List<TeacherSocialMedia> teacherSocialMedias)
        {
            try
            {
                foreach (var teacherSocialMedia in teacherSocialMedias)
                {
                    teacherSocialMedia.IsActive = false;
                }

                DeleteAllEntitiesByStatusForAllRelationList(teacherSocialMedias);

                int affectedRows = _teacherSocialMediaDal.DeleteByStatus(teacherSocialMedias);

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

        private void DeleteAllEntitiesByStatusForAllRelationList(List<TeacherSocialMedia> teacherSocialMedias)
        {
            foreach (var teacherSocialMedia in teacherSocialMedias)
            {
            }
        }

        private void DeleteByStatusForAllRelation(TeacherSocialMedia teacherSocialMedia)
        {
        }




        #region Asynchronous

        public async Task<IDataResult<int>> AddAsync(TeacherSocialMedia teacherSocialMedia)
        {
            try
            {
                int affectedRows = await _teacherSocialMediaDal.AddAsync(teacherSocialMedia);
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

                var deletableEntity = await _teacherSocialMediaDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = await _teacherSocialMediaDal.DeleteByStatusAsync(deletableEntity);

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

                var deletableEntity = await _teacherSocialMediaDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = await _teacherSocialMediaDal.DeletePermanentlyAsync(deletableEntity);
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

        public async Task<IDataResult<TeacherSocialMedia>> GetAsync(Expression<Func<TeacherSocialMedia, bool>> filter)
        {
            try
            {
                var response = await _teacherSocialMediaDal.GetAsync(filter);
                var mappingResult = _mapper.Map<TeacherSocialMedia>(response);
                return new SuccessDataResult<TeacherSocialMedia>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<TeacherSocialMedia>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<TeacherSocialMedia>>> GetListAsync(Expression<Func<TeacherSocialMedia, bool>> filter = null)
        {
            try
            {
                var response = (await _teacherSocialMediaDal.GetAllAsQueryableAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<TeacherSocialMedia>>(response);
                return new SuccessDataResult<List<TeacherSocialMedia>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<TeacherSocialMedia>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> UpdateAsync(TeacherSocialMedia teacherSocialMedia)
        {
            try
            {
                int affectedRows = await _teacherSocialMediaDal.UpdateAsync(teacherSocialMedia);
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

        public async Task<IDataResult<int>> AddListAsync(List<TeacherSocialMedia> teacherSocialMedias)
        {
            try
            {
                int affectedRows = await _teacherSocialMediaDal.AddAsync(teacherSocialMedias);
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

        public async Task<IDataResult<int>> UpdateListAndSaveAsync(List<TeacherSocialMedia> teacherSocialMedias)
        {
            try
            {
                int affectedRows = await _teacherSocialMediaDal.UpdateAndSaveAsync(teacherSocialMedias);
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

        public async Task<IDataResult<int>> DeletePermanentlyListAsync(List<TeacherSocialMedia> teacherSocialMedias)
        {
            try
            {
                int affectedRows = await _teacherSocialMediaDal.DeletePermanentlyAsync(teacherSocialMedias);
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

        public async Task<IDataResult<GetTeacherSocialMediaDto>> GetDtoAsync(Expression<Func<TeacherSocialMedia, bool>> filter = null)
        {
            try
            {
                var response = await _teacherSocialMediaDal.GetAsync(filter);
                var mappingResult = _mapper.Map<GetTeacherSocialMediaDto>(response);
                return new SuccessDataResult<GetTeacherSocialMediaDto>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetTeacherSocialMediaDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<GetTeacherSocialMediaDto>>> GetDtoListAsync(Expression<Func<TeacherSocialMedia, bool>> filter = null, int takeCount = 2000)
        {
            try
            {
                var response = (await _teacherSocialMediaDal.GetAllAsQueryableAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<GetTeacherSocialMediaDto>>(response).Take(takeCount).ToList();
                return new SuccessDataResult<List<GetTeacherSocialMediaDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetTeacherSocialMediaDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        #endregion
    }
}
