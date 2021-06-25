using AutoMapper;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class LanguageManager : ILanguageService
    {
        private readonly ILanguageDal _languageDal;
        private readonly IMapper _mapper;

        private readonly IUserLanguageService _userLanguageService;
        private readonly ICategoryLanguageService _categoryLanguageService;
        private readonly IMessageLanguageService _messageLanguageService;
        private readonly IHomeMetaTagLanguageService _homeMetaTagLanguageService;
        private readonly ISectionLanguageService _sectionLanguageService;
        private readonly IFeatureValueLanguageService _featureValueLanguageService;
        private readonly IFeatureLanguageService _featureLanguageService;

        public LanguageManager(ILanguageDal languageDal, IMapper mapper,
                               IUserLanguageService userLanguageService,
                               ICategoryLanguageService categoryLanguageService,
                               IMessageLanguageService messageLanguageService,
                               IHomeMetaTagLanguageService homeMetaTagLanguageService,
                               ISectionLanguageService sectionLanguageService,
                               IFeatureValueLanguageService featureValueLanguageService,
                               IFeatureLanguageService featureLanguageService)
        {
            _languageDal = languageDal;
            _mapper = mapper;
            _userLanguageService = userLanguageService;
            _categoryLanguageService = categoryLanguageService;
            _messageLanguageService = messageLanguageService;
            _homeMetaTagLanguageService = homeMetaTagLanguageService;
            _sectionLanguageService = sectionLanguageService;
            _featureValueLanguageService = featureValueLanguageService;
            _featureLanguageService = featureLanguageService;
        }

        public IDataResult<int> Add(Language language)
        {
            try
            {
                int affectedRows = _languageDal.Add(language);
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

        public IDataResult<IEnumerable<Language>> GetList(Expression<Func<Language, bool>> filter = null)
        {
            try
            {
                var response = _languageDal.GetList(filter);
                var mappingResult = _mapper.Map<IEnumerable<Language>>(response);
                return new SuccessDataResult<IEnumerable<Language>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<IEnumerable<Language>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
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



        public IDataResult<int> AddList(IEnumerable<Language> languages)
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

        public IDataResult<int> UpdateList(IEnumerable<Language> languages)
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

        public IDataResult<int> DeletePermanentlyList(IEnumerable<Language> languages)
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

        public IDataResult<int> DeleteByStatusList(IEnumerable<Language> languages)
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

        private void DeleteAllEntitiesByStatusForAllRelationList(IEnumerable<Language> languages)
        {
            foreach (var language in languages)
            {
                if (language.CategoryLanguages != null)
                {
                    _categoryLanguageService.DeleteByStatusList(language.CategoryLanguages);
                }

                if (language.FameousPersonLanguages != null)
                {
                    _userLanguageService.DeleteByStatusList(language.FameousPersonLanguages);
                }
                if (language.FeatureLanguages != null)
                {
                    _featureLanguageService.DeleteByStatusList(language.FeatureLanguages);
                }

                if (language.FeatureValueLanguages != null)
                {
                    _featureValueLanguageService.DeleteByStatusList(language.FeatureValueLanguages);
                }
                if (language.HomeMetaTagLanguages != null)
                {
                    _homeMetaTagLanguageService.DeleteByStatusList(language.HomeMetaTagLanguages);
                }

                if (language.MessageLanguages != null)
                {
                    _messageLanguageService.DeleteByStatusList(language.MessageLanguages);
                }

                if (language.SectionLanguages != null)
                {
                    _sectionLanguageService.DeleteByStatusList(language.SectionLanguages);
                }
            }
        }

        private void DeleteByStatusForAllRelation(Language language)
        {
            if (language.CategoryLanguages != null)
            {
                _categoryLanguageService.DeleteByStatusList(language.CategoryLanguages);
            }

            if (language.FameousPersonLanguages != null)
            {
                _userLanguageService.DeleteByStatusList(language.FameousPersonLanguages);
            }
            if (language.FeatureLanguages != null)
            {
                _featureLanguageService.DeleteByStatusList(language.FeatureLanguages);
            }

            if (language.FeatureValueLanguages != null)
            {
                _featureValueLanguageService.DeleteByStatusList(language.FeatureValueLanguages);
            }
            if (language.HomeMetaTagLanguages != null)
            {
                _homeMetaTagLanguageService.DeleteByStatusList(language.HomeMetaTagLanguages);
            }

            if (language.MessageLanguages != null)
            {
                _messageLanguageService.DeleteByStatusList(language.MessageLanguages);
            }

            if (language.SectionLanguages != null)
            {
                _sectionLanguageService.DeleteByStatusList(language.SectionLanguages);
            }
        }
    }
}
