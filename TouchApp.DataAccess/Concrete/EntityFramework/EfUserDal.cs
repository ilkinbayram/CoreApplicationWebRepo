using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ApplicationDbContext>, IUserDal
    {
        public EfUserDal(ApplicationDbContext context) : base(context)
        {
        }

        public List<User> GetAllWithRelations(Expression<Func<User, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return filter == null ?
                Context.Users.
                Include(x => x.UserOperationClaims).ThenInclude(x => x.User).
                Include(x => x.UserSocialMedias).ThenInclude(x => x.User).
                Include(x => x.UserOperationClaims).ThenInclude(x => x.OperationClaim).
                Include(x => x.UserSocialMedias).ThenInclude(x => x.SocialMedia).ToList() :
                Context.Users.
                Include(x => x.UserOperationClaims).ThenInclude(x => x.User).
                Include(x => x.UserSocialMedias).ThenInclude(x => x.User).
                Include(x => x.UserOperationClaims).ThenInclude(x => x.OperationClaim).
                Include(x => x.UserSocialMedias).ThenInclude(x => x.SocialMedia).Where(filter).ToList();
        }

        public User GetWithRelations(Expression<Func<User, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return Context.Users.
                Include(x => x.UserOperationClaims).ThenInclude(x => x.User).
                Include(x => x.UserSocialMedias).ThenInclude(x => x.User).
                Include(x => x.UserOperationClaims).ThenInclude(x => x.OperationClaim).
                Include(x => x.UserSocialMedias).ThenInclude(x => x.SocialMedia).FirstOrDefault(filter);
        }





        public List<OperationClaim> GetClaims(User user)
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
