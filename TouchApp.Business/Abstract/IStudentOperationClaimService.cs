using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface IStudentOperationClaimService
    {
        IDataResult<List<StudentOperationClaim>> GetList(Expression<Func<StudentOperationClaim, bool>> filter = null);
        IDataResult<StudentOperationClaim> Get(Expression<Func<StudentOperationClaim, bool>> filter);
        IDataResult<int> Add(StudentOperationClaim studentOperationClaim);
        IDataResult<int> Update(StudentOperationClaim studentOperationClaim);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<StudentOperationClaim> studentOperationClaims);
        IDataResult<int> UpdateList(List<StudentOperationClaim> studentOperationClaims);
        IDataResult<int> DeletePermanentlyList(List<StudentOperationClaim> studentOperationClaims);
        IDataResult<int> DeleteByStatusList(List<StudentOperationClaim> studentOperationClaims);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<StudentOperationClaim> studentOperationClaims);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<StudentOperationClaim> studentOperationClaims);
        Task<IDataResult<List<StudentOperationClaim>>> GetListAsync(Expression<Func<StudentOperationClaim, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<StudentOperationClaim> studentOperationClaims);
        Task<IDataResult<int>> UpdateAsync(StudentOperationClaim studentOperationClaim);
        Task<IDataResult<StudentOperationClaim>> GetAsync(Expression<Func<StudentOperationClaim, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(StudentOperationClaim studentOperationClaim);
    }
}
