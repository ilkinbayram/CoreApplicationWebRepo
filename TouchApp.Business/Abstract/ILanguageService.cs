using Core.Entities.Concrete;
using Core.Entities.Dtos.Language;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface ILanguageService
    {
        IDataResult<List<Language>> GetList(Expression<Func<Language, bool>> filter = null);
        IDataResult<Language> Get(Expression<Func<Language, bool>> filter);
        IDataResult<int> Add(CreateManagementLanguageDto language);
        IDataResult<int> Update(Language language);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<Language> languages);
        IDataResult<int> UpdateList(List<Language> languages);
        IDataResult<int> DeletePermanentlyList(List<Language> languages);
        IDataResult<int> DeleteByStatusList(List<Language> languages);

        //Task<IDataResult<List<GetLanguageDto>>> GetDtoListAsync(Expression<Func<Language, bool>> filter = null, int takeCount = 2000);
        //Task<IDataResult<GetLanguageDto>> GetDtoAsync(Expression<Func<Language, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<Language> languages);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<Language> languages);
        Task<IDataResult<List<Language>>> GetListAsync(Expression<Func<Language, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<Language> languages);
        Task<IDataResult<int>> UpdateAsync(Language language);
        Task<IDataResult<Language>> GetAsync(Expression<Func<Language, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(CreateManagementLanguageDto language);
    }
}
