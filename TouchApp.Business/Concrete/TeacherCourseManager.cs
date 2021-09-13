using AutoMapper;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Entities.Dtos.TeacherCourse;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;
using TouchApp.DataAccess.Abstract;

namespace Business.Concrete
{
    public class TeacherCourseManager : ITeacherCourseService
    {
        private readonly ITeacherCourseDal _teacherCourseDal;
        private readonly IMapper _mapper;

        public TeacherCourseManager(ITeacherCourseDal teacherCourseDal, IMapper mapper)
        {
            _teacherCourseDal = teacherCourseDal;
            _mapper = mapper;
        }

        public IDataResult<int> Add(TeacherCourse teacherCourse)
        {
            try
            {
                int affectedRows = _teacherCourseDal.Add(teacherCourse);
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

                var deletableEntity = _teacherCourseDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = _teacherCourseDal.DeleteByStatus(deletableEntity);

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

                var deletableEntity = _teacherCourseDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _teacherCourseDal.DeletePermanently(deletableEntity);
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

        public IDataResult<TeacherCourse> Get(Expression<Func<TeacherCourse, bool>> filter)
        {
            try
            {
                var response = _teacherCourseDal.Get(filter);
                var mappingResult = _mapper.Map<TeacherCourse>(response);
                return new SuccessDataResult<TeacherCourse>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<TeacherCourse>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<TeacherCourse>> GetList(Expression<Func<TeacherCourse, bool>> filter = null)
        {
            try
            {
                var response = _teacherCourseDal.GetList(filter);
                var mappingResult = _mapper.Map<List<TeacherCourse>>(response);
                return new SuccessDataResult<List<TeacherCourse>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<TeacherCourse>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> Update(TeacherCourse teacherCourse)
        {
            try
            {
                int affectedRows = _teacherCourseDal.Update(teacherCourse);
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



        public IDataResult<int> AddList(List<TeacherCourse> teacherCourses)
        {
            try
            {
                int affectedRows = _teacherCourseDal.Add(teacherCourses);
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

        public IDataResult<int> UpdateList(List<TeacherCourse> teacherCourses)
        {
            try
            {
                int affectedRows = _teacherCourseDal.Update(teacherCourses);
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

        public IDataResult<int> DeletePermanentlyList(List<TeacherCourse> teacherCourses)
        {
            try
            {
                int affectedRows = _teacherCourseDal.DeletePermanently(teacherCourses);
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

        public IDataResult<int> DeleteByStatusList(List<TeacherCourse> teacherCourses)
        {
            try
            {
                foreach (var teacherCourse in teacherCourses)
                {
                    teacherCourse.IsActive = false;
                }

                DeleteAllEntitiesByStatusForAllRelationList(teacherCourses);

                int affectedRows = _teacherCourseDal.DeleteByStatus(teacherCourses);

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

        private void DeleteAllEntitiesByStatusForAllRelationList(List<TeacherCourse> teacherCourses)
        {
            foreach (var teacherCourse in teacherCourses)
            {
            }
        }

        private void DeleteByStatusForAllRelation(TeacherCourse teacherCourse)
        {
        }




        #region Asynchronous

        public async Task<IDataResult<int>> AddAsync(TeacherCourse teacherCourse)
        {
            try
            {
                int affectedRows = await _teacherCourseDal.AddAsync(teacherCourse);
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

                var deletableEntity = await _teacherCourseDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = await _teacherCourseDal.DeleteByStatusAsync(deletableEntity);

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

                var deletableEntity = await _teacherCourseDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = await _teacherCourseDal.DeletePermanentlyAsync(deletableEntity);
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

        public async Task<IDataResult<TeacherCourse>> GetAsync(Expression<Func<TeacherCourse, bool>> filter)
        {
            try
            {
                var response = await _teacherCourseDal.GetAsync(filter);
                var mappingResult = _mapper.Map<TeacherCourse>(response);
                return new SuccessDataResult<TeacherCourse>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<TeacherCourse>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<TeacherCourse>>> GetListAsync(Expression<Func<TeacherCourse, bool>> filter = null)
        {
            try
            {
                var response = (await _teacherCourseDal.GetAllAsQueryableAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<TeacherCourse>>(response);
                return new SuccessDataResult<List<TeacherCourse>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<TeacherCourse>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> UpdateAsync(TeacherCourse teacherCourse)
        {
            try
            {
                int affectedRows = await _teacherCourseDal.UpdateAsync(teacherCourse);
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

        public async Task<IDataResult<int>> AddListAsync(List<TeacherCourse> teacherCourses)
        {
            try
            {
                int affectedRows = await _teacherCourseDal.AddAsync(teacherCourses);
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

        public async Task<IDataResult<int>> UpdateListAndSaveAsync(List<TeacherCourse> teacherCourses)
        {
            try
            {
                int affectedRows = await _teacherCourseDal.UpdateAndSaveAsync(teacherCourses);
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

        public async Task<IDataResult<int>> DeletePermanentlyListAsync(List<TeacherCourse> teacherCourses)
        {
            try
            {
                int affectedRows = await _teacherCourseDal.DeletePermanentlyAsync(teacherCourses);
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

        public async Task<IDataResult<GetTeacherCourseDto>> GetDtoAsync(Expression<Func<TeacherCourse, bool>> filter = null)
        {
            try
            {
                var response = await _teacherCourseDal.GetAsync(filter);
                var mappingResult = _mapper.Map<GetTeacherCourseDto>(response);
                return new SuccessDataResult<GetTeacherCourseDto>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetTeacherCourseDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<GetTeacherCourseDto>>> GetDtoListAsync(Expression<Func<TeacherCourse, bool>> filter = null, int takeCount = 2000)
        {
            try
            {
                var response = (await _teacherCourseDal.GetAllAsQueryableAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<GetTeacherCourseDto>>(response).Take(takeCount).ToList();
                return new SuccessDataResult<List<GetTeacherCourseDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetTeacherCourseDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        #endregion
    }
}
