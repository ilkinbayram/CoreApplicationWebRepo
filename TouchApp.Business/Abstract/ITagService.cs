using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface ITagService
    {
        IDataResult<IEnumerable<Tag>> GetList(Expression<Func<Tag, bool>> filter = null);
        IDataResult<Tag> Get(Expression<Func<Tag, bool>> filter);
        IDataResult<int> Add(Tag tag);
        IDataResult<int> Update(Tag tag);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<Tag> tags);
        IDataResult<int> UpdateList(IEnumerable<Tag> tags);
        IDataResult<int> DeletePermanentlyList(IEnumerable<Tag> tags);
        IDataResult<int> DeleteByStatusList(IEnumerable<Tag> tags);
    }
}
