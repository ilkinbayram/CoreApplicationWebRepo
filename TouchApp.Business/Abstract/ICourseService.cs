using Core.Entities.Concrete;
using Core.Entities.Dtos.Course;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface ICourseService
    {
        IDataResult<List<Course>> GetList(Expression<Func<Course, bool>> filter = null);
        IDataResult<List<GetCourseDto>> GetDtoList(Func<GetCourseDto, bool> filter = null, int takeCount = 2000);
        IDataResult<Course> Get(Expression<Func<Course, bool>> filter);
        IDataResult<GetCourseDto> GetDto(Func<GetCourseDto, bool> filter);
        IDataResult<int> Add(Course course);
        IDataResult<int> Update(Course course);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<Course> courses);
        IDataResult<int> UpdateList(List<Course> courses);
        IDataResult<int> DeletePermanentlyList(List<Course> courses);
        IDataResult<int> DeleteByStatusList(List<Course> courses);
    }
}
