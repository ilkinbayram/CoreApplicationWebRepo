using Core.Entities.Concrete;
using Core.Entities.Dtos.TeacherCourse;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface ITeacherCourseService
    {
        IDataResult<List<TeacherCourse>> GetList(Expression<Func<TeacherCourse, bool>> filter = null);
        IDataResult<TeacherCourse> Get(Expression<Func<TeacherCourse, bool>> filter);
        IDataResult<GetTeacherCourseDto> GetDto(Expression<Func<TeacherCourse, bool>> filter = null);
        IDataResult<int> Add(TeacherCourse teacherCourse);
        IDataResult<int> Update(TeacherCourse teacherCourse);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<TeacherCourse> teacherCourses);
        IDataResult<int> UpdateList(List<TeacherCourse> teacherCourses);
        IDataResult<int> DeletePermanentlyList(List<TeacherCourse> teacherCourses);
        IDataResult<int> DeleteByStatusList(List<TeacherCourse> teacherCourses);

        Task<IDataResult<List<GetTeacherCourseDto>>> GetDtoListAsync(Expression<Func<TeacherCourse, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetTeacherCourseDto>> GetDtoAsync(Expression<Func<TeacherCourse, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<TeacherCourse> teacherCourses);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<TeacherCourse> teacherCourses);
        Task<IDataResult<List<TeacherCourse>>> GetListAsync(Expression<Func<TeacherCourse, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<TeacherCourse> teacherCourses);
        Task<IDataResult<int>> UpdateAsync(TeacherCourse teacherCourse);
        Task<IDataResult<TeacherCourse>> GetAsync(Expression<Func<TeacherCourse, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(TeacherCourse teacherCourse);
    }
}
