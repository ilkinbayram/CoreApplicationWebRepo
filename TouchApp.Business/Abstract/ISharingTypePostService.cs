using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface ISharingTypePostService
    {
        IDataResult<IEnumerable<SharingTypePost>> GetList(Expression<Func<SharingTypePost, bool>> filter = null);
        IDataResult<SharingTypePost> Get(Expression<Func<SharingTypePost, bool>> filter);
        IDataResult<int> Add(SharingTypePost sharingTypePost);
        IDataResult<int> Update(SharingTypePost sharingTypePost);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<SharingTypePost> sharingTypePosts);
        IDataResult<int> UpdateList(IEnumerable<SharingTypePost> sharingTypePosts);
        IDataResult<int> DeletePermanentlyList(IEnumerable<SharingTypePost> sharingTypePosts);
        IDataResult<int> DeleteByStatusList(IEnumerable<SharingTypePost> sharingTypePosts);
    }
}
