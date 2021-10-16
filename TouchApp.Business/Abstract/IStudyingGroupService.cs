using Core.Entities.Concrete;
using Core.Entities.Dtos.StudyingGroup;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface IStudyingGroupService
    {
        IDataResult<List<StudyingGroup>> GetList(Expression<Func<StudyingGroup, bool>> filter = null);
        IDataResult<List<GetStudyingGroupDto>> GetDtoList(Func<GetStudyingGroupDto, bool> filter = null, int takeCount = 2000);
        IDataResult<StudyingGroup> Get(Expression<Func<StudyingGroup, bool>> filter);
        IDataResult<GetStudyingGroupDto> GetDto(Expression<Func<StudyingGroup, bool>> filter = null);
        IDataResult<int> Add(StudyingGroup studyingGroup);
        IDataResult<int> Update(StudyingGroup studyingGroup);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<StudyingGroup> studyingGroups);
        IDataResult<int> UpdateList(List<StudyingGroup> studyingGroups);
        IDataResult<int> DeletePermanentlyList(List<StudyingGroup> studyingGroups);
        IDataResult<int> DeleteByStatusList(List<StudyingGroup> studyingGroups);

        Task<IDataResult<List<GetStudyingGroupDto>>> GetDtoListAsync(Expression<Func<StudyingGroup, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetStudyingGroupDto>> GetDtoAsync(Expression<Func<StudyingGroup, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<StudyingGroup> studyingGroups);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<StudyingGroup> studyingGroups);
        Task<IDataResult<List<StudyingGroup>>> GetListAsync(Expression<Func<StudyingGroup, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<StudyingGroup> studyingGroups);
        Task<IDataResult<int>> UpdateAsync(StudyingGroup studyingGroup);
        Task<IDataResult<StudyingGroup>> GetAsync(Expression<Func<StudyingGroup, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(StudyingGroup studyingGroup);
    }
}
