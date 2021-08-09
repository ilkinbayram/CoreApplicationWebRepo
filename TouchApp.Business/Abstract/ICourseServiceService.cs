using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface ICourseServiceService
    {
        IDataResult<IEnumerable<CourseService>> GetList(Expression<Func<CourseService, bool>> filter = null);
        IDataResult<CourseService> Get(Expression<Func<CourseService, bool>> filter);
        IDataResult<int> Add(CourseService courseService);
        IDataResult<int> Update(CourseService courseService);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<CourseService> courseServices);
        IDataResult<int> UpdateList(IEnumerable<CourseService> courseServices);
        IDataResult<int> DeletePermanentlyList(IEnumerable<CourseService> courseServices);
        IDataResult<int> DeleteByStatusList(IEnumerable<CourseService> courseServices);
    }
}
