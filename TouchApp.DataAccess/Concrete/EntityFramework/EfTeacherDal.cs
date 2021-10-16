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
    public class EfTeacherDal : EfEntityRepositoryBase<Teacher, ApplicationDbContext>, ITeacherDal
    {
        public EfTeacherDal(ApplicationDbContext context) : base(context)
        {
        }

        public List<Teacher> GetAllWithRelations(Expression<Func<Teacher, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return filter == null ?
                Context.Teachers.
                Include(x => x.TeacherCourses).ThenInclude(x => x.Teacher).
                Include(x => x.TeacherOperationClaims).ThenInclude(x => x.Teacher).
                Include(x => x.TeacherSocialMedias).ThenInclude(x => x.Teacher).
                Include(x => x.TeacherCourses).ThenInclude(x => x.Course).
                Include(x => x.TeacherOperationClaims).ThenInclude(x => x.OperationClaim).
                Include(x => x.TeacherSocialMedias).ThenInclude(x => x.SocialMedia).ToList() :
                Context.Teachers.
                Include(x => x.TeacherCourses).ThenInclude(x => x.Teacher).
                Include(x => x.TeacherOperationClaims).ThenInclude(x => x.Teacher).
                Include(x => x.TeacherSocialMedias).ThenInclude(x => x.Teacher).
                Include(x => x.TeacherCourses).ThenInclude(x => x.Course).
                Include(x => x.TeacherOperationClaims).ThenInclude(x => x.OperationClaim).
                Include(x => x.TeacherSocialMedias).ThenInclude(x => x.SocialMedia).Where(filter).ToList();
        }

        public Teacher GetWithRelations(Expression<Func<Teacher, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return Context.Teachers.
                Include(x => x.TeacherCourses).ThenInclude(x => x.Teacher).
                Include(x => x.TeacherOperationClaims).ThenInclude(x => x.Teacher).
                Include(x => x.TeacherSocialMedias).ThenInclude(x => x.Teacher).
                Include(x => x.TeacherCourses).ThenInclude(x => x.Course).
                Include(x => x.TeacherOperationClaims).ThenInclude(x => x.OperationClaim).
                Include(x => x.TeacherSocialMedias).ThenInclude(x => x.SocialMedia).FirstOrDefault(filter);
        }
    }
}
