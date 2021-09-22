using Core.Entities.Concrete;
using Core.Entities.Dtos.ExamQuestion;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface IExamQuestionService
    {
        IDataResult<List<ExamQuestion>> GetList(Expression<Func<ExamQuestion, bool>> filter = null);
        IDataResult<List<GetExamQuestionDto>> GetDtoList(Func<GetExamQuestionDto, bool> filter = null, int takeCount = 2000);
        IDataResult<ExamQuestion> Get(Expression<Func<ExamQuestion, bool>> filter);
        IDataResult<GetExamQuestionDto> GetDto(Func<GetExamQuestionDto, bool> filter);
        IDataResult<int> Add(ExamQuestion examQuestion);
        IDataResult<int> Update(ExamQuestion examQuestion);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<ExamQuestion> examQuestions);
        IDataResult<int> UpdateList(List<ExamQuestion> examQuestions);
        IDataResult<int> DeletePermanentlyList(List<ExamQuestion> examQuestions);
        IDataResult<int> DeleteByStatusList(List<ExamQuestion> examQuestions);

        Task<IDataResult<List<GetExamQuestionDto>>> GetDtoListAsync(Expression<Func<ExamQuestion, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetExamQuestionDto>> GetDtoAsync(Expression<Func<ExamQuestion, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<ExamQuestion> examQuestions);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<ExamQuestion> examQuestions);
        Task<IDataResult<List<ExamQuestion>>> GetListAsync(Expression<Func<ExamQuestion, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<ExamQuestion> examQuestions);
        Task<IDataResult<int>> UpdateAsync(ExamQuestion examQuestion);
        Task<IDataResult<ExamQuestion>> GetAsync(Expression<Func<ExamQuestion, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(ExamQuestion examQuestion);
    }
}
