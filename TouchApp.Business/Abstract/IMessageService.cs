using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface IMessageService
    {
        IDataResult<IEnumerable<Message>> GetList(Expression<Func<Message, bool>> filter = null);
        IDataResult<Message> Get(Expression<Func<Message, bool>> filter);
        IDataResult<int> Add(Message message);
        IDataResult<int> Update(Message message);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<Message> messages);
        IDataResult<int> UpdateList(IEnumerable<Message> messages);
        IDataResult<int> DeletePermanentlyList(IEnumerable<Message> messages);
        IDataResult<int> DeleteByStatusList(IEnumerable<Message> messages);
    }
}
