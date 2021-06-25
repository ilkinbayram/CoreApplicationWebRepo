using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IUserLanguageService
    {
        IDataResult<IEnumerable<UserLanguage>> GetList(Expression<Func<UserLanguage, bool>> filter = null);
        IDataResult<UserLanguage> Get(Expression<Func<UserLanguage, bool>> filter);
        IDataResult<int> Add(UserLanguage userLanguage);
        IDataResult<int> Update(UserLanguage userLanguage);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<UserLanguage> userLanguages);
        IDataResult<int> UpdateList(IEnumerable<UserLanguage> userLanguages);
        IDataResult<int> DeletePermanentlyList(IEnumerable<UserLanguage> userLanguages);
        IDataResult<int> DeleteByStatusList(IEnumerable<UserLanguage> userLanguages);
    }
}
