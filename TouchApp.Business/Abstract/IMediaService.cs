using Core.Entities.Concrete;
using Core.Entities.Dtos.Media;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface IMediaService
    {
        IDataResult<List<Media>> GetList(Expression<Func<Media, bool>> filter = null);
        IDataResult<Media> Get(Expression<Func<Media, bool>> filter);
        IDataResult<List<GetMediaDto>> GetDtoList(Func<GetMediaDto, bool> filter = null, int takeCount = 2000);
        IDataResult<GetMediaDto> GetDto(Func<GetMediaDto, bool> filter);
        IDataResult<int> Add(Media media);
        IDataResult<int> Update(Media media);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<Media> medias);
        IDataResult<int> UpdateList(List<Media> medias);
        IDataResult<int> DeletePermanentlyList(List<Media> medias);
        IDataResult<int> DeleteByStatusList(List<Media> medias);

        Task<IDataResult<List<GetMediaDto>>> GetDtoListAsync(Expression<Func<Media, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetMediaDto>> GetDtoAsync(Expression<Func<Media, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<Media> medias);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<Media> medias);
        Task<IDataResult<List<Media>>> GetListAsync(Expression<Func<Media, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<Media> medias);
        Task<IDataResult<int>> UpdateAsync(Media media);
        Task<IDataResult<Media>> GetAsync(Expression<Func<Media, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(Media media);
    }
}
