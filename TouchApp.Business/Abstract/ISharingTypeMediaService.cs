using Core.Entities.Concrete;
using Core.Entities.Dtos.SharingTypeMedia;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface ISharingTypeMediaService
    {
        IDataResult<List<SharingTypeMedia>> GetList(Expression<Func<SharingTypeMedia, bool>> filter = null);
        IDataResult<SharingTypeMedia> Get(Expression<Func<SharingTypeMedia, bool>> filter);
        IDataResult<GetSharingTypeMediaDto> GetDto(Expression<Func<SharingTypeMedia, bool>> filter = null);
        IDataResult<int> Add(SharingTypeMedia sharingTypeMedia);
        IDataResult<int> Update(SharingTypeMedia sharingTypeMedia);
        IDataResult<int> DeletePermanently(long id);
        IDataResult<int> DeleteByStatus(long id);
        IDataResult<int> AddList(List<SharingTypeMedia> sharingTypeMedias);
        IDataResult<int> UpdateList(List<SharingTypeMedia> sharingTypeMedias);
        IDataResult<int> DeletePermanentlyList(List<SharingTypeMedia> sharingTypeMedias);
        IDataResult<int> DeleteByStatusList(List<SharingTypeMedia> sharingTypeMedias);

        Task<IDataResult<List<GetSharingTypeMediaDto>>> GetDtoListAsync(Expression<Func<SharingTypeMedia, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetSharingTypeMediaDto>> GetDtoAsync(Expression<Func<SharingTypeMedia, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<SharingTypeMedia> sharingTypeMedias);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<SharingTypeMedia> sharingTypeMedias);
        Task<IDataResult<List<SharingTypeMedia>>> GetListAsync(Expression<Func<SharingTypeMedia, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<SharingTypeMedia> sharingTypeMedias);
        Task<IDataResult<int>> UpdateAsync(SharingTypeMedia sharingTypeMedia);
        Task<IDataResult<SharingTypeMedia>> GetAsync(Expression<Func<SharingTypeMedia, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(SharingTypeMedia sharingTypeMedia);
    }
}
