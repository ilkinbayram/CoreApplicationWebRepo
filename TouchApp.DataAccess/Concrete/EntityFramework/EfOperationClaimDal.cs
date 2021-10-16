using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfOperationClaimDal : EfEntityRepositoryBase<OperationClaim, ApplicationDbContext>, IOperationClaimDal
    {
        public EfOperationClaimDal(ApplicationDbContext context) : base(context)
        {
        }

        public List<OperationClaim> GetAllWithRelations(Expression<Func<OperationClaim, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return filter == null ?
                Context.OperationClaims.Include(x => x.UserOperationClaims).ThenInclude(x => x.OperationClaim).Include(x => x.TeacherOperationClaims).ThenInclude(x => x.OperationClaim).Include(x => x.StudentOperationClaims).ThenInclude(x => x.OperationClaim).Include(x => x.UserOperationClaims).ThenInclude(x => x.User).Include(x => x.TeacherOperationClaims).ThenInclude(x => x.Teacher).Include(x => x.StudentOperationClaims).ThenInclude(x => x.Student).ToList() :
                Context.OperationClaims.Include(x => x.UserOperationClaims).ThenInclude(x => x.OperationClaim).Include(x => x.TeacherOperationClaims).ThenInclude(x => x.OperationClaim).Include(x => x.StudentOperationClaims).ThenInclude(x => x.OperationClaim).Include(x => x.UserOperationClaims).ThenInclude(x => x.User).Include(x => x.TeacherOperationClaims).ThenInclude(x => x.Teacher).Include(x => x.StudentOperationClaims).ThenInclude(x => x.Student).Where(filter).ToList();
        }

        public OperationClaim GetWithRelations(Expression<Func<OperationClaim, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return Context.OperationClaims.
                Include(x => x.UserOperationClaims).ThenInclude(x => x.OperationClaim).
                Include(x => x.TeacherOperationClaims).ThenInclude(x => x.OperationClaim).
                Include(x => x.StudentOperationClaims).ThenInclude(x => x.OperationClaim).FirstOrDefault(filter);
        }
    }
}
