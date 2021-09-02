using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IDataResult<List<UserOperationClaim>> GetList(Expression<Func<UserOperationClaim, bool>> filter = null);
        IDataResult<UserOperationClaim> Get(Expression<Func<UserOperationClaim, bool>> filter);
        IDataResult<int> Add(UserOperationClaim userOperationClaim);
        IDataResult<int> Update(UserOperationClaim userOperationClaim);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<UserOperationClaim> userOperationClaims);
        IDataResult<int> UpdateList(List<UserOperationClaim> userOperationClaims);
        IDataResult<int> DeletePermanentlyList(List<UserOperationClaim> userOperationClaims);
        IDataResult<int> DeleteByStatusList(List<UserOperationClaim> userOperationClaims);

        Task<IDataResult<List<GetUserOperationClaimDto>>> GetDtoListAsync(Expression<Func<UserOperationClaim, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetUserOperationClaimDto>> GetDtoAsync(Expression<Func<UserOperationClaim, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<UserOperationClaim> userOperationClaims);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<UserOperationClaim> userOperationClaims);
        Task<IDataResult<List<UserOperationClaim>>> GetListAsync(Expression<Func<UserOperationClaim, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<UserOperationClaim> userOperationClaims);
        Task<IDataResult<int>> UpdateAsync(UserOperationClaim userOperationClaim);
        Task<IDataResult<UserOperationClaim>> GetAsync(Expression<Func<UserOperationClaim, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(UserOperationClaim userOperationClaim);
    }
}
