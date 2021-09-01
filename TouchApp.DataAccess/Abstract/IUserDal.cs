using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.DataAccess;
using Core.Entities.Concrete;

namespace TouchApp.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        User GetUserWithRelations(Expression<Func<User, bool>> filter);
        User GetUserForOrderWithRelations(Expression<Func<User, bool>> filter);
        User UserGetById(long id);
    }
}
