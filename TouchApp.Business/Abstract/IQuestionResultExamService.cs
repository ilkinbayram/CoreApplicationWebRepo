using Core.Entities.Concrete;
using Core.Entities.Dtos.QuestionResultExam;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface IQuestionResultExamService
    {
        IDataResult<List<QuestionResultExam>> GetList(Expression<Func<QuestionResultExam, bool>> filter = null);
        IDataResult<List<GetQuestionResultExamDto>> GetDtoList(Func<GetQuestionResultExamDto, bool> filter = null, int takeCount = 2000);
        IDataResult<QuestionResultExam> Get(Expression<Func<QuestionResultExam, bool>> filter);
        IDataResult<GetQuestionResultExamDto> GetDto(Func<GetQuestionResultExamDto, bool> filter);
        IDataResult<int> Add(QuestionResultExam questionResultExam);
        IDataResult<int> Update(QuestionResultExam questionResultExam);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<QuestionResultExam> questionResultExams);
        IDataResult<int> UpdateList(List<QuestionResultExam> questionResultExams);
        IDataResult<int> DeletePermanentlyList(List<QuestionResultExam> questionResultExams);
        IDataResult<int> DeleteByStatusList(List<QuestionResultExam> questionResultExams);

        Task<IDataResult<List<GetQuestionResultExamDto>>> GetDtoListAsync(Expression<Func<QuestionResultExam, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetQuestionResultExamDto>> GetDtoAsync(Expression<Func<QuestionResultExam, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<QuestionResultExam> questionResultExams);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<QuestionResultExam> questionResultExams);
        Task<IDataResult<List<QuestionResultExam>>> GetListAsync(Expression<Func<QuestionResultExam, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<QuestionResultExam> questionResultExams);
        Task<IDataResult<int>> UpdateAsync(QuestionResultExam questionResultExam);
        Task<IDataResult<QuestionResultExam>> GetAsync(Expression<Func<QuestionResultExam, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(QuestionResultExam questionResultExam);
    }
}
