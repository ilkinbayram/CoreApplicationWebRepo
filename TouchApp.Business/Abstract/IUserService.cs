using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities.Concrete;
using Core.Entities.Dtos.User;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<IEnumerable<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);

        IDataResult<IEnumerable<User>> GetList(Expression<Func<User, bool>> filter = null);
        IDataResult<User> Get(Expression<Func<User, bool>> filter);
        IDataResult<int> Add(User user);
        IDataResult<int> CreateUserByAdmin(CreateUserDto createUserDto);
        IDataResult<int> Update(User user);
        IDataResult<int> UpdateUserByAdmin(UpdateUserDto updateUserDto);

        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<User> users);
        IDataResult<int> UpdateList(IEnumerable<User> users);
        IDataResult<int> DeletePermanentlyList(IEnumerable<User> users);
        IDataResult<int> DeleteByStatusList(IEnumerable<User> users);
        IDataResult<UserGetByIdDto> GetUserById(long userId);
        IDataResult<User> GetByMailWithExpression(Expression<Func<User, bool>> filter);
        IDataResult<User> GetUserWithRelations(Expression<Func<User, bool>> filter);
        IDataResult<IEnumerable<GetFamousOfferFeatureDto>> GetUserOfferFeatures(long famousPersonId, string acceptedLang);

        IDataResult<UserLangDto> GetUserBySlug(string userSlug , string lang);
    }
}
