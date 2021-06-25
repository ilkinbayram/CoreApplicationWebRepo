using Core.Entities.Concrete;
using Core.Entities.Dtos.Home;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IHomeMetaTagService
    {
        IDataResult<IEnumerable<HomeMetaTag>> GetList(Expression<Func<HomeMetaTag, bool>> filter = null);
        IDataResult<GetHomeMetaTagDto> Get(Expression<Func<HomeMetaTag, bool>> filter);
        IDataResult<int> Add(CreateHomeMetaTagDto createHomeMetaTagDto);
        IDataResult<int> Update(EditHomeMetaTagDto editHomeMetaTagDto);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<CreateHomeMetaTagDto> createHomeMetaTagDtos);
        IDataResult<int> UpdateList(IEnumerable<HomeMetaTag> homeMetaTags);
        IDataResult<int> DeletePermanentlyList(IEnumerable<HomeMetaTag> homeMetaTags);
        IDataResult<int> DeleteByStatusList(IEnumerable<HomeMetaTag> homeMetaTags);
        IDataResult<GetHomeMetaTagDto> GetItemWithInclude(Expression<Func<HomeMetaTag, bool>> filter);
        IDataResult<IEnumerable<GetHomeMetaTagDto>> GetAllItemsWithInclude(Expression<Func<HomeMetaTag, bool>> filter = null);
        IDataResult<IEnumerable<GetHomeMetaTagDto>> GetAllItemsWithIncludeByLang(long langID,Expression<Func<HomeMetaTag, bool>> filter = null);
        IDataResult<bool> CheckIsExist(long id);
    }
}
