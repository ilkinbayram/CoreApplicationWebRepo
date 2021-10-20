using AutoMapper;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Entities.Dtos.SharingType;
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
    public class SharingTypeManager : ISharingTypeService
    {
        private readonly ISharingTypeDal _sharingTypeDal;
        private readonly IMapper _mapper;
        private readonly ILocalizationDal _localizationDal;

        public SharingTypeManager(ISharingTypeDal sharingTypeDal, 
                                  IMapper mapper,
                                  ILocalizationDal localizationDal)
        {
            _sharingTypeDal = sharingTypeDal;
            _mapper = mapper;
            _localizationDal = localizationDal;
        }

        public IDataResult<int> Add(CreateManagementSharingTypeDto sharingType)
        {
            try
            {
                var mappedModel = _mapper.Map<SharingType>(sharingType);

                int affectedRows = _sharingTypeDal.Add(mappedModel);

                var localizationList = GeneralFunctionality.ConvertModelToLocalizationList(sharingType);

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

                var deletableEntity = _sharingTypeDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = _sharingTypeDal.DeleteByStatus(deletableEntity);

                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataDeleted);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotDeleted);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> DeletePermanently(long Id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = _sharingTypeDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _sharingTypeDal.DeletePermanently(deletableEntity);
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataDeleted);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotDeleted);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<SharingType> Get(Expression<Func<SharingType, bool>> filter)
        {
            try
            {
                var response = _sharingTypeDal.Get(filter);
                var mappingResult = _mapper.Map<SharingType>(response);
                return new SuccessDataResult<SharingType>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<SharingType>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<GetSharingTypeDto> GetDto(Expression<Func<SharingType, bool>> filter = null)
        {
            try
            {
                var response = _sharingTypeDal.GetWithRelations(filter);
                var mappedModel = _mapper.Map<GetSharingTypeDto>(response);
                return new SuccessDataResult<GetSharingTypeDto>(mappedModel);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetSharingTypeDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<SharingType>> GetList(Expression<Func<SharingType, bool>> filter = null)
        {
            try
            {
                var response = _sharingTypeDal.GetList(filter);
                var mappingResult = _mapper.Map<List<SharingType>>(response);
                return new SuccessDataResult<List<SharingType>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<SharingType>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }
        public IDataResult<List<GetSharingTypeDto>> GetDtoList(Expression<Func<SharingType, bool>> filter = null)
        {
            try
            {
                var dtoListResult = new List<GetSharingTypeDto>();
                _sharingTypeDal.GetAllWithRelations(filter).ToList().ForEach(x =>
                {
                    dtoListResult.Add(_mapper.Map<GetSharingTypeDto>(x));
                });

                return new SuccessDataResult<List<GetSharingTypeDto>>(dtoListResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetSharingTypeDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> Update(SharingType sharingType)
        {
            try
            {
                int affectedRows = _sharingTypeDal.Update(sharingType);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataUpdated);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotUpdated);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }



        public IDataResult<int> AddList(List<SharingType> sharingTypes)
        {
            try
            {
                int affectedRows = _sharingTypeDal.Add(sharingTypes);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> UpdateList(List<SharingType> sharingTypes)
        {
            try
            {
                int affectedRows = _sharingTypeDal.Update(sharingTypes);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> DeletePermanentlyList(List<SharingType> sharingTypes)
        {
            try
            {
                int affectedRows = _sharingTypeDal.DeletePermanently(sharingTypes);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> DeleteByStatusList(List<SharingType> sharingTypes)
        {
            try
            {
                foreach (var sharingType in sharingTypes)
                {
                    sharingType.IsActive = false;
                }

                DeleteAllEntitiesByStatusForAllRelationList(sharingTypes);

                int affectedRows = _sharingTypeDal.DeleteByStatus(sharingTypes);

                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        private void DeleteAllEntitiesByStatusForAllRelationList(List<SharingType> sharingTypes)
        {
            foreach (var sharingType in sharingTypes)
            {
            }
        }

        private void DeleteByStatusForAllRelation(SharingType sharingType)
        {
        }


        #region Asynchronous

        public async Task<IDataResult<int>> AddAsync(SharingType sharingType)
        {
            try
            {
                int affectedRows = await _sharingTypeDal.AddAsync(sharingType);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> DeleteByStatusAsync(long Id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = await _sharingTypeDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = await _sharingTypeDal.DeleteByStatusAsync(deletableEntity);

                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataDeleted);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotDeleted);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> DeletePermanentlyAsync(long Id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = await _sharingTypeDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = await _sharingTypeDal.DeletePermanentlyAsync(deletableEntity);
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataDeleted);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotDeleted);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<SharingType>> GetAsync(Expression<Func<SharingType, bool>> filter)
        {
            try
            {
                var response = await _sharingTypeDal.GetAsync(filter);
                var mappingResult = _mapper.Map<SharingType>(response);
                return new SuccessDataResult<SharingType>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<SharingType>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<SharingType>>> GetListAsync(Expression<Func<SharingType, bool>> filter = null)
        {
            try
            {
                var response = (await _sharingTypeDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<SharingType>>(response);
                return new SuccessDataResult<List<SharingType>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<SharingType>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> UpdateAsync(SharingType sharingType)
        {
            try
            {
                int affectedRows = await _sharingTypeDal.UpdateAsync(sharingType);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataUpdated);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotUpdated);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> AddListAsync(List<SharingType> sharingTypes)
        {
            try
            {
                int affectedRows = await _sharingTypeDal.AddAsync(sharingTypes);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> UpdateListAndSaveAsync(List<SharingType> sharingTypes)
        {
            try
            {
                int affectedRows = await _sharingTypeDal.UpdateAndSaveAsync(sharingTypes);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> DeletePermanentlyListAsync(List<SharingType> sharingTypes)
        {
            try
            {
                int affectedRows = await _sharingTypeDal.DeletePermanentlyAsync(sharingTypes);
                IDataResult<int> dataResult;
                if (affectedRows > 0)
                {
                    dataResult = new SuccessDataResult<int>(affectedRows, Messages.BusinessDataAdded);
                }
                else
                {
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<GetSharingTypeDto>> GetDtoAsync(Expression<Func<SharingType, bool>> filter = null)
        {
            try
            {
                var response = await _sharingTypeDal.GetAsync(filter);
                var mappingResult = _mapper.Map<GetSharingTypeDto>(response);
                return new SuccessDataResult<GetSharingTypeDto>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetSharingTypeDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<GetSharingTypeDto>>> GetDtoListAsync(Expression<Func<SharingType, bool>> filter = null, int takeCount = 2000)
        {
            try
            {
                var response = (await _sharingTypeDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<GetSharingTypeDto>>(response).Take(takeCount).ToList();
                return new SuccessDataResult<List<GetSharingTypeDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetSharingTypeDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        #endregion
    }
}
