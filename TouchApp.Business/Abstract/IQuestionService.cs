using Core.Entities.Concrete;
using Core.Entities.Dtos.Question;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface IQuestionService
    {
        IDataResult<List<Question>> GetList(Expression<Func<Question, bool>> filter = null);
        IDataResult<List<GetQuestionDto>> GetDtoList(Func<GetQuestionDto, bool> filter = null, int takeCount = 2000);
        IDataResult<Question> Get(Expression<Func<Question, bool>> filter);
        IDataResult<GetQuestionDto> GetDto(Expression<Func<Question, bool>> filter = null);
        IDataResult<int> Add(Question question);
        IDataResult<int> Update(Question question);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<Question> questions);
        IDataResult<int> UpdateList(List<Question> questions);
        IDataResult<int> DeletePermanentlyList(List<Question> questions);
        IDataResult<int> DeleteByStatusList(List<Question> questions);

        Task<IDataResult<List<GetQuestionDto>>> GetDtoListAsync(Expression<Func<Question, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetQuestionDto>> GetDtoAsync(Expression<Func<Question, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<Question> questions);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<Question> questions);
        Task<IDataResult<List<Question>>> GetListAsync(Expression<Func<Question, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<Question> questions);
        Task<IDataResult<int>> UpdateAsync(Question question);
        Task<IDataResult<Question>> GetAsync(Expression<Func<Question, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(Question question);
    }
}
