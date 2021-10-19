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
    public class EfCourseDal : EfEntityRepositoryBase<Course, ApplicationDbContext>, ICourseDal
    {
        public EfCourseDal(ApplicationDbContext context) : base(context)
        {
        }

        public List<Course> GetAllWithRelations(Expression<Func<Course, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return filter == null ?
                Context.Courses.
                Include(x => x.TeacherCourses).ThenInclude(x => x.Course).
                Include(x => x.TeacherCourses).ThenInclude(x => x.Teacher).ToList() :
                Context.Courses.
                Include(x => x.TeacherCourses).ThenInclude(x => x.Course).
                Include(x => x.TeacherCourses).ThenInclude(x => x.Teacher).Where(filter).ToList();
        }

        public Course GetWithRelations(Expression<Func<Course, bool>> filter)
        {
            Context.ChangeTracker.LazyLoadingEnabled = false;
            return Context.Courses.
                Include(x => x.TeacherCourses).ThenInclude(x => x.Course).
                Include(x => x.TeacherCourses).ThenInclude(x => x.Teacher).FirstOrDefault(filter);
        }
    }
}
