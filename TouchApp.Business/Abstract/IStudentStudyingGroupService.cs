using Core.Entities.Concrete;
using Core.Entities.Dtos.StudentStudyingGroup;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface IStudentStudyingGroupService
    {
        IDataResult<List<StudentStudyingGroup>> GetList(Expression<Func<StudentStudyingGroup, bool>> filter = null);
        IDataResult<List<GetStudentStudyingGroupDto>> GetDtoList(Func<GetStudentStudyingGroupDto, bool> filter = null, int takeCount = 2000);
        IDataResult<StudentStudyingGroup> Get(Expression<Func<StudentStudyingGroup, bool>> filter);
        IDataResult<GetStudentStudyingGroupDto> GetDto(Expression<Func<StudentStudyingGroup, bool>> filter = null);
        IDataResult<int> Add(StudentStudyingGroup studentStudyingGroup);
        IDataResult<int> Update(StudentStudyingGroup studentStudyingGroup);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<StudentStudyingGroup> studentStudyingGroups);
        IDataResult<int> UpdateList(List<StudentStudyingGroup> studentStudyingGroups);
        IDataResult<int> DeletePermanentlyList(List<StudentStudyingGroup> studentStudyingGroups);
        IDataResult<int> DeleteByStatusList(List<StudentStudyingGroup> studentStudyingGroups);

        Task<IDataResult<List<GetStudentStudyingGroupDto>>> GetDtoListAsync(Expression<Func<StudentStudyingGroup, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetStudentStudyingGroupDto>> GetDtoAsync(Expression<Func<StudentStudyingGroup, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<StudentStudyingGroup> studentStudyingGroups);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<StudentStudyingGroup> studentStudyingGroups);
        Task<IDataResult<List<StudentStudyingGroup>>> GetListAsync(Expression<Func<StudentStudyingGroup, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<StudentStudyingGroup> studentStudyingGroups);
        Task<IDataResult<int>> UpdateAsync(StudentStudyingGroup studentStudyingGroup);
        Task<IDataResult<StudentStudyingGroup>> GetAsync(Expression<Func<StudentStudyingGroup, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(StudentStudyingGroup studentStudyingGroup);
    }
}
