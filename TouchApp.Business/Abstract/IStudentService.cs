using Core.Entities.Concrete;
using Core.Entities.Dtos.Student;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface IStudentService
    {
        IDataResult<List<Student>> GetList(Expression<Func<Student, bool>> filter = null);
        IDataResult<Student> Get(Expression<Func<Student, bool>> filter);
        IDataResult<List<GetStudentDto>> GetDtoList(Func<GetStudentDto, bool> filter = null, int takeCount = 2000);
        IDataResult<GetStudentDto> GetDto(Expression<Func<Student, bool>> filter = null);
        IDataResult<int> Add(Student student);
        IDataResult<int> Update(Student student);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<Student> students);
        IDataResult<int> UpdateList(List<Student> students);
        IDataResult<int> DeletePermanentlyList(List<Student> students);
        IDataResult<int> DeleteByStatusList(List<Student> students);

        Task<IDataResult<List<GetStudentDto>>> GetDtoListAsync(Expression<Func<Student, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetStudentDto>> GetDtoAsync(Expression<Func<Student, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<Student> students);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<Student> students);
        Task<IDataResult<List<Student>>> GetListAsync(Expression<Func<Student, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<Student> students);
        Task<IDataResult<int>> UpdateAsync(Student student);
        Task<IDataResult<Student>> GetAsync(Expression<Func<Student, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(Student student);
    }
}
