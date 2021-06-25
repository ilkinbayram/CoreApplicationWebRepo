using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Resources.Enums;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using System;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IMapper _mapper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IMapper mapper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
        }
        [ValidationAspect(typeof(UserRegisterValidator), Priority = 1)]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password, string securityToken)
        {
            if (userForRegisterDto.IsAgree)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

                var user = new User
                {
                    Email = userForRegisterDto.Email,
                    FirstName = userForRegisterDto.FirstName,
                    LastName = userForRegisterDto.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Birthday = userForRegisterDto.Birthday,
                    SecurityToken = securityToken,
                    IsActive = true,
                    AccountType = AccountType.Client,
                    Created_at = DateTime.Now,
                    Created_by = "Client"
                };

                if (_userService.Add(user).Data > 0)
                {
                    return new SuccessDataResult<User>(user, Messages.UserRegistered);
                }
                return new ErrorDataResult<User>(user, Messages.NotUserRegistered);
            }
            return new ErrorDataResult<User>(Messages.NotUserRegistered);

        }

        [ValidationAspect(typeof(UserRegisterValidator), Priority = 1)]
        public IDataResult<User> RegisterByExistMail(UserForRegisterDto userForRegisterDto, string password, string securityToken)
        {
            if (userForRegisterDto.IsAgree)
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);

                var model = _mapper.Map<UserForRegisterDto, User>(userForRegisterDto);


                var dbModel = _userService.GetUserWithRelations(x => x.Email == userForRegisterDto.Email).Data;

                dbModel.Email = userForRegisterDto.Email;
                dbModel.FirstName = userForRegisterDto.FirstName;
                dbModel.LastName = userForRegisterDto.LastName;
                dbModel.Birthday = userForRegisterDto.Birthday;

                dbModel.AccountType = AccountType.Client;
                dbModel.Created_at = DateTime.Now;
                dbModel.Created_by = "Client";
                dbModel.PasswordHash = passwordHash;
                dbModel.PasswordSalt = passwordSalt;
                dbModel.SecurityToken = securityToken;

                if (_userService.Update(dbModel).Data > 0)
                {
                    return new SuccessDataResult<User>(model, Messages.UserRegistered);
                }
                return new ErrorDataResult<User>(model, Messages.NotUserRegistered);
            }
            return new ErrorDataResult<User>(Messages.NotUserRegistered);
        }

        public IDataResult<User> UpdatePassword(User currentUser, UserPasswordChangeDto passwordChangeDto)
        {

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(passwordChangeDto.Password, out passwordHash, out passwordSalt);

            currentUser.Modified_at = DateTime.Now;
            currentUser.PasswordHash = passwordHash;
            currentUser.PasswordSalt = passwordSalt;
            currentUser.SecurityToken = StringGenerator.GenerateExpirableToken();

            if (_userService.Update(currentUser).Data > 0)
            {
                return new SuccessDataResult<User>(currentUser, Messages.BusinessDataUpdated);
            }
            return new ErrorDataResult<User>(currentUser, Messages.BusinessDataWasNotUpdated);

        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessfulLogin);
        }

        // This method works properly only for Registration
        public IResult UserExists(string email)
        {
            var existUser = _userService.GetByMail(email);
            if (existUser.Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user, bool rememberMe)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data, rememberMe);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IResult UserExistWithExpression(Expression<Func<User, bool>> filter)
        {
            var existUser = _userService.GetByMailWithExpression(filter);
            if (existUser.Data != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
