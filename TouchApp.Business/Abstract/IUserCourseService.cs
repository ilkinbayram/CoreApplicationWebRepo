using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface IUserCourseService
    {
        IDataResult<List<UserCourse>> GetList(Expression<Func<UserCourse, bool>> filter = null);
        IDataResult<UserCourse> Get(Expression<Func<UserCourse, bool>> filter);
        IDataResult<int> Add(UserCourse userCourse);
        IDataResult<int> Update(UserCourse userCourse);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<UserCourse> userCourses);
        IDataResult<int> UpdateList(List<UserCourse> userCourses);
        IDataResult<int> DeletePermanentlyList(List<UserCourse> userCourses);
        IDataResult<int> DeleteByStatusList(List<UserCourse> userCourses);
    }
}
