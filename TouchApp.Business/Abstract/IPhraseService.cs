using Core.Entities.Concrete;
using Core.Entities.Dtos.Phrase;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface IPhraseService
    {
        IDataResult<List<Phrase>> GetList(Expression<Func<Phrase, bool>> filter = null);
        IDataResult<Phrase> Get(Expression<Func<Phrase, bool>> filter);
        IDataResult<List<GetPhraseDto>> GetDtoList(Expression<Func<Phrase, bool>> filter = null, int takeCount = 2000);
        IDataResult<GetPhraseDto> GetDto(Expression<Func<Phrase, bool>> filter = null);
        IDataResult<int> Add(Phrase phrase);
        IDataResult<int> Update(Phrase phrase);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<Phrase> phrases);
        IDataResult<int> UpdateList(List<Phrase> phrases);
        IDataResult<int> DeletePermanentlyList(List<Phrase> phrases);
        IDataResult<int> DeleteByStatusList(List<Phrase> phrases);

        Task<IDataResult<List<GetPhraseDto>>> GetDtoListAsync(Expression<Func<Phrase, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetPhraseDto>> GetDtoAsync(Expression<Func<Phrase, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<Phrase> phrases);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<Phrase> phrases);
        Task<IDataResult<List<Phrase>>> GetListAsync(Expression<Func<Phrase, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<Phrase> phrases);
        Task<IDataResult<int>> UpdateAsync(Phrase phrase);
        Task<IDataResult<Phrase>> GetAsync(Expression<Func<Phrase, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(Phrase phrase);
    }
}
