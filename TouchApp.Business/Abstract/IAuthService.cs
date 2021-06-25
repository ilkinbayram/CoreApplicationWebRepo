using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto,string password, string securityToken);
        IDataResult<User> RegisterByExistMail(UserForRegisterDto userForRegisterDto,string password, string securityToken);
        IDataResult<User> UpdatePassword(User currentUser, UserPasswordChangeDto passwordChangeDto);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IResult UserExistWithExpression(Expression<Func<User, bool>> filter);
        IDataResult<AccessToken> CreateAccessToken(User user,bool rememberMe);
    }
}
