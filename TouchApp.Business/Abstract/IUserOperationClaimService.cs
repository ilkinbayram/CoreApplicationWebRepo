﻿using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

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
    }
}
