using Core.Entities.Concrete;
using Core.Entities.Dtos.ResultExam;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface IResultExamService
    {
        IDataResult<List<ResultExam>> GetList(Expression<Func<ResultExam, bool>> filter = null);
        IDataResult<List<GetResultExamDto>> GetDtoList(Func<GetResultExamDto, bool> filter = null, int takeCount = 2000);
        IDataResult<ResultExam> Get(Expression<Func<ResultExam, bool>> filter);
        IDataResult<GetResultExamDto> GetDto(Func<GetResultExamDto, bool> filter);
        IDataResult<int> Add(ResultExam resultExam);
        IDataResult<int> Update(ResultExam resultExam);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<ResultExam> resultExams);
        IDataResult<int> UpdateList(List<ResultExam> resultExams);
        IDataResult<int> DeletePermanentlyList(List<ResultExam> resultExams);
        IDataResult<int> DeleteByStatusList(List<ResultExam> resultExams);

        Task<IDataResult<List<GetResultExamDto>>> GetDtoListAsync(Expression<Func<ResultExam, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetResultExamDto>> GetDtoAsync(Expression<Func<ResultExam, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<ResultExam> resultExams);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<ResultExam> resultExams);
        Task<IDataResult<List<ResultExam>>> GetListAsync(Expression<Func<ResultExam, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<ResultExam> resultExams);
        Task<IDataResult<int>> UpdateAsync(ResultExam resultExam);
        Task<IDataResult<ResultExam>> GetAsync(Expression<Func<ResultExam, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(ResultExam resultExam);
    }
}
