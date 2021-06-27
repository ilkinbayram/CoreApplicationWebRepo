using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ApplicationDbContext>, IUserDal
    {
        public EfUserDal(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<OperationClaim> GetClaims(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUserForOrderWithRelations(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public User GetUserWithRelations(Expression<Func<User, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public User UserGetById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
