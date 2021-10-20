using AutoMapper;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Entities.Dtos.StudentStudyingGroup;
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
    public class StudentStudyingGroupManager : IStudentStudyingGroupService
    {
        private readonly IStudentStudyingGroupDal _studentStudyingGroupDal;
        private readonly IMapper _mapper;

        public StudentStudyingGroupManager(IStudentStudyingGroupDal studentStudyingGroupDal, IMapper mapper)
        {
            _studentStudyingGroupDal = studentStudyingGroupDal;
            _mapper = mapper;
        }

        public IDataResult<int> Add(StudentStudyingGroup studentStudyingGroup)
        {
            try
            {
                int affectedRows = _studentStudyingGroupDal.Add(studentStudyingGroup);
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

        public IDataResult<int> DeleteByStatus(long Id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = _studentStudyingGroupDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = _studentStudyingGroupDal.DeleteByStatus(deletableEntity);

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

                var deletableEntity = _studentStudyingGroupDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _studentStudyingGroupDal.DeletePermanently(deletableEntity);
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

        public IDataResult<StudentStudyingGroup> Get(Expression<Func<StudentStudyingGroup, bool>> filter)
        {
            try
            {
                var response = _studentStudyingGroupDal.Get(filter);
                var mappingResult = _mapper.Map<StudentStudyingGroup>(response);
                return new SuccessDataResult<StudentStudyingGroup>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<StudentStudyingGroup>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<StudentStudyingGroup>> GetList(Expression<Func<StudentStudyingGroup, bool>> filter = null)
        {
            try
            {
                var response = _studentStudyingGroupDal.GetList(filter);
                var mappingResult = _mapper.Map<List<StudentStudyingGroup>>(response);
                return new SuccessDataResult<List<StudentStudyingGroup>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<StudentStudyingGroup>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> Update(StudentStudyingGroup studentStudyingGroup)
        {
            try
            {
                int affectedRows = _studentStudyingGroupDal.Update(studentStudyingGroup);
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

        public IDataResult<int> AddList(List<StudentStudyingGroup> studentStudyingGroups)
        {
            try
            {
                int affectedRows = _studentStudyingGroupDal.Add(studentStudyingGroups);
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

        public IDataResult<int> UpdateList(List<StudentStudyingGroup> studentStudyingGroups)
        {
            try
            {
                int affectedRows = _studentStudyingGroupDal.Update(studentStudyingGroups);
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

        public IDataResult<int> DeletePermanentlyList(List<StudentStudyingGroup> studentStudyingGroups)
        {
            try
            {
                int affectedRows = _studentStudyingGroupDal.DeletePermanently(studentStudyingGroups);
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

        public IDataResult<int> DeleteByStatusList(List<StudentStudyingGroup> studentStudyingGroups)
        {
            try
            {
                foreach (var studentStudyingGroup in studentStudyingGroups)
                {
                    studentStudyingGroup.IsActive = false;
                }

                DeleteAllEntitiesByStatusForAllRelationList(studentStudyingGroups);

                int affectedRows = _studentStudyingGroupDal.DeleteByStatus(studentStudyingGroups);

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

        private void DeleteAllEntitiesByStatusForAllRelationList(List<StudentStudyingGroup> studentStudyingGroups)
        {
            foreach (var studentStudyingGroup in studentStudyingGroups)
            {
            }
        }

        private void DeleteByStatusForAllRelation(StudentStudyingGroup studentStudyingGroup)
        {
        }

        public IDataResult<GetStudentStudyingGroupDto> GetDto(Expression<Func<StudentStudyingGroup, bool>> filter = null)
        {
            try
            {
                var response = _studentStudyingGroupDal.Get(filter);
                var mappedModel = _mapper.Map<GetStudentStudyingGroupDto>(response);
                return new SuccessDataResult<GetStudentStudyingGroupDto>(mappedModel);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetStudentStudyingGroupDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<GetStudentStudyingGroupDto>> GetDtoList(Func<GetStudentStudyingGroupDto, bool> filter = null, int takeCount = 2000)
        {
            try
            {
                var response = _studentStudyingGroupDal.GetList();
                var mappingResult = _mapper.Map<List<GetStudentStudyingGroupDto>>(response).Where(filter).Take(takeCount).ToList();
                return new SuccessDataResult<List<GetStudentStudyingGroupDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetStudentStudyingGroupDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }



        #region Asynchronous

        public async Task<IDataResult<int>> AddAsync(StudentStudyingGroup studentStudyingGroup)
        {
            try
            {
                int affectedRows = await _studentStudyingGroupDal.AddAsync(studentStudyingGroup);
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

                var deletableEntity = await _studentStudyingGroupDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = await _studentStudyingGroupDal.DeleteByStatusAsync(deletableEntity);

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

                var deletableEntity = await _studentStudyingGroupDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = await _studentStudyingGroupDal.DeletePermanentlyAsync(deletableEntity);
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

        public async Task<IDataResult<StudentStudyingGroup>> GetAsync(Expression<Func<StudentStudyingGroup, bool>> filter)
        {
            try
            {
                var response = await _studentStudyingGroupDal.GetAsync(filter);
                var mappingResult = _mapper.Map<StudentStudyingGroup>(response);
                return new SuccessDataResult<StudentStudyingGroup>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<StudentStudyingGroup>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<StudentStudyingGroup>>> GetListAsync(Expression<Func<StudentStudyingGroup, bool>> filter = null)
        {
            try
            {
                var response = (await _studentStudyingGroupDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<StudentStudyingGroup>>(response);
                return new SuccessDataResult<List<StudentStudyingGroup>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<StudentStudyingGroup>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> UpdateAsync(StudentStudyingGroup studentStudyingGroup)
        {
            try
            {
                int affectedRows = await _studentStudyingGroupDal.UpdateAsync(studentStudyingGroup);
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

        public async Task<IDataResult<int>> AddListAsync(List<StudentStudyingGroup> studentStudyingGroups)
        {
            try
            {
                int affectedRows = await _studentStudyingGroupDal.AddAsync(studentStudyingGroups);
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

        public async Task<IDataResult<int>> UpdateListAndSaveAsync(List<StudentStudyingGroup> studentStudyingGroups)
        {
            try
            {
                int affectedRows = await _studentStudyingGroupDal.UpdateAndSaveAsync(studentStudyingGroups);
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

        public async Task<IDataResult<int>> DeletePermanentlyListAsync(List<StudentStudyingGroup> studentStudyingGroups)
        {
            try
            {
                int affectedRows = await _studentStudyingGroupDal.DeletePermanentlyAsync(studentStudyingGroups);
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

        public async Task<IDataResult<GetStudentStudyingGroupDto>> GetDtoAsync(Expression<Func<StudentStudyingGroup, bool>> filter = null)
        {
            try
            {
                var response = await _studentStudyingGroupDal.GetAsync(filter);
                var mappingResult = _mapper.Map<GetStudentStudyingGroupDto>(response);
                return new SuccessDataResult<GetStudentStudyingGroupDto>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetStudentStudyingGroupDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<GetStudentStudyingGroupDto>>> GetDtoListAsync(Expression<Func<StudentStudyingGroup, bool>> filter = null, int takeCount = 2000)
        {
            try
            {
                var response = (await _studentStudyingGroupDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<GetStudentStudyingGroupDto>>(response).Take(takeCount).ToList();
                return new SuccessDataResult<List<GetStudentStudyingGroupDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetStudentStudyingGroupDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        #endregion

    }
}
