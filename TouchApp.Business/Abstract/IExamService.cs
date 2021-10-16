using Core.Entities.Concrete;
using Core.Entities.Dtos.Exam;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface IExamService
    {
        IDataResult<List<Exam>> GetList(Expression<Func<Exam, bool>> filter = null);
        IDataResult<List<GetExamDto>> GetDtoList(Func<GetExamDto, bool> filter = null, int takeCount = 2000);
        IDataResult<Exam> Get(Expression<Func<Exam, bool>> filter);
        IDataResult<GetExamDto> GetDto(Expression<Func<Exam, bool>> filter = null);
        IDataResult<int> Add(Exam exam);
        IDataResult<int> Update(Exam exam);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<Exam> exams);
        IDataResult<int> UpdateList(List<Exam> exams);
        IDataResult<int> DeletePermanentlyList(List<Exam> exams);
        IDataResult<int> DeleteByStatusList(List<Exam> exams);

        Task<IDataResult<List<GetExamDto>>> GetDtoListAsync(Expression<Func<Exam, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetExamDto>> GetDtoAsync(Expression<Func<Exam, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<Exam> exams);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<Exam> exams);
        Task<IDataResult<List<Exam>>> GetListAsync(Expression<Func<Exam, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<Exam> exams);
        Task<IDataResult<int>> UpdateAsync(Exam exam);
        Task<IDataResult<Exam>> GetAsync(Expression<Func<Exam, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(Exam exam);
    }
}
