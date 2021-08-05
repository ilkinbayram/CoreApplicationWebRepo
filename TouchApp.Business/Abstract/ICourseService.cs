using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface ICourseService
    {
        IDataResult<IEnumerable<Course>> GetList(Expression<Func<Course, bool>> filter = null);
        IDataResult<Course> Get(Expression<Func<Course, bool>> filter);
        IDataResult<int> Add(Course course);
        IDataResult<int> Update(Course course);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<Course> courses);
        IDataResult<int> UpdateList(IEnumerable<Course> courses);
        IDataResult<int> DeletePermanentlyList(IEnumerable<Course> courses);
        IDataResult<int> DeleteByStatusList(IEnumerable<Course> courses);
    }
}
