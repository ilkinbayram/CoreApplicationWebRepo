using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface ITeacherOperationClaimService
    {
        IDataResult<List<TeacherOperationClaim>> GetList(Expression<Func<TeacherOperationClaim, bool>> filter = null);
        IDataResult<TeacherOperationClaim> Get(Expression<Func<TeacherOperationClaim, bool>> filter);
        IDataResult<int> Add(TeacherOperationClaim teacherOperationClaim);
        IDataResult<int> Update(TeacherOperationClaim teacherOperationClaim);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<TeacherOperationClaim> teacherOperationClaims);
        IDataResult<int> UpdateList(List<TeacherOperationClaim> teacherOperationClaims);
        IDataResult<int> DeletePermanentlyList(List<TeacherOperationClaim> teacherOperationClaims);
        IDataResult<int> DeleteByStatusList(List<TeacherOperationClaim> teacherOperationClaims);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<TeacherOperationClaim> teacherOperationClaims);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<TeacherOperationClaim> teacherOperationClaims);
        Task<IDataResult<List<TeacherOperationClaim>>> GetListAsync(Expression<Func<TeacherOperationClaim, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<TeacherOperationClaim> teacherOperationClaims);
        Task<IDataResult<int>> UpdateAsync(TeacherOperationClaim teacherOperationClaim);
        Task<IDataResult<TeacherOperationClaim>> GetAsync(Expression<Func<TeacherOperationClaim, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(TeacherOperationClaim teacherOperationClaim);
    }
}
