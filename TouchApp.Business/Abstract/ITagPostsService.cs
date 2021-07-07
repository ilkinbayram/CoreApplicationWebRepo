using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface ITagPostsService
    {
        IDataResult<IEnumerable<TagPosts>> GetList(Expression<Func<TagPosts, bool>> filter = null);
        IDataResult<TagPosts> Get(Expression<Func<TagPosts, bool>> filter);
        IDataResult<int> Add(TagPosts tagPosts);
        IDataResult<int> Update(TagPosts tagPosts);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<TagPosts> tagPostss);
        IDataResult<int> UpdateList(IEnumerable<TagPosts> tagPostss);
        IDataResult<int> DeletePermanentlyList(IEnumerable<TagPosts> tagPostss);
        IDataResult<int> DeleteByStatusList(IEnumerable<TagPosts> tagPostss);
    }
}
