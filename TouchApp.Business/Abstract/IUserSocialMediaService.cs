using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface IUserSocialMediaService
    {
        IDataResult<IEnumerable<UserSocialMedia>> GetList(Expression<Func<UserSocialMedia, bool>> filter = null);
        IDataResult<UserSocialMedia> Get(Expression<Func<UserSocialMedia, bool>> filter);
        IDataResult<int> Add(UserSocialMedia userSocialMedia);
        IDataResult<int> Update(UserSocialMedia userSocialMedia);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<UserSocialMedia> userSocialMedias);
        IDataResult<int> UpdateList(IEnumerable<UserSocialMedia> userSocialMedias);
        IDataResult<int> DeletePermanentlyList(IEnumerable<UserSocialMedia> userSocialMedias);
        IDataResult<int> DeleteByStatusList(IEnumerable<UserSocialMedia> userSocialMedias);
    }
}
