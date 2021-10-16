using Core.Entities.Concrete;
using Core.Entities.Dtos.User;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);

        IDataResult<List<User>> GetList(Expression<Func<User, bool>> filter = null);
        IDataResult<User> Get(Expression<Func<User, bool>> filter);
        IDataResult<GetUserDto> GetDto(Expression<Func<User, bool>> filter = null);
        IDataResult<int> Add(User user);
        IDataResult<int> CreateUserByAdmin(CreateManagementUserDto createUserDto);
        IDataResult<int> Update(User user);
        IDataResult<int> UpdateUserByAdmin(UpdateUserDto updateUserDto);

        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<User> users);
        IDataResult<int> UpdateList(List<User> users);
        IDataResult<int> DeletePermanentlyList(List<User> users);
        IDataResult<int> DeleteByStatusList(List<User> users);
        IDataResult<UserGetByIdDto> GetUserById(long userId);
        IDataResult<User> GetByMailWithExpression(Expression<Func<User, bool>> filter);
        IDataResult<User> GetUserWithRelations(Expression<Func<User, bool>> filter);


        Task<IDataResult<List<GetUserDto>>> GetDtoListAsync(Expression<Func<User, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetUserDto>> GetDtoAsync(Expression<Func<User, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<User> users);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<User> users);
        Task<IDataResult<List<User>>> GetListAsync(Expression<Func<User, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<User> users);
        Task<IDataResult<int>> UpdateAsync(User user);
        Task<IDataResult<User>> GetAsync(Expression<Func<User, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(User user);
    }
}
