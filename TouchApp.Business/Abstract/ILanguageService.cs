using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface ILanguageService
    {
        IDataResult<IEnumerable<Language>> GetList(Expression<Func<Language, bool>> filter = null);
        IDataResult<Language> Get(Expression<Func<Language, bool>> filter);
        IDataResult<int> Add(Language language);
        IDataResult<int> Update(Language language);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<Language> languages);
        IDataResult<int> UpdateList(IEnumerable<Language> languages);
        IDataResult<int> DeletePermanentlyList(IEnumerable<Language> languages);
        IDataResult<int> DeleteByStatusList(IEnumerable<Language> languages);
    }
}
