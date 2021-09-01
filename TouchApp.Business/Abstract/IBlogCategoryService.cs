using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace TouchApp.Business.Abstract
{
    public interface IBlogCategoryService
    {
        IDataResult<List<BlogCategory>> GetList(Expression<Func<BlogCategory, bool>> filter = null);
        IDataResult<BlogCategory> Get(Expression<Func<BlogCategory, bool>> filter);
        IDataResult<int> Add(BlogCategory blogCategory);
        IDataResult<int> Update(BlogCategory blogCategory);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<BlogCategory> blogCategorys);
        IDataResult<int> UpdateList(List<BlogCategory> blogCategorys);
        IDataResult<int> DeletePermanentlyList(List<BlogCategory> blogCategorys);
        IDataResult<int> DeleteByStatusList(List<BlogCategory> blogCategorys);
    }
}
