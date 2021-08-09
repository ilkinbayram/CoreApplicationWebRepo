using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface ISharingTypeMediaService
    {
        IDataResult<IEnumerable<SharingTypeMedia>> GetList(Expression<Func<SharingTypeMedia, bool>> filter = null);
        IDataResult<SharingTypeMedia> Get(Expression<Func<SharingTypeMedia, bool>> filter);
        IDataResult<int> Add(SharingTypeMedia sharingTypeMedia);
        IDataResult<int> Update(SharingTypeMedia sharingTypeMedia);
        IDataResult<int> DeletePermanently(long id);
        IDataResult<int> DeleteByStatus(long id);
        IDataResult<int> AddList(IEnumerable<SharingTypeMedia> sharingTypeMedias);
        IDataResult<int> UpdateList(IEnumerable<SharingTypeMedia> sharingTypeMedias);
        IDataResult<int> DeletePermanentlyList(IEnumerable<SharingTypeMedia> sharingTypeMedias);
        IDataResult<int> DeleteByStatusList(IEnumerable<SharingTypeMedia> sharingTypeMedias);
    }
}
