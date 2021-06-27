using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface IMediaService
    {
        IDataResult<IEnumerable<Media>> GetList(Expression<Func<Media, bool>> filter = null);
        IDataResult<Media> Get(Expression<Func<Media, bool>> filter);
        IDataResult<int> Add(Media media);
        IDataResult<int> Update(Media media);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<Media> medias);
        IDataResult<int> UpdateList(IEnumerable<Media> medias);
        IDataResult<int> DeletePermanentlyList(IEnumerable<Media> medias);
        IDataResult<int> DeleteByStatusList(IEnumerable<Media> medias);
    }
}
