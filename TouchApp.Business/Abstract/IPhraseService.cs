using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface IPhraseService
    {
        IDataResult<IEnumerable<Phrase>> GetList(Expression<Func<Phrase, bool>> filter = null);
        IDataResult<Phrase> Get(Expression<Func<Phrase, bool>> filter);
        IDataResult<int> Add(Phrase phrase);
        IDataResult<int> Update(Phrase phrase);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<Phrase> phrases);
        IDataResult<int> UpdateList(IEnumerable<Phrase> phrases);
        IDataResult<int> DeletePermanentlyList(IEnumerable<Phrase> phrases);
        IDataResult<int> DeleteByStatusList(IEnumerable<Phrase> phrases);
    }
}
