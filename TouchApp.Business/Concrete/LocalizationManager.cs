using AutoMapper;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Entities.Concrete;
using Core.Entities.Dtos.Localization;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;
using TouchApp.Business.BusinessHelper;
using TouchApp.DataAccess.Abstract;

namespace Business.Concrete
{
    public class LocalizationManager : ILocalizationService
    {
        private readonly ILocalizationDal _localizationDal;
        private readonly IMapper _mapper;

        public LocalizationManager(ILocalizationDal localizationDal, IMapper mapper)
        {
            _localizationDal = localizationDal;
            _mapper = mapper;
        }

        [TransactionScopeAspect(Priority = 1)]
        public IDataResult<int> Add(CreateLocalizationDto localization)
        {
            int counterResult = 0;
            var localizationList = GeneralFunctionality.ConverModelToLocalizationList(localization);

            foreach (var localizationOne in localizationList)
            {
                var responseAddLocalization = _localizationDal.Add(localizationOne);
                counterResult += responseAddLocalization;
                if (responseAddLocalization <= 0)
                    throw new Exception(Messages.ErrorMessages.NOT_ADDED_AND_ROLLED_BACK);
            }

            return new SuccessDataResult<int>(counterResult, Messages.BusinessDataAdded);
        }

        public IDataResult<int> DeleteByStatus(long Id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = _localizationDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = _localizationDal.DeleteByStatus(deletableEntity);

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

                var deletableEntity = _localizationDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _localizationDal.DeletePermanently(deletableEntity);
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

        public IDataResult<Localization> Get(Expression<Func<Localization, bool>> filter)
        {
            try
            {
                var response = _localizationDal.Get(filter);
                var mappingResult = _mapper.Map<Localization>(response);
                return new SuccessDataResult<Localization>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<Localization>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<Localization>> GetList(Expression<Func<Localization, bool>> filter = null)
        {
            try
            {
                var response = _localizationDal.GetList(filter);
                var mappingResult = _mapper.Map<List<Localization>>(response);
                return new SuccessDataResult<List<Localization>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<Localization>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> Update(Localization localization)
        {
            try
            {
                int affectedRows = _localizationDal.Update(localization);
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



        public IDataResult<int> AddList(List<Localization> localizations)
        {
            try
            {
                int affectedRows = _localizationDal.Add(localizations);
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

        public IDataResult<int> UpdateList(List<Localization> localizations)
        {
            try
            {
                int affectedRows = _localizationDal.Update(localizations);
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

        public IDataResult<int> DeletePermanentlyList(List<Localization> localizations)
        {
            try
            {
                int affectedRows = _localizationDal.DeletePermanently(localizations);
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

        public IDataResult<int> DeleteByStatusList(List<Localization> localizations)
        {
            try
            {
                foreach (var localization in localizations)
                {
                    localization.IsActive = false;
                }

                DeleteAllEntitiesByStatusForAllRelationList(localizations);

                int affectedRows = _localizationDal.DeleteByStatus(localizations);

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

        private void DeleteAllEntitiesByStatusForAllRelationList(List<Localization> localizations)
        {
            foreach (var localization in localizations)
            {
            }
        }

        private void DeleteByStatusForAllRelation(Localization localization)
        {
        }


        #region Asynchronous

        public async Task<IDataResult<int>> AddDtoAsync(CreateLocalizationDto localization)
        {
            try
            {
                var addLocalizeModel = _mapper.Map<Localization>(localization);
                int affectedRows = await _localizationDal.AddAsync(addLocalizeModel);
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

        public async Task<IDataResult<int>> AddModelAsync(Localization localization)
        {
            try
            {
                int affectedRows = await _localizationDal.AddAsync(localization);
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

        public async Task<IDataResult<int>> DeleteByStatusAsync(long Id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = await _localizationDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = await _localizationDal.DeleteByStatusAsync(deletableEntity);

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

                var deletableEntity = await _localizationDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = await _localizationDal.DeletePermanentlyAsync(deletableEntity);
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

        public async Task<IDataResult<Localization>> GetAsync(Expression<Func<Localization, bool>> filter)
        {
            try
            {
                var response = await _localizationDal.GetAsync(filter);
                var mappingResult = _mapper.Map<Localization>(response);
                return new SuccessDataResult<Localization>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<Localization>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<Localization>>> GetListAsync(Expression<Func<Localization, bool>> filter = null)
        {
            try
            {
                var response = (await _localizationDal.GetAllAsQueryableAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<Localization>>(response);
                return new SuccessDataResult<List<Localization>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<Localization>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> UpdateAsync(Localization localization)
        {
            try
            {
                int affectedRows = await _localizationDal.UpdateAsync(localization);
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

        public async Task<IDataResult<int>> AddListAsync(List<Localization> localizations)
        {
            try
            {
                int affectedRows = await _localizationDal.AddAsync(localizations);
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

        public async Task<IDataResult<int>> UpdateListAndSaveAsync(List<Localization> localizations)
        {
            try
            {
                int affectedRows = await _localizationDal.UpdateAndSaveAsync(localizations);
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

        public async Task<IDataResult<int>> DeletePermanentlyListAsync(List<Localization> localizations)
        {
            try
            {
                int affectedRows = await _localizationDal.DeletePermanentlyAsync(localizations);
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

        //public async Task<IDataResult<GetLocalizationDto>> GetDtoAsync(Expression<Func<Localization, bool>> filter = null)
        //{
        //    try
        //    {
        //        var response = await _localizationDal.GetAsync(filter);
        //        var mappingResult = _mapper.Map<GetLocalizationDto>(response);
        //        return new SuccessDataResult<GetLocalizationDto>(mappingResult);
        //    }
        //    catch (Exception exception)
        //    {
        //        return new ErrorDataResult<GetLocalizationDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
        //    }
        //}

        //public async Task<IDataResult<List<GetLocalizationDto>>> GetDtoListAsync(Expression<Func<Localization, bool>> filter = null, int takeCount = 2000)
        //{
        //    try
        //    {
        //        var response = (await _localizationDal.GetAllAsQueryableAsync(filter)).ToList();
        //        var mappingResult = _mapper.Map<List<GetLocalizationDto>>(response).Take(takeCount).ToList();
        //        return new SuccessDataResult<List<GetLocalizationDto>>(mappingResult);
        //    }
        //    catch (Exception exception)
        //    {
        //        return new ErrorDataResult<List<GetLocalizationDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
        //    }
        //}

        #endregion
    }
}
