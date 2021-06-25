using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepositoryBase<User,ApplicationDbContext>,IUserDal
    {
        public EfUserDal(ApplicationDbContext applicationContext) : base(applicationContext)
        {
        }

        public IEnumerable<OperationClaim> GetClaims(User user)
        {
            var result = from operationClaim in Context.OperationClaims
                join userOperationClaim in Context.UserOperationClaims
                    on operationClaim.Id equals userOperationClaim.OperationClaim.Id
                where userOperationClaim.User.Id == user.Id
                select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            return result.ToList();
        }

        public UserLanguage GetUserBySlug(string userSlug, string lang)
        {
            var langid = Context.Languages.FirstOrDefault(x => x.LanguageName == lang)?.Id;
            var userlang = Context.UserLanguages.Include(x=>x.User).ThenInclude(x=>x.UserFeatureValues).FirstOrDefault(x => x.LanguageId == langid && x.Slug == userSlug);
           return userlang;
        }

        public User GetUserWithRelations(Expression<Func<User, bool>> filter)
        {
            return Context.Users.Include(x => x.FamousRates).ThenInclude(x => x.FamousPerson).Include(x => x.UserRates).ThenInclude(x => x.User).Include(x => x.UserOrders).ThenInclude(x => x.User).Include(x => x.FamousOrders).ThenInclude(x => x.FamousPerson).Include(x => x.UserFeatureValues).ThenInclude(x => x.FeatureValue).ThenInclude(x=>x.Feature).ThenInclude(x=>x.FeatureLanguages).ThenInclude(x=>x.Feature).ThenInclude(x=>x.FeatureValues).ThenInclude(x=>x.FeatureValueLanguages).Include(x => x.UserLanguages).ThenInclude(x => x.User).Include(x => x.UserOperationClaims).ThenInclude(x => x.User).FirstOrDefault(filter);
        }

        public User GetUserForOrderWithRelations(Expression<Func<User, bool>> filter)
        {

            Context.ChangeTracker.LazyLoadingEnabled = false;

            return Context.Users.Include(x => x.UserFeatureValues).ThenInclude(x => x.FeatureValue).ThenInclude(x => x.Feature).ThenInclude(x => x.FeatureLanguages).Include(x => x.UserFeatureValues).ThenInclude(x => x.FeatureValue).ThenInclude(x => x.FeatureValueLanguages).FirstOrDefault(filter);
        }

        public User UserGetById(long id)
        {
            return Context.Users.Include(x=>x.UserFeatureValues).Include(x=>x.UserLanguages).FirstOrDefault(x => x.Id == id);
        }
    }
}