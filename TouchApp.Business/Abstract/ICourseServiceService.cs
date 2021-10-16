using Core.Entities.Concrete;
using Core.Entities.Dtos.OurService;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface ICourseServiceService
    {
        IDataResult<List<CourseService>> GetList(Expression<Func<CourseService, bool>> filter = null);
        IDataResult<List<GetCourseServiceDto>> GetDtoList(Expression<Func<CourseService, bool>> filter = null, int takeCount = 2000);
        IDataResult<GetCourseServiceDto> GetDto(Expression<Func<CourseService, bool>> filter = null);
        IDataResult<CourseService> Get(Expression<Func<CourseService, bool>> filter);
        IDataResult<int> Add(CourseService courseService);
        IDataResult<int> Update(CourseService courseService);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<CourseService> courseServices);
        IDataResult<int> UpdateList(List<CourseService> courseServices);
        IDataResult<int> DeletePermanentlyList(List<CourseService> courseServices);
        IDataResult<int> DeleteByStatusList(List<CourseService> courseServices);

        Task<IDataResult<List<GetCourseServiceDto>>> GetDtoListAsync(Expression<Func<CourseService, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetCourseServiceDto>> GetDtoAsync(Expression<Func<CourseService, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<CourseService> courseServices);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<CourseService> courseServices);
        Task<IDataResult<List<CourseService>>> GetListAsync(Expression<Func<CourseService, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<CourseService> courseServices);
        Task<IDataResult<int>> UpdateAsync(CourseService courseService);
        Task<IDataResult<CourseService>> GetAsync(Expression<Func<CourseService, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(CourseService courseService);
    }
}
