using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IHomeMetaTagGalleryService
    {
        IDataResult<IEnumerable<HomeMetaTagGallery>> GetList(Expression<Func<HomeMetaTagGallery, bool>> filter = null);
        IDataResult<HomeMetaTagGallery> Get(Expression<Func<HomeMetaTagGallery, bool>> filter);
        IDataResult<int> Add(HomeMetaTagGallery homeMetaTagGallery);
        IDataResult<int> Update(HomeMetaTagGallery homeMetaTagGallery);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<HomeMetaTagGallery> homeMetaTagGalleries);
        IDataResult<int> UpdateList(IEnumerable<HomeMetaTagGallery> homeMetaTagGalleries);
        IDataResult<int> DeletePermanentlyList(IEnumerable<HomeMetaTagGallery> homeMetaTagGalleries);
        IDataResult<int> DeleteByStatusList(IEnumerable<HomeMetaTagGallery> homeMetaTagGalleries);
    }
}
