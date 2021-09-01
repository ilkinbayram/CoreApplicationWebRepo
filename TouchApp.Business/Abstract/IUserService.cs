using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Core.Entities.Concrete;
using Core.Entities.Dtos.User;
using Core.Utilities.Results;

namespace TouchApp.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IDataResult<User> GetByMail(string email);

        IDataResult<List<User>> GetList(Expression<Func<User, bool>> filter = null);
        IDataResult<User> Get(Expression<Func<User, bool>> filter);
        IDataResult<int> Add(User user);
        IDataResult<int> CreateUserByAdmin(CreateUserDto createUserDto);
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
        IDataResult<List<GetFamousOfferFeatureDto>> GetUserOfferFeatures(long famousPersonId, string acceptedLang);

        IDataResult<UserLangDto> GetUserBySlug(string userSlug , string lang);
    }
}
