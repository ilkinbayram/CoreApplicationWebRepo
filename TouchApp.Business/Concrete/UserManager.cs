using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using Business.Abstract;
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
using DataAccess.Abstract;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;
        private readonly IUserOperationClaimService _userOperationClaimService; //
        private readonly IOrderService _orderService;
        private readonly ICategoryService _categoryService;
        private readonly IRateService _rateService; //
        private readonly IUserLanguageService _userLanguageService;
        private readonly IUserFeatureValueService _userFeatureValueService;
        private readonly ILanguageService _languageService;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IFileManager _fileManager;
        private readonly IMailService _mailService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IUserFeatureValueDal _userFeatureValueDal;


        public UserManager(IUserDal userDal,
                           IMapper mapper,
                           IUserOperationClaimService userOperationClaimService,
                           ICategoryService categoryService,
                           IRateService rateService,
                           IOrderService orderService,
                           IUserLanguageService userLanguageService,
                           IUserFeatureValueService userFeatureValueService,
                           ICloudinaryService cloudinaryService,
                           IMailService mailService,
                           IFileManager fileManager,
                           ILanguageService languageService,
                           IHttpContextAccessor httpContextAccessor,
                           IUserFeatureValueDal userFeatureValueDal)
        {
            _userDal = userDal;
            _mapper = mapper;
            _userOperationClaimService = userOperationClaimService;
            _categoryService = categoryService;
            _orderService = orderService;
            _rateService = rateService;
            _userLanguageService = userLanguageService;
            _userFeatureValueService = userFeatureValueService;
            _cloudinaryService = cloudinaryService;
            _fileManager = fileManager;
            _mailService = mailService;
            _languageService = languageService;
            _httpContext = httpContextAccessor;
            _userFeatureValueDal = userFeatureValueDal;
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
                userModel.AccountType = AccountType.Celebrity;
                userModel.Rate = 0;
                userModel.ProfilePhotoPath = createUserDto.ProfilePhotoPath;
                userModel.IsActive = true;
                userModel.WallpaperPath = createUserDto.WallpaperPath;

                userModel.PreviewMoviePath = createUserDto.PreviewMoviePath;

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

        public IDataResult<IEnumerable<OperationClaim>> GetClaims(User user)
        {
            try
            {
                var response = _userDal.GetClaims(user);
                var mappingResult = _mapper.Map<IEnumerable<OperationClaim>>(response);
                return new SuccessDataResult<IEnumerable<OperationClaim>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<IEnumerable<OperationClaim>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<IEnumerable<User>> GetList(Expression<Func<User, bool>> filter = null)
        {
            try
            {
                var response = _userDal.GetList(filter);
                var mappingResult = _mapper.Map<IEnumerable<User>>(response);
                return new SuccessDataResult<IEnumerable<User>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<IEnumerable<User>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
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

        [TransactionScopeAspect()]
        private bool TransactionalUserRelationsAdd(UserLanguage userLanguage, UserFeatureValue userFeatureValue)
        {
            bool result = false;

            result = _userLanguageService.Add(userLanguage).Data > 0 && _userFeatureValueService.Add(userFeatureValue).Data > 0;

            return result;
        }

        public IDataResult<int> AddList(IEnumerable<User> users)
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

        public IDataResult<int> UpdateList(IEnumerable<User> users)
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

        public IDataResult<int> DeletePermanentlyList(IEnumerable<User> users)
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

        public IDataResult<int> DeleteByStatusList(IEnumerable<User> users)
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

        private void DeleteAllEntitiesByStatusForAllRelationList(IEnumerable<User> users)
        {
            foreach (var user in users)
            {
                if (user.UserRates != null)
                {
                    _rateService.DeleteByStatusList(user.UserRates);
                }

                if (user.FamousRates != null)
                {
                    _rateService.DeleteByStatusList(user.FamousRates);
                }

                if (user.UserOrders != null)
                {
                    _orderService.DeleteByStatusList(user.UserOrders);
                }

                if (user.FamousOrders != null)
                {
                    _orderService.DeleteByStatusList(user.FamousOrders);
                }

                if (user.UserOperationClaims != null)
                {
                    _userOperationClaimService.DeleteByStatusList(user.UserOperationClaims);
                }

                if (user.UserLanguages != null)
                {
                    _userLanguageService.DeleteByStatusList(user.UserLanguages);
                }

                if (user.UserFeatureValues != null)
                {
                    _userFeatureValueService.DeleteByStatusList(user.UserFeatureValues);
                }
            }
        }

        private void DeleteByStatusForAllRelation(User user)
        {
            if (user.UserRates != null)
            {
                _rateService.DeleteByStatusList(user.UserRates);
            }

            if (user.FamousRates != null)
            {
                _rateService.DeleteByStatusList(user.FamousRates);
            }

            if (user.UserOrders != null)
            {
                _orderService.DeleteByStatusList(user.UserOrders);
            }

            if (user.FamousOrders != null)
            {
                _orderService.DeleteByStatusList(user.FamousOrders);
            }

            if (user.UserOperationClaims != null)
            {
                _userOperationClaimService.DeleteByStatusList(user.UserOperationClaims);
            }

            if (user.UserLanguages != null)
            {
                _userLanguageService.DeleteByStatusList(user.UserLanguages);
            }

            if (user.UserFeatureValues != null)
            {
                _userFeatureValueService.DeleteByStatusList(user.UserFeatureValues);
            }
        }

        [ValidationAspect(typeof(UpdateUserDtoValidator), Priority = 1)]
        public IDataResult<int> UpdateUserByAdmin(UpdateUserDto updateUserDto)
        {
            try
            {
                var activeUserName = _httpContext.HttpContext.User.GetFullName();
                User user = _userDal.UserGetById(updateUserDto.Id);
                user.Modified_at = DateTime.Now;
                user.Modified_by = activeUserName;
                user.Gender = updateUserDto.Gender;
                user.FirstName = updateUserDto.FirstName;
                user.LastName = updateUserDto.LastName;
                user.UnitPrice = updateUserDto.UnitPrice;
                user.Biography = user.Biography;
                user.Birthday = updateUserDto.Birthday;
                user.PhoneNumber = updateUserDto.PhoneNumber;
                user.PhoneNumberPrefix = updateUserDto.PhoneNumberPrefix;
                user.ShowInHomePage = updateUserDto.ShowInHomePage;
                user.CategoryId = updateUserDto.CategoryId;
                
                if (updateUserDto.ProfilePhotoPath != null && user.ProfilePhotoPath == null)
                {
                    user.ProfilePhotoPath = updateUserDto.ProfilePhotoPath;
                }
                else if (updateUserDto.ProfilePhotoPath != null && user.ProfilePhotoPath != null)
                {
                    _cloudinaryService.Delete(user.ProfilePhotoPath);
                    user.ProfilePhotoPath = updateUserDto.ProfilePhotoPath;
                }
                if (updateUserDto.WallpaperPath != null && user.WallpaperPath == null)
                {
                        
                        user.WallpaperPath = updateUserDto.WallpaperPath;
                }
                else if (updateUserDto.WallpaperPath != null && user.WallpaperPath != null)
                 {
                        _cloudinaryService.Delete(user.WallpaperPath);
                    
                        user.WallpaperPath = updateUserDto.WallpaperPath;
                 }
                if (updateUserDto.PreviewMoviePath != null && user.PreviewMoviePath == null)
                {
                        
                        user.ProfilePhotoPath = updateUserDto.PreviewMoviePath;
                }
                else if (updateUserDto.PreviewMoviePath != null && user.PreviewMoviePath != null)
                {
                        _cloudinaryService.Delete(user.PreviewMoviePath);
                       
                        user.PreviewMoviePath = updateUserDto.PreviewMoviePath;
                }

                foreach (var userLang in updateUserDto.UserLanguages)
                {

                    var userlang = user.UserLanguages.FirstOrDefault(x => x.Id == userLang.Id && x.LanguageId == userLang.LanguageId);
                    if (userlang != null)
                    {
                        userlang.Description = userLang.Description;
                        userlang.LanguageId = userLang.LanguageId;
                        userlang.Slug = userLang.Slug;

                    }
                }
                var dbuserfeturevalue = user.UserFeatureValues.ToList();

                foreach (var userfeaturevalue in updateUserDto.UserFeatureValues)
                {
                    if (dbuserfeturevalue.Any(x=>x.Id == userfeaturevalue.Id))
                    {
                        var featureValue = user.UserFeatureValues.FirstOrDefault(x => x.Id == userfeaturevalue.Id);
                        featureValue.FeatureValueId = userfeaturevalue.FeatureValueId ;
                        featureValue.CategoryFeatureId = userfeaturevalue.CategoryFeatureId;
                        dbuserfeturevalue.Remove(user.UserFeatureValues.FirstOrDefault(x => x.Id == userfeaturevalue.Id));
                    }
                    else
                    {

                        var userfeturemappermapper = new UserFeatureValue
                        {
                            IsActive = true,
                            FeatureValueId = userfeaturevalue.FeatureValueId,
                            CategoryFeatureId = userfeaturevalue.CategoryFeatureId,
                            UserId = user.Id
                        };
                        _userFeatureValueDal.AddUserFeature(userfeturemappermapper);
                    }
                }

                _userFeatureValueDal.RemoveRange(dbuserfeturevalue);

                int affectedRows = _userDal.Commit();
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

        public IDataResult<UserGetByIdDto> GetUserById(long userId)
        {
            try
            {
                var response = _userDal.UserGetById(userId);
                var mappingresult = _mapper.Map<UserGetByIdDto>(response);
                mappingresult.ProfilePhotoPathCloudinaryUrl = _cloudinaryService.BuildUrl(response.ProfilePhotoPath);
                mappingresult.WallpaperPathCloudinaryUrl = _cloudinaryService.BuildUrl(response.WallpaperPath);
                mappingresult.PreviewMoviePathCloudinaryUrl = _cloudinaryService.BuildUrlVideo(response.PreviewMoviePath);

                return new SuccessDataResult<UserGetByIdDto>(mappingresult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<UserGetByIdDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<IEnumerable<GetFamousOfferFeatureDto>> GetUserOfferFeatures(long famousPersonId, string acceptedLang)

        {
            IDataResult<IEnumerable<GetFamousOfferFeatureDto>> dataResult;
            var langID = _languageService.Get(x => x.LanguageName == acceptedLang).Data.Id;
            try
            {
                var user = _userDal.GetUserForOrderWithRelations(x=>x.Id==famousPersonId & x.IsActive == true);
                var features = user.UserFeatureValues.Select(x=>x.FeatureValue.Feature).GroupBy(g => g.Id).Select(s => s.First()).ToList();

                //foreach (var feature in features)
                //{
                //    feature.FeatureLanguages = feature.FeatureLanguages.Where(f => f.LanguageId == langID).ToList();
                //    foreach (var featureValue in feature.FeatureValues)
                //        featureValue.FeatureValueLanguages = featureValue.FeatureValueLanguages.Where(f => f.LanguageId == langID).ToList();
                //}
                var c = features.Where(z=>z.OfferFeature).Select(x => new GetFamousOfferFeatureDto
                {
                    FeatureName = x.FeatureLanguages.FirstOrDefault(z => z.LanguageId == langID).FeatureName,
                    FeatureValues = x.FeatureValues.Select(b => new GetFamousOfferFeatureValueDto
                    {
                        Id=b.Id,
                        FeatureValueName = b.FeatureValueLanguages.FirstOrDefault(n => n.LanguageId == langID).FeatureValueName
                    })
                });

                //var result = _mapper.Map<IEnumerable<GetFamousOfferFeatureDto>>(features);
                return new SuccessDataResult<IEnumerable<GetFamousOfferFeatureDto>>(c);

            }
            catch (Exception exception)
            {
                dataResult = new ErrorDataResult<IEnumerable<GetFamousOfferFeatureDto>>($"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");

                return dataResult;
            }
        }

        public IDataResult<UserLangDto> GetUserBySlug(string userSlug, string lang)
        {
           
                try
                {
                    var response = _userDal.GetUserBySlug(userSlug,lang);
                    var mappingresult = _mapper.Map<UserLangDto>(response);
                    mappingresult.User.ProfilePhotoPathCloudinaryUrl = _cloudinaryService.BuildUrl(response.User.ProfilePhotoPath);
                    mappingresult.User.WallpaperPathCloudinaryUrl = _cloudinaryService.BuildUrl(response.User.WallpaperPath);
                    mappingresult.User.PreviewMoviePathCloudinaryUrl = _cloudinaryService.BuildUrlVideo(response.User.PreviewMoviePath);

                    return new SuccessDataResult<UserLangDto>(mappingresult);
                }
                catch (Exception exception)
                {
                    return new ErrorDataResult<UserLangDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
                }
            }

        
    }
}
