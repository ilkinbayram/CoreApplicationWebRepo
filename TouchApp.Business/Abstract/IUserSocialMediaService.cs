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
        IDataResult<List<UserSocialMedia>> GetList(Expression<Func<UserSocialMedia, bool>> filter = null);
        IDataResult<UserSocialMedia> Get(Expression<Func<UserSocialMedia, bool>> filter);
        IDataResult<int> Add(UserSocialMedia userSocialMedia);
        IDataResult<int> Update(UserSocialMedia userSocialMedia);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<UserSocialMedia> userSocialMedias);
        IDataResult<int> UpdateList(List<UserSocialMedia> userSocialMedias);
        IDataResult<int> DeletePermanentlyList(List<UserSocialMedia> userSocialMedias);
        IDataResult<int> DeleteByStatusList(List<UserSocialMedia> userSocialMedias);
    }
}
