using Core.Entities.Concrete;
using Core.Entities.Dtos.Media;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

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
    }
}
