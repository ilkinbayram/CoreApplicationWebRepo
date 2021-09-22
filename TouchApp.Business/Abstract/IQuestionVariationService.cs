using Core.Entities.Concrete;
using Core.Entities.Dtos.QuestionVariation;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface IQuestionVariationService
    {
        IDataResult<List<QuestionVariation>> GetList(Expression<Func<QuestionVariation, bool>> filter = null);
        IDataResult<List<GetQuestionVariationDto>> GetDtoList(Func<GetQuestionVariationDto, bool> filter = null, int takeCount = 2000);
        IDataResult<QuestionVariation> Get(Expression<Func<QuestionVariation, bool>> filter);
        IDataResult<GetQuestionVariationDto> GetDto(Func<GetQuestionVariationDto, bool> filter);
        IDataResult<int> Add(QuestionVariation questionVariation);
        IDataResult<int> Update(QuestionVariation questionVariation);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<QuestionVariation> questionVariations);
        IDataResult<int> UpdateList(List<QuestionVariation> questionVariations);
        IDataResult<int> DeletePermanentlyList(List<QuestionVariation> questionVariations);
        IDataResult<int> DeleteByStatusList(List<QuestionVariation> questionVariations);

        Task<IDataResult<List<GetQuestionVariationDto>>> GetDtoListAsync(Expression<Func<QuestionVariation, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetQuestionVariationDto>> GetDtoAsync(Expression<Func<QuestionVariation, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<QuestionVariation> questionVariations);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<QuestionVariation> questionVariations);
        Task<IDataResult<List<QuestionVariation>>> GetListAsync(Expression<Func<QuestionVariation, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<QuestionVariation> questionVariations);
        Task<IDataResult<int>> UpdateAsync(QuestionVariation questionVariation);
        Task<IDataResult<QuestionVariation>> GetAsync(Expression<Func<QuestionVariation, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(QuestionVariation questionVariation);
    }
}
