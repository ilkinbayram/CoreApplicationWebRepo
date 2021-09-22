using Core.Entities.Concrete;
using Core.Entities.Dtos.Localization;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface ILocalizationService
    {
        IDataResult<List<Localization>> GetList(Expression<Func<Localization, bool>> filter = null);
        IDataResult<Localization> Get(Expression<Func<Localization, bool>> filter);
        IDataResult<int> Add(CreateLocalizationDto localization);
        IDataResult<int> Update(Localization localization);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<Localization> localizations);
        IDataResult<int> UpdateList(List<Localization> localizations);
        IDataResult<int> DeletePermanentlyList(List<Localization> localizations);
        IDataResult<int> DeleteByStatusList(List<Localization> localizations);

        //Task<IDataResult<List<GetLocalizationDto>>> GetDtoListAsync(Expression<Func<Localization, bool>> filter = null, int takeCount = 2000);
        //Task<IDataResult<GetLocalizationDto>> GetDtoAsync(Expression<Func<Localization, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<Localization> localizations);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<Localization> localizations);
        Task<IDataResult<List<Localization>>> GetListAsync(Expression<Func<Localization, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<Localization> localizations);
        Task<IDataResult<int>> UpdateAsync(Localization localization);
        Task<IDataResult<Localization>> GetAsync(Expression<Func<Localization, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddDtoAsync(CreateLocalizationDto localization);
        Task<IDataResult<int>> AddModelAsync(Localization localization);
    }
}
