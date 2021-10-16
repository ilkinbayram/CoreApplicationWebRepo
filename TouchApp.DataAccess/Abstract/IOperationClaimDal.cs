using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TouchApp.DataAccess.Abstract
{
    public interface IOperationClaimDal : IEntityRepository<OperationClaim>, IEntityQueryableRepository<OperationClaim>
    {
        List<OperationClaim> GetAllWithRelations(Expression<Func<OperationClaim, bool>> filter);
        OperationClaim GetWithRelations(Expression<Func<OperationClaim, bool>> filter);

    }
}
