using Core.Entities.Concrete;
using Core.Entities.Dtos.Profession;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface IProfessionService
    {
        IDataResult<List<Profession>> GetList(Expression<Func<Profession, bool>> filter = null);
        IDataResult<Profession> Get(Expression<Func<Profession, bool>> filter);
        IDataResult<int> Add(Profession profession);
        IDataResult<int> Update(Profession profession);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<Profession> professions);
        IDataResult<int> UpdateList(List<Profession> professions);
        IDataResult<int> DeletePermanentlyList(List<Profession> professions);
        IDataResult<int> DeleteByStatusList(List<Profession> professions);

        Task<IDataResult<List<GetProfessionDto>>> GetDtoListAsync(Expression<Func<Profession, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetProfessionDto>> GetDtoAsync(Expression<Func<Profession, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<Profession> professions);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<Profession> professions);
        Task<IDataResult<List<Profession>>> GetListAsync(Expression<Func<Profession, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<Profession> professions);
        Task<IDataResult<int>> UpdateAsync(Profession profession);
        Task<IDataResult<Profession>> GetAsync(Expression<Func<Profession, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(Profession profession);
    }
}
