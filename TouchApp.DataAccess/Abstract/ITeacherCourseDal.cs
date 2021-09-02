using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace TouchApp.DataAccess.Abstract
{
    public interface ITeacherCourseDal : IEntityRepository<TeacherCourse>, IEntityQueryableRepository<TeacherCourse>
    {
    }
}
