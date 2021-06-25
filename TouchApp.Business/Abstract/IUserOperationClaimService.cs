using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IUserOperationClaimService
    {
        IDataResult<IEnumerable<UserOperationClaim>> GetList(Expression<Func<UserOperationClaim, bool>> filter = null);
        IDataResult<UserOperationClaim> Get(Expression<Func<UserOperationClaim, bool>> filter);
        IDataResult<int> Add(UserOperationClaim userOperationClaim);
        IDataResult<int> Update(UserOperationClaim userOperationClaim);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<UserOperationClaim> userOperationClaims);
        IDataResult<int> UpdateList(IEnumerable<UserOperationClaim> userOperationClaims);
        IDataResult<int> DeletePermanentlyList(IEnumerable<UserOperationClaim> userOperationClaims);
        IDataResult<int> DeleteByStatusList(IEnumerable<UserOperationClaim> userOperationClaims);
    }
}
