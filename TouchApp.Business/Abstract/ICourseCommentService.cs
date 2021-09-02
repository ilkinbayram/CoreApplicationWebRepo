using Core.Entities.Concrete;
using Core.Entities.Dtos.CourseComment;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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

        Task<IDataResult<List<GetCourseCommentDto>>> GetDtoListAsync(Expression<Func<CourseComment, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetCourseCommentDto>> GetDtoAsync(Expression<Func<CourseComment, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<CourseComment> courseComments);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<CourseComment> courseComments);
        Task<IDataResult<List<CourseComment>>> GetListAsync(Expression<Func<CourseComment, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<CourseComment> courseComments);
        Task<IDataResult<int>> UpdateAsync(CourseComment courseComment);
        Task<IDataResult<CourseComment>> GetAsync(Expression<Func<CourseComment, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(CourseComment courseComment);
    }
}
