using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface ICourseCommentService
    {
        IDataResult<List<CourseComment>> GetList(Expression<Func<CourseComment, bool>> filter = null);
        IDataResult<CourseComment> Get(Expression<Func<CourseComment, bool>> filter);
        IDataResult<int> Add(CourseComment courseComment);
        IDataResult<int> Update(CourseComment courseComment);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<CourseComment> courseComments);
        IDataResult<int> UpdateList(List<CourseComment> courseComments);
        IDataResult<int> DeletePermanentlyList(List<CourseComment> courseComments);
        IDataResult<int> DeleteByStatusList(List<CourseComment> courseComments);
    }
}
