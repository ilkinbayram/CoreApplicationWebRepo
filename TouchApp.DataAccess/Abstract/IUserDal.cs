using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TouchApp.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>, IEntityQueryableRepository<User>
    {
        List<User> GetAllWithRelations(Expression<Func<User, bool>> filter);
        User GetWithRelations(Expression<Func<User, bool>> filter);


        List<OperationClaim> GetClaims(User user);
        User GetUserWithRelations(Expression<Func<User, bool>> filter);
        User GetUserForOrderWithRelations(Expression<Func<User, bool>> filter);
        User UserGetById(long id);
    }
}
