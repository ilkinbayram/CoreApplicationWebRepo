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
        IDataResult<List<Tag>> GetList(Expression<Func<Tag, bool>> filter = null);
        IDataResult<Tag> Get(Expression<Func<Tag, bool>> filter);
        IDataResult<int> Add(Tag tag);
        IDataResult<int> Update(Tag tag);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<Tag> tags);
        IDataResult<int> UpdateList(List<Tag> tags);
        IDataResult<int> DeletePermanentlyList(List<Tag> tags);
        IDataResult<int> DeleteByStatusList(List<Tag> tags);
    }
}
