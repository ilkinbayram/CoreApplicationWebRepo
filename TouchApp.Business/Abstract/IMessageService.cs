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
        IDataResult<List<Message>> GetList(Expression<Func<Message, bool>> filter = null);
        IDataResult<Message> Get(Expression<Func<Message, bool>> filter);
        IDataResult<int> Add(Message message);
        IDataResult<int> Update(Message message);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<Message> messages);
        IDataResult<int> UpdateList(List<Message> messages);
        IDataResult<int> DeletePermanentlyList(List<Message> messages);
        IDataResult<int> DeleteByStatusList(List<Message> messages);
    }
}
