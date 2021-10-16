using Core.Entities.Concrete;
using Core.Entities.Dtos.SocialMedia;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface ISocialMediaService
    {
        IDataResult<List<SocialMedia>> GetList(Expression<Func<SocialMedia, bool>> filter = null);
        IDataResult<SocialMedia> Get(Expression<Func<SocialMedia, bool>> filter);
        IDataResult<GetSocialMediaDto> GetDto(Expression<Func<SocialMedia, bool>> filter = null);
        IDataResult<int> Add(SocialMedia socialMedia);
        IDataResult<int> Update(SocialMedia socialMedia);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<SocialMedia> socialMedias);
        IDataResult<int> UpdateList(List<SocialMedia> socialMedias);
        IDataResult<int> DeletePermanentlyList(List<SocialMedia> socialMedias);
        IDataResult<int> DeleteByStatusList(List<SocialMedia> socialMedias);

        Task<IDataResult<List<GetSocialMediaDto>>> GetDtoListAsync(Expression<Func<SocialMedia, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetSocialMediaDto>> GetDtoAsync(Expression<Func<SocialMedia, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<SocialMedia> socialMedias);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<SocialMedia> socialMedias);
        Task<IDataResult<List<SocialMedia>>> GetListAsync(Expression<Func<SocialMedia, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<SocialMedia> socialMedias);
        Task<IDataResult<int>> UpdateAsync(SocialMedia socialMedia);
        Task<IDataResult<SocialMedia>> GetAsync(Expression<Func<SocialMedia, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(SocialMedia socialMedia);
    }
}
