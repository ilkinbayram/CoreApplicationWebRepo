using Core.Entities.Concrete;
using Core.Entities.Dtos.Teacher;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface ITeacherService
    {
        IDataResult<List<Teacher>> GetList(Expression<Func<Teacher, bool>> filter = null);
        IDataResult<Teacher> Get(Expression<Func<Teacher, bool>> filter);
        IDataResult<List<GetTeacherDto>> GetDtoList(Func<GetTeacherDto, bool> filter = null, int takeCount = 2000);
        IDataResult<GetTeacherDto> GetDto(Func<GetTeacherDto, bool> filter);
        IDataResult<int> Add(Teacher teacher);
        IDataResult<int> Update(Teacher teacher);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<Teacher> teachers);
        IDataResult<int> UpdateList(List<Teacher> teachers);
        IDataResult<int> DeletePermanentlyList(List<Teacher> teachers);
        IDataResult<int> DeleteByStatusList(List<Teacher> teachers);

        Task<IDataResult<List<GetTeacherDto>>> GetDtoListAsync(Expression<Func<Teacher, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetTeacherDto>> GetDtoAsync(Expression<Func<Teacher, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<Teacher> teachers);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<Teacher> teachers);
        Task<IDataResult<List<Teacher>>> GetListAsync(Expression<Func<Teacher, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<Teacher> teachers);
        Task<IDataResult<int>> UpdateAsync(Teacher teacher);
        Task<IDataResult<Teacher>> GetAsync(Expression<Func<Teacher, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(Teacher teacher);
    }
}
