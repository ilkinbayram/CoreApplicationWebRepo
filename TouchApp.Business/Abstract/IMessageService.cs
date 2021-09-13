using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

        //Task<IDataResult<List<GetMessageDto>>> GetDtoListAsync(Expression<Func<Message, bool>> filter = null, int takeCount = 2000);
        //Task<IDataResult<GetMessageDto>> GetDtoAsync(Expression<Func<Message, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<Message> messages);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<Message> messages);
        Task<IDataResult<List<Message>>> GetListAsync(Expression<Func<Message, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<Message> messages);
        Task<IDataResult<int>> UpdateAsync(Message message);
        Task<IDataResult<Message>> GetAsync(Expression<Func<Message, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(Message message);
    }
}
