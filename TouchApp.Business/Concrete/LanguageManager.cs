using AutoMapper;
using Business.Constants;
using Business.Libs;
using Core.Aspects.Autofac.Transaction;
using Core.Entities.Concrete;
using Core.Entities.Dtos.FieUploud;
using Core.Entities.Dtos.Language;
using Core.Resources.Enums;
using Core.Utilities.Results;
using Core.Utilities.Services.Rest;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;
using TouchApp.Business.BusinessHelper;
using TouchApp.DataAccess.Abstract;

namespace Business.Concrete
{
    public class LanguageManager : ILanguageService
    {
        private readonly ILanguageDal _languageDal;
        private readonly IMapper _mapper;

        private IFileManager _fileManager;
        private ICloudinaryService _cloudinaryService;
        private ILocalizationDal _localizationDal;

        public LanguageManager(ILanguageDal languageDal,
                               IMapper mapper,
                               IFileManager fileManager,
                               ICloudinaryService cloudinaryService,
                               ILocalizationDal localizationDal)
        {
            _languageDal = languageDal;
            _mapper = mapper;
            _fileManager = fileManager;
            _cloudinaryService = cloudinaryService;
            _localizationDal = localizationDal;
        }

        [TransactionScopeAspect(Priority = 1)]
        public IDataResult<int> Add(CreateManagementLanguageDto language)
        {
            try
            {
                var langOid = Convert.ToInt16(language.NameAbr);
                var langAbriveature = Enum.GetName(typeof(LanguageOidContainerEnum), langOid);
                language.NameAbr = langAbriveature;
                language.Language_oid = langOid;

                var listFileListAdded = new List<string>();

                var fileUploadResult = _fileManager.UploadThumbnail(language.FlagIconFile);

                if (!fileUploadResult.Success)
                    return new ErrorDataResult<int>(-1, fileUploadResult.Message);

                var publicId = _cloudinaryService.StoreImage(fileUploadResult.Data["thumbnailPath"]);

                var result = new FileName()
                {
                    FilePath = fileUploadResult.Data["thumbnailPath"],
                    CdnPath = _cloudinaryService.BuildUrl(publicId),
                    PublicId = publicId
                };

                _fileManager.Delete(fileUploadResult.Data["imagePath"]);
                _fileManager.Delete(fileUploadResult.Data["thumbnailPath"]);

                listFileListAdded.Add(publicId);

                language.FlagIconSource = result.CdnPath;

                var addLangModel = _mapper.Map<Language>(language);

                int affectedRows = _languageDal.Add(addLangModel);

                var localizationList = GeneralFunctionality.ConvertModelToLocalizationList(language);

                foreach (var localizationOne in localizationList)
                {
                    var responseAddLocalization = _localizationDal.Add(localizationOne);
                    if (responseAddLocalization <= 0)
                        throw new Exception(Messages.ErrorMessages.NOT_ADDED_AND_ROLLED_BACK);
                }

                if (affectedRows <= 0)
                    throw new Exception(Messages.ErrorMessages.NOT_ADDED_AND_ROLLED_BACK);

                return new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-500, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> DeleteByStatus(long Id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = _languageDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = _languageDal.DeleteByStatus(deletableEntity);

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

                var deletableEntity = _languageDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _languageDal.DeletePermanently(deletableEntity);
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

        public IDataResult<Language> Get(Expression<Func<Language, bool>> filter)
        {
            try
            {
                var response = _languageDal.Get(filter);
                var mappingResult = _mapper.Map<Language>(response);
                return new SuccessDataResult<Language>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<Language>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<GetLanguageDto> GetDto(Expression<Func<Language, bool>> filter = null)
        {
            try
            {
                var response = _languageDal.Get(filter);
                var mappedModel = _mapper.Map<GetLanguageDto>(response);
                return new SuccessDataResult<GetLanguageDto>(mappedModel);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetLanguageDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<Language>> GetList(Expression<Func<Language, bool>> filter = null)
        {
            try
            {
                var response = _languageDal.GetList(filter);
                var mappingResult = _mapper.Map<List<Language>>(response);
                return new SuccessDataResult<List<Language>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<Language>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> Update(Language language)
        {
            try
            {
                int affectedRows = _languageDal.Update(language);
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



        public IDataResult<int> AddList(List<Language> languages)
        {
            try
            {
                int affectedRows = _languageDal.Add(languages);
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

        public IDataResult<int> UpdateList(List<Language> languages)
        {
            try
            {
                int affectedRows = _languageDal.Update(languages);
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

        public IDataResult<int> DeletePermanentlyList(List<Language> languages)
        {
            try
            {
                int affectedRows = _languageDal.DeletePermanently(languages);
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

        public IDataResult<int> DeleteByStatusList(List<Language> languages)
        {
            try
            {
                foreach (var language in languages)
                {
                    language.IsActive = false;
                }

                DeleteAllEntitiesByStatusForAllRelationList(languages);

                int affectedRows = _languageDal.DeleteByStatus(languages);

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

        private void DeleteAllEntitiesByStatusForAllRelationList(List<Language> languages)
        {
            foreach (var language in languages)
            {
            }
        }

        private void DeleteByStatusForAllRelation(Language language)
        {
        }


        #region Asynchronous

        [TransactionScopeAspectAsync(Priority = 1)]
        public async Task<IDataResult<int>> AddAsync(CreateManagementLanguageDto language)
        {
            var listFileListAdded = new List<string>();
            //try
            //{
            var fileUploadResult = _fileManager.UploadThumbnail(language.FlagIconFile);

            if (!fileUploadResult.Success)
            {
                return new ErrorDataResult<int>(-1, fileUploadResult.Message);
            }

            var publicId = _cloudinaryService.StoreImage(fileUploadResult.Data["thumbnailPath"]);

            var result = new FileName()
            {
                FilePath = fileUploadResult.Data["thumbnailPath"],
                CdnPath = _cloudinaryService.BuildUrl(publicId),
                PublicId = publicId
            };

            _fileManager.Delete(fileUploadResult.Data["imagePath"]);
            _fileManager.Delete(fileUploadResult.Data["thumbnailPath"]);

            listFileListAdded.Add(publicId);

            language.FlagIconSource = result.CdnPath;

            var addLangModel = _mapper.Map<Language>(language);

            int affectedRows = await _languageDal.AddAsync(addLangModel);

            var localizationList = GeneralFunctionality.ConvertModelToLocalizationList(language);

            foreach (var localizationOne in localizationList)
            {
                var responseAddLocalization = await _localizationDal.AddAsync(localizationOne);
                if (responseAddLocalization <= 0)
                    throw new Exception(Messages.ErrorMessages.NOT_ADDED_AND_ROLLED_BACK);
            }

            throw new Exception(Messages.ErrorMessages.NOT_ADDED_AND_ROLLED_BACK);


            if (affectedRows <= 0)
                throw new Exception(Messages.ErrorMessages.NOT_ADDED_AND_ROLLED_BACK);

            return new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
            //}
            //catch (Exception exception)
            //{
            //    listFileListAdded.ForEach(x =>
            //    {
            //        _cloudinaryService.Delete(x);
            //    });

            //    return new ErrorDataResult<int>(-1, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            //}
        }

        public async Task<IDataResult<int>> DeleteByStatusAsync(long Id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = await _languageDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = await _languageDal.DeleteByStatusAsync(deletableEntity);

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

        public async Task<IDataResult<int>> DeletePermanentlyAsync(long Id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = await _languageDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = await _languageDal.DeletePermanentlyAsync(deletableEntity);
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

        public async Task<IDataResult<Language>> GetAsync(Expression<Func<Language, bool>> filter)
        {
            try
            {
                var response = await _languageDal.GetAsync(filter);
                var mappingResult = _mapper.Map<Language>(response);
                return new SuccessDataResult<Language>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<Language>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<Language>>> GetListAsync(Expression<Func<Language, bool>> filter = null)
        {
            try
            {
                var response = (await _languageDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<Language>>(response);
                return new SuccessDataResult<List<Language>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<Language>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> UpdateAsync(Language language)
        {
            try
            {
                int affectedRows = await _languageDal.UpdateAsync(language);
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

        public async Task<IDataResult<int>> AddListAsync(List<Language> languages)
        {
            try
            {
                int affectedRows = await _languageDal.AddAsync(languages);
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

        public async Task<IDataResult<int>> UpdateListAndSaveAsync(List<Language> languages)
        {
            try
            {
                int affectedRows = await _languageDal.UpdateAndSaveAsync(languages);
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

        public async Task<IDataResult<int>> DeletePermanentlyListAsync(List<Language> languages)
        {
            try
            {
                int affectedRows = await _languageDal.DeletePermanentlyAsync(languages);
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

        //public async Task<IDataResult<GetLanguageDto>> GetDtoAsync(Expression<Func<Language, bool>> filter = null)
        //{
        //    try
        //    {
        //        var response = await _languageDal.GetAsync(filter);
        //        var mappingResult = _mapper.Map<GetLanguageDto>(response);
        //        return new SuccessDataResult<GetLanguageDto>(mappingResult);
        //    }
        //    catch (Exception exception)
        //    {
        //        return new ErrorDataResult<GetLanguageDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
        //    }
        //}

        //public async Task<IDataResult<List<GetLanguageDto>>> GetDtoListAsync(Expression<Func<Language, bool>> filter = null, int takeCount = 2000)
        //{
        //    try
        //    {
        //        var response = (await _languageDal.GetAllAsync(filter)).ToList();
        //        var mappingResult = _mapper.Map<List<GetLanguageDto>>(response).Take(takeCount).ToList();
        //        return new SuccessDataResult<List<GetLanguageDto>>(mappingResult);
        //    }
        //    catch (Exception exception)
        //    {
        //        return new ErrorDataResult<List<GetLanguageDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
        //    }
        //}

        #endregion
    }
}
