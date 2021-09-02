using Core.Entities.Concrete;
using Core.Entities.Dtos.SharingType;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface ISharingTypeService
    {
        IDataResult<List<SharingType>> GetList(Expression<Func<SharingType, bool>> filter = null);
        IDataResult<SharingType> Get(Expression<Func<SharingType, bool>> filter);
        IDataResult<int> Add(SharingType sharingType);
        IDataResult<int> Update(SharingType sharingType);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<SharingType> sharingTypes);
        IDataResult<int> UpdateList(List<SharingType> sharingTypes);
        IDataResult<int> DeletePermanentlyList(List<SharingType> sharingTypes);
        IDataResult<int> DeleteByStatusList(List<SharingType> sharingTypes);

        Task<IDataResult<List<GetSharingTypeDto>>> GetDtoListAsync(Expression<Func<SharingType, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetSharingTypeDto>> GetDtoAsync(Expression<Func<SharingType, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<SharingType> sharingTypes);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<SharingType> sharingTypes);
        Task<IDataResult<List<SharingType>>> GetListAsync(Expression<Func<SharingType, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<SharingType> sharingTypes);
        Task<IDataResult<int>> UpdateAsync(SharingType sharingType);
        Task<IDataResult<SharingType>> GetAsync(Expression<Func<SharingType, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(SharingType sharingType);
    }
}
