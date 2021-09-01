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
        IDataResult<List<Language>> GetList(Expression<Func<Language, bool>> filter = null);
        IDataResult<Language> Get(Expression<Func<Language, bool>> filter);
        IDataResult<int> Add(Language language);
        IDataResult<int> Update(Language language);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<Language> languages);
        IDataResult<int> UpdateList(List<Language> languages);
        IDataResult<int> DeletePermanentlyList(List<Language> languages);
        IDataResult<int> DeleteByStatusList(List<Language> languages);
    }
}
