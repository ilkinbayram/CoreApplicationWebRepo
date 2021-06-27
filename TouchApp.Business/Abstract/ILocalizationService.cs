using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface ILocalizationService
    {
        IDataResult<IEnumerable<Localization>> GetList(Expression<Func<Localization, bool>> filter = null);
        IDataResult<Localization> Get(Expression<Func<Localization, bool>> filter);
        IDataResult<int> Add(Localization localization);
        IDataResult<int> Update(Localization localization);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<Localization> localizations);
        IDataResult<int> UpdateList(IEnumerable<Localization> localizations);
        IDataResult<int> DeletePermanentlyList(IEnumerable<Localization> localizations);
        IDataResult<int> DeleteByStatusList(IEnumerable<Localization> localizations);
    }
}
