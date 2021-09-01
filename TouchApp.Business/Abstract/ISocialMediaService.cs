using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface ISocialMediaService
    {
        IDataResult<List<SocialMedia>> GetList(Expression<Func<SocialMedia, bool>> filter = null);
        IDataResult<SocialMedia> Get(Expression<Func<SocialMedia, bool>> filter);
        IDataResult<int> Add(SocialMedia socialMedia);
        IDataResult<int> Update(SocialMedia socialMedia);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<SocialMedia> socialMedias);
        IDataResult<int> UpdateList(List<SocialMedia> socialMedias);
        IDataResult<int> DeletePermanentlyList(List<SocialMedia> socialMedias);
        IDataResult<int> DeleteByStatusList(List<SocialMedia> socialMedias);
    }
}
