using Core.Entities.Concrete;
using Core.Entities.Dtos.Phrase;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface IPhraseService
    {
        IDataResult<List<Phrase>> GetList(Expression<Func<Phrase, bool>> filter = null);
        IDataResult<Phrase> Get(Expression<Func<Phrase, bool>> filter);
        IDataResult<List<GetPhraseDto>> GetDtoList(Func<GetPhraseDto, bool> filter = null, int takeCount = 2000);
        IDataResult<GetPhraseDto> GetDto(Func<GetPhraseDto, bool> filter);
        IDataResult<int> Add(Phrase phrase);
        IDataResult<int> Update(Phrase phrase);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<Phrase> phrases);
        IDataResult<int> UpdateList(List<Phrase> phrases);
        IDataResult<int> DeletePermanentlyList(List<Phrase> phrases);
        IDataResult<int> DeleteByStatusList(List<Phrase> phrases);
    }
}
