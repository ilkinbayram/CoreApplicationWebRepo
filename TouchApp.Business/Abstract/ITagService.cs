using Core.Entities.Concrete;
using Core.Entities.Dtos.Tag;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface ITagService
    {
        IDataResult<List<Tag>> GetList(Expression<Func<Tag, bool>> filter = null);
        IDataResult<List<GetTagDto>> GetListDto(Expression<Func<Tag, bool>> filter = null);
        IDataResult<Tag> Get(Expression<Func<Tag, bool>> filter);
        IDataResult<GetTagDto> GetDto(Expression<Func<Tag, bool>> filter = null);
        IDataResult<int> Add(Tag tag);
        IDataResult<int> Update(Tag tag);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<Tag> tags);
        IDataResult<int> UpdateList(List<Tag> tags);
        IDataResult<int> DeletePermanentlyList(List<Tag> tags);
        IDataResult<int> DeleteByStatusList(List<Tag> tags);

        Task<IDataResult<List<GetTagDto>>> GetDtoListAsync(Expression<Func<Tag, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetTagDto>> GetDtoAsync(Expression<Func<Tag, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<Tag> tags);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<Tag> tags);
        Task<IDataResult<List<Tag>>> GetListAsync(Expression<Func<Tag, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<Tag> tags);
        Task<IDataResult<int>> UpdateAsync(Tag tag);
        Task<IDataResult<Tag>> GetAsync(Expression<Func<Tag, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(Tag tag);
    }
}
