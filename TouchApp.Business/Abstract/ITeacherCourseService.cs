using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface ITeacherCourseService
    {
        IDataResult<List<TeacherCourse>> GetList(Expression<Func<TeacherCourse, bool>> filter = null);
        IDataResult<TeacherCourse> Get(Expression<Func<TeacherCourse, bool>> filter);
        IDataResult<int> Add(TeacherCourse teacherCourse);
        IDataResult<int> Update(TeacherCourse teacherCourse);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<TeacherCourse> teacherCourses);
        IDataResult<int> UpdateList(List<TeacherCourse> teacherCourses);
        IDataResult<int> DeletePermanentlyList(List<TeacherCourse> teacherCourses);
        IDataResult<int> DeleteByStatusList(List<TeacherCourse> teacherCourses);
    }
}
