using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using TouchApp.Business.Abstract;
using Business.Constants;
using Business.ExternalServices.Mail;
using Business.ExternalServices.Mail.Services.Abstract;
using Business.Libs;
using Business.ValidationRules.FluentValidation.User;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Entities;
using Core.Entities.Concrete;
using Core.Entities.Dtos.User;
using Core.Extensions;
using Core.Resources.Enums;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Services.Rest;
using TouchApp.DataAccess.Abstract;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;
        private readonly IUserOperationClaimService _userOperationClaimService; //
        private readonly ICategoryService _categoryService;
        private readonly ILanguageService _languageService;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IFileManager _fileManager;
        private readonly IMailService _mailService;
        private readonly IHttpContextAccessor _httpContext;

        public UserManager(IUserDal userDal,
                           IMapper mapper,
                           IUserOperationClaimService userOperationClaimService,
                           ICategoryService categoryService,
                           ICloudinaryService cloudinaryService,
                           IMailService mailService,
                           IFileManager fileManager,
                           ILanguageService languageService,
                           IHttpContextAccessor httpContextAccessor)
        {
            _userDal = userDal;
            _mapper = mapper;
            _userOperationClaimService = userOperationClaimService;
            _categoryService = categoryService;
            _cloudinaryService = cloudinaryService;
            _fileManager = fileManager;
            _mailService = mailService;
            _languageService = languageService;
            _httpContext = httpContextAccessor;
        }

        public IDataResult<int> Add(User user)
        {
            try
            {
                user.Created_at = DateTime.Now;
                user.Modified_at = DateTime.Now;

                int affectedRows = _userDal.Add(user);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        [TransactionScopeAspect()]
        [ValidationAspect(typeof(CreateUserValidator), Priority = 1)]
        public IDataResult<int> CreateUserByAdmin(CreateUserDto createUserDto)
        {
            try
            {
                IDataResult<int> dataResult;
                var activeUserName = _httpContext.HttpContext.User.GetFullName();

                var securityToken = StringGenerator.GenerateToken();
                string pas = CreatePassword(6);
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(pas, out passwordHash, out passwordSalt);

                var userModel = _mapper.Map<CreateUserDto, User>(createUserDto);
                userModel.Created_at = DateTime.Now;
                userModel.Modified_at = DateTime.Now;
                userModel.Created_by = _httpContext.HttpContext.User.GetFirstName();
                userModel.Modified_by = _httpContext.HttpContext.User.GetFirstName();
                userModel.PasswordHash = passwordHash;
                userModel.PasswordSalt = passwordSalt;
                userModel.SecurityToken = securityToken;
                userModel.ProfilePhotoPath = createUserDto.ProfilePhotoPath;
                userModel.IsActive = true;
                userModel.WallpaperPath = createUserDto.WallpaperPath;

                int affectedRows = _userDal.Add(userModel);

                var addedUser = _userDal.Get(x => x.SecurityToken == securityToken);

                if (affectedRows > 0 && addedUser != null)
                {
                    MailRequest mailRequest = new MailRequest
                    {
                        Body = string.Format(Messages.AdminCreatedUserMailMessage, pas),
                        ToEmail = createUserDto.Email,
                        Subject = MailUtilityHelper.GetMailSubject(MailSubjectStatus.AccountCreatedByAdmin)
                    };

                    var isMailSent = _mailService.SendMail(mailRequest);

                    if (!isMailSent)
                    {
                        dataResult = new ErrorDataResult<int>(-1, Messages.NotSentEmailPassword);
                    }

                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }
        private string CreatePassword(int length) // random string code generate
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
        public IDataResult<int> DeleteByStatus(long Id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = _userDal.GetUserWithRelations(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = _userDal.DeleteByStatus(deletableEntity);

                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataDeleted);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, Messages.BusinessDataWasNotDeleted);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> DeletePermanently(long Id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = _userDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _userDal.DeletePermanently(deletableEntity);
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataDeleted);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, Messages.BusinessDataWasNotDeleted);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<User> Get(Expression<Func<User, bool>> filter)
        {
            try
            {
                var response = _userDal.Get(filter);
                return new SuccessDataResult<User>(response);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<User>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<User> GetUserWithRelations(Expression<Func<User, bool>> filter)
        {
            try
            {
                var response = _userDal.GetUserWithRelations(filter);
                return new SuccessDataResult<User>(response);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<User>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<User> GetByMail(string email)
        {
            try
            {
                var response = _userDal.Get(x => x.Email == email);
                return new SuccessDataResult<User>(response);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<User>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<User> GetByMailWithExpression(Expression<Func<User, bool>> filter)
        {
            try
            {
                var response = _userDal.Get(filter);
                return new SuccessDataResult<User>(response);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<User>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            try
            {
                var response = _userDal.GetClaims(user);
                var mappingResult = _mapper.Map<List<OperationClaim>>(response);
                return new SuccessDataResult<List<OperationClaim>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<OperationClaim>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<User>> GetList(Expression<Func<User, bool>> filter = null)
        {
            try
            {
                var response = _userDal.GetList(filter);
                var mappingResult = _mapper.Map<List<User>>(response);
                return new SuccessDataResult<List<User>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<User>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> Update(User user)
        {
            try
            {
                var userDbModel = _userDal.GetUserWithRelations(x => x.Email == user.Email);
                int affectedRows = _userDal.Update(user);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataUpdated);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, Messages.BusinessDataWasNotUpdated);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> AddList(List<User> users)
        {
            try
            {
                int affectedRows = _userDal.Add(users);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> UpdateList(List<User> users)
        {
            try
            {
                int affectedRows = _userDal.Update(users);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> DeletePermanentlyList(List<User> users)
        {
            try
            {
                int affectedRows = _userDal.DeletePermanently(users);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> DeleteByStatusList(List<User> users)
        {
            try
            {
                foreach (var user in users)
                {
                    user.IsActive = false;
                }

                DeleteAllEntitiesByStatusForAllRelationList(users);

                int affectedRows = _userDal.DeleteByStatus(users);

                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        private void DeleteAllEntitiesByStatusForAllRelationList(List<User> users)
        {
            foreach (var user in users)
            {
                
            }
        }

        private void DeleteByStatusForAllRelation(User user)
        {
            
        }

        [ValidationAspect(typeof(UpdateUserDtoValidator), Priority = 1)]
        public IDataResult<int> UpdateUserByAdmin(UpdateUserDto updateUserDto)
        {
            return null;
        }

        public IDataResult<UserGetByIdDto> GetUserById(long userId)
        {
            return null;
        }

        public IDataResult<List<GetFamousOfferFeatureDto>> GetUserOfferFeatures(long famousPersonId, string acceptedLang)

        {
            return null;
        }

        public IDataResult<UserLangDto> GetUserBySlug(string userSlug, string lang)
        {
           
                try
                {
                    return new SuccessDataResult<UserLangDto>();
                }
                catch (Exception exception)
                {
                    return new ErrorDataResult<UserLangDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
                }
            }

        
    }
}
