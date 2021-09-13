﻿using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework.Contexts;
using TouchApp.DataAccess.Abstract;

namespace TouchApp.DataAccess.Concrete.EntityFramework
{
    public class EfTeacherCourseDal : EfEntityRepositoryBase<TeacherCourse, ApplicationDbContext>, ITeacherCourseDal
    {
        public EfTeacherCourseDal(ApplicationDbContext context) : base(context)
        {
        }
    }
}
