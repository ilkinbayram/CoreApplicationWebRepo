using Core.Entities.Concrete;
using Core.Entities.Dtos.UserSocialMedia;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

        Task<IDataResult<List<GetUserSocialMediaDto>>> GetDtoListAsync(Expression<Func<UserSocialMedia, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetUserSocialMediaDto>> GetDtoAsync(Expression<Func<UserSocialMedia, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<UserSocialMedia> userSocialMedias);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<UserSocialMedia> userSocialMedias);
        Task<IDataResult<List<UserSocialMedia>>> GetListAsync(Expression<Func<UserSocialMedia, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<UserSocialMedia> userSocialMedias);
        Task<IDataResult<int>> UpdateAsync(UserSocialMedia userSocialMedia);
        Task<IDataResult<UserSocialMedia>> GetAsync(Expression<Func<UserSocialMedia, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(UserSocialMedia userSocialMedia);
    }
}
