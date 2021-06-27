using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface IPostService
    {
        IDataResult<IEnumerable<Post>> GetList(Expression<Func<Post, bool>> filter = null);
        IDataResult<Post> Get(Expression<Func<Post, bool>> filter);
        IDataResult<int> Add(Post post);
        IDataResult<int> Update(Post post);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<Post> posts);
        IDataResult<int> UpdateList(IEnumerable<Post> posts);
        IDataResult<int> DeletePermanentlyList(IEnumerable<Post> posts);
        IDataResult<int> DeleteByStatusList(IEnumerable<Post> posts);
    }
}
