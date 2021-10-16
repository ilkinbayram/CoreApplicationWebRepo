using AutoMapper;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Entities.Dtos.StudyingGroup;
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
    public class StudyingGroupManager : IStudyingGroupService
    {
        private readonly IStudyingGroupDal _studyingGroupDal;
        private readonly IMapper _mapper;

        public StudyingGroupManager(IStudyingGroupDal studyingGroupDal, IMapper mapper)
        {
            _studyingGroupDal = studyingGroupDal;
            _mapper = mapper;
        }

        public IDataResult<int> Add(StudyingGroup studyingGroup)
        {
            try
            {
                int affectedRows = _studyingGroupDal.Add(studyingGroup);
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

                var deletableEntity = _studyingGroupDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = _studyingGroupDal.DeleteByStatus(deletableEntity);

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

                var deletableEntity = _studyingGroupDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _studyingGroupDal.DeletePermanently(deletableEntity);
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

        public IDataResult<StudyingGroup> Get(Expression<Func<StudyingGroup, bool>> filter)
        {
            try
            {
                var response = _studyingGroupDal.Get(filter);
                var mappingResult = _mapper.Map<StudyingGroup>(response);
                return new SuccessDataResult<StudyingGroup>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<StudyingGroup>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<StudyingGroup>> GetList(Expression<Func<StudyingGroup, bool>> filter = null)
        {
            try
            {
                var response = _studyingGroupDal.GetList(filter);
                var mappingResult = _mapper.Map<List<StudyingGroup>>(response);
                return new SuccessDataResult<List<StudyingGroup>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<StudyingGroup>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> Update(StudyingGroup studyingGroup)
        {
            try
            {
                int affectedRows = _studyingGroupDal.Update(studyingGroup);
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

        public IDataResult<int> AddList(List<StudyingGroup> studyingGroups)
        {
            try
            {
                int affectedRows = _studyingGroupDal.Add(studyingGroups);
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

        public IDataResult<int> UpdateList(List<StudyingGroup> studyingGroups)
        {
            try
            {
                int affectedRows = _studyingGroupDal.Update(studyingGroups);
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

        public IDataResult<int> DeletePermanentlyList(List<StudyingGroup> studyingGroups)
        {
            try
            {
                int affectedRows = _studyingGroupDal.DeletePermanently(studyingGroups);
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

        public IDataResult<int> DeleteByStatusList(List<StudyingGroup> studyingGroups)
        {
            try
            {
                foreach (var studyingGroup in studyingGroups)
                {
                    studyingGroup.IsActive = false;
                }

                DeleteAllEntitiesByStatusForAllRelationList(studyingGroups);

                int affectedRows = _studyingGroupDal.DeleteByStatus(studyingGroups);

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

        private void DeleteAllEntitiesByStatusForAllRelationList(List<StudyingGroup> studyingGroups)
        {
            foreach (var studyingGroup in studyingGroups)
            {
            }
        }

        private void DeleteByStatusForAllRelation(StudyingGroup studyingGroup)
        {
        }

        public IDataResult<GetStudyingGroupDto> GetDto(Expression<Func<StudyingGroup, bool>> filter = null)
        {
            try
            {
                var response = _studyingGroupDal.GetWithRelations(filter);
                var mappedModel = _mapper.Map<GetStudyingGroupDto>(response);
                return new SuccessDataResult<GetStudyingGroupDto>(mappedModel);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetStudyingGroupDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<GetStudyingGroupDto>> GetDtoList(Func<GetStudyingGroupDto, bool> filter = null, int takeCount = 2000)
        {
            try
            {
                var response = _studyingGroupDal.GetList();
                var mappingResult = _mapper.Map<List<GetStudyingGroupDto>>(response).Where(filter).Take(takeCount).ToList();
                return new SuccessDataResult<List<GetStudyingGroupDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetStudyingGroupDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }



        #region Asynchronous

        public async Task<IDataResult<int>> AddAsync(StudyingGroup studyingGroup)
        {
            try
            {
                int affectedRows = await _studyingGroupDal.AddAsync(studyingGroup);
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

                var deletableEntity = await _studyingGroupDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = await _studyingGroupDal.DeleteByStatusAsync(deletableEntity);

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

                var deletableEntity = await _studyingGroupDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = await _studyingGroupDal.DeletePermanentlyAsync(deletableEntity);
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

        public async Task<IDataResult<StudyingGroup>> GetAsync(Expression<Func<StudyingGroup, bool>> filter)
        {
            try
            {
                var response = await _studyingGroupDal.GetAsync(filter);
                var mappingResult = _mapper.Map<StudyingGroup>(response);
                return new SuccessDataResult<StudyingGroup>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<StudyingGroup>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<StudyingGroup>>> GetListAsync(Expression<Func<StudyingGroup, bool>> filter = null)
        {
            try
            {
                var response = (await _studyingGroupDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<StudyingGroup>>(response);
                return new SuccessDataResult<List<StudyingGroup>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<StudyingGroup>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> UpdateAsync(StudyingGroup studyingGroup)
        {
            try
            {
                int affectedRows = await _studyingGroupDal.UpdateAsync(studyingGroup);
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

        public async Task<IDataResult<int>> AddListAsync(List<StudyingGroup> studyingGroups)
        {
            try
            {
                int affectedRows = await _studyingGroupDal.AddAsync(studyingGroups);
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

        public async Task<IDataResult<int>> UpdateListAndSaveAsync(List<StudyingGroup> studyingGroups)
        {
            try
            {
                int affectedRows = await _studyingGroupDal.UpdateAndSaveAsync(studyingGroups);
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

        public async Task<IDataResult<int>> DeletePermanentlyListAsync(List<StudyingGroup> studyingGroups)
        {
            try
            {
                int affectedRows = await _studyingGroupDal.DeletePermanentlyAsync(studyingGroups);
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

        public async Task<IDataResult<GetStudyingGroupDto>> GetDtoAsync(Expression<Func<StudyingGroup, bool>> filter = null)
        {
            try
            {
                var response = await _studyingGroupDal.GetAsync(filter);
                var mappingResult = _mapper.Map<GetStudyingGroupDto>(response);
                return new SuccessDataResult<GetStudyingGroupDto>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetStudyingGroupDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<GetStudyingGroupDto>>> GetDtoListAsync(Expression<Func<StudyingGroup, bool>> filter = null, int takeCount = 2000)
        {
            try
            {
                var response = (await _studyingGroupDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<GetStudyingGroupDto>>(response).Take(takeCount).ToList();
                return new SuccessDataResult<List<GetStudyingGroupDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetStudyingGroupDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        #endregion

    }
}
