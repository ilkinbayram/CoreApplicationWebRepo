using Core.Entities.Concrete;
using Core.Entities.Dtos.AnswerVariation;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface IAnswerVariationService
    {
        IDataResult<List<AnswerVariation>> GetList(Expression<Func<AnswerVariation, bool>> filter = null);
        IDataResult<List<GetAnswerVariationDto>> GetDtoList(Func<GetAnswerVariationDto, bool> filter = null, int takeCount = 2000);
        IDataResult<AnswerVariation> Get(Expression<Func<AnswerVariation, bool>> filter);
        IDataResult<GetAnswerVariationDto> GetDto(Func<GetAnswerVariationDto, bool> filter);
        IDataResult<int> Add(AnswerVariation answerVariation);
        IDataResult<int> Update(AnswerVariation answerVariation);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<AnswerVariation> answerVariations);
        IDataResult<int> UpdateList(List<AnswerVariation> answerVariations);
        IDataResult<int> DeletePermanentlyList(List<AnswerVariation> answerVariations);
        IDataResult<int> DeleteByStatusList(List<AnswerVariation> answerVariations);

        Task<IDataResult<List<GetAnswerVariationDto>>> GetDtoListAsync(Expression<Func<AnswerVariation, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetAnswerVariationDto>> GetDtoAsync(Expression<Func<AnswerVariation, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<AnswerVariation> answerVariations);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<AnswerVariation> answerVariations);
        Task<IDataResult<List<AnswerVariation>>> GetListAsync(Expression<Func<AnswerVariation, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<AnswerVariation> answerVariations);
        Task<IDataResult<int>> UpdateAsync(AnswerVariation answerVariation);
        Task<IDataResult<AnswerVariation>> GetAsync(Expression<Func<AnswerVariation, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(AnswerVariation answerVariation);
    }
}
