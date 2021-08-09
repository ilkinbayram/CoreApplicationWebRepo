using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface IBlogService
    {
        IDataResult<IEnumerable<Blog>> GetList(Expression<Func<Blog, bool>> filter = null);
        IDataResult<Blog> Get(Expression<Func<Blog, bool>> filter);
        IDataResult<int> Add(Blog blog);
        IDataResult<int> Update(Blog blog);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<Blog> blogs);
        IDataResult<int> UpdateList(IEnumerable<Blog> blogs);
        IDataResult<int> DeletePermanentlyList(IEnumerable<Blog> blogs);
        IDataResult<int> DeleteByStatusList(IEnumerable<Blog> blogs);
    }
}
