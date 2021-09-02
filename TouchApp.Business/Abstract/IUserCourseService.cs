using Core.Entities.Concrete;
using Core.Entities.Dtos.UserCourse;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

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

        Task<IDataResult<List<GetUserCourseDto>>> GetDtoListAsync(Expression<Func<UserCourse, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetUserCourseDto>> GetDtoAsync(Expression<Func<UserCourse, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<UserCourse> userCourses);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<UserCourse> userCourses);
        Task<IDataResult<List<UserCourse>>> GetListAsync(Expression<Func<UserCourse, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<UserCourse> userCourses);
        Task<IDataResult<int>> UpdateAsync(UserCourse userCourse);
        Task<IDataResult<UserCourse>> GetAsync(Expression<Func<UserCourse, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(UserCourse userCourse);
    }
}
