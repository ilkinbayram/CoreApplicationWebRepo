using AutoMapper;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Entities.Dtos.AnswerVariation;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;
using TouchApp.DataAccess.Abstract;

namespace Business.Concrete
{
    public class AnswerVariationManager : IAnswerVariationService
    {
        private readonly IAnswerVariationDal _answerVariationDal;
        private readonly IMapper _mapper;

        public AnswerVariationManager(IAnswerVariationDal answerVariationDal, IMapper mapper)
        {
            _answerVariationDal = answerVariationDal;
            _mapper = mapper;
        }

        public IDataResult<int> Add(AnswerVariation answerVariation)
        {
            try
            {
                int affectedRows = _answerVariationDal.Add(answerVariation);
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

                var deletableEntity = _answerVariationDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = _answerVariationDal.DeleteByStatus(deletableEntity);

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

                var deletableEntity = _answerVariationDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _answerVariationDal.DeletePermanently(deletableEntity);
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

        public IDataResult<AnswerVariation> Get(Expression<Func<AnswerVariation, bool>> filter)
        {
            try
            {
                var response = _answerVariationDal.Get(filter);
                var mappingResult = _mapper.Map<AnswerVariation>(response);
                return new SuccessDataResult<AnswerVariation>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<AnswerVariation>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<AnswerVariation>> GetList(Expression<Func<AnswerVariation, bool>> filter = null)
        {
            try
            {
                var response = _answerVariationDal.GetList(filter);
                var mappingResult = _mapper.Map<List<AnswerVariation>>(response);
                return new SuccessDataResult<List<AnswerVariation>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<AnswerVariation>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> Update(AnswerVariation answerVariation)
        {
            try
            {
                int affectedRows = _answerVariationDal.Update(answerVariation);
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

        public IDataResult<int> AddList(List<AnswerVariation> answerVariations)
        {
            try
            {
                int affectedRows = _answerVariationDal.Add(answerVariations);
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

        public IDataResult<int> UpdateList(List<AnswerVariation> answerVariations)
        {
            try
            {
                int affectedRows = _answerVariationDal.Update(answerVariations);
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

        public IDataResult<int> DeletePermanentlyList(List<AnswerVariation> answerVariations)
        {
            try
            {
                int affectedRows = _answerVariationDal.DeletePermanently(answerVariations);
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

        public IDataResult<int> DeleteByStatusList(List<AnswerVariation> answerVariations)
        {
            try
            {
                foreach (var answerVariation in answerVariations)
                {
                    answerVariation.IsActive = false;
                }

                DeleteAllEntitiesByStatusForAllRelationList(answerVariations);

                int affectedRows = _answerVariationDal.DeleteByStatus(answerVariations);

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

        private void DeleteAllEntitiesByStatusForAllRelationList(List<AnswerVariation> answerVariations)
        {
            foreach (var answerVariation in answerVariations)
            {
            }
        }

        private void DeleteByStatusForAllRelation(AnswerVariation answerVariation)
        {
        }

        public IDataResult<GetAnswerVariationDto> GetDto(Func<GetAnswerVariationDto, bool> filter = null)
        {
            try
            {
                var response = _answerVariationDal.GetAll();
                var mappingResult = _mapper.Map<List<GetAnswerVariationDto>>(response);
                return new SuccessDataResult<GetAnswerVariationDto>(mappingResult.FirstOrDefault(filter));
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetAnswerVariationDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<GetAnswerVariationDto>> GetDtoList(Func<GetAnswerVariationDto, bool> filter = null, int takeCount = 2000)
        {
            try
            {
                var response = _answerVariationDal.GetList();
                var mappingResult = _mapper.Map<List<GetAnswerVariationDto>>(response).Where(filter).Take(takeCount).ToList();
                return new SuccessDataResult<List<GetAnswerVariationDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetAnswerVariationDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }



        #region Asynchronous

        public async Task<IDataResult<int>> AddAsync(AnswerVariation answerVariation)
        {
            try
            {
                int affectedRows = await _answerVariationDal.AddAsync(answerVariation);
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

                var deletableEntity = await _answerVariationDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = await _answerVariationDal.DeleteByStatusAsync(deletableEntity);

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

                var deletableEntity = await _answerVariationDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = await _answerVariationDal.DeletePermanentlyAsync(deletableEntity);
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

        public async Task<IDataResult<AnswerVariation>> GetAsync(Expression<Func<AnswerVariation, bool>> filter)
        {
            try
            {
                var response = await _answerVariationDal.GetAsync(filter);
                var mappingResult = _mapper.Map<AnswerVariation>(response);
                return new SuccessDataResult<AnswerVariation>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<AnswerVariation>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<AnswerVariation>>> GetListAsync(Expression<Func<AnswerVariation, bool>> filter = null)
        {
            try
            {
                var response = (await _answerVariationDal.GetAllAsQueryableAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<AnswerVariation>>(response);
                return new SuccessDataResult<List<AnswerVariation>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<AnswerVariation>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> UpdateAsync(AnswerVariation answerVariation)
        {
            try
            {
                int affectedRows = await _answerVariationDal.UpdateAsync(answerVariation);
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

        public async Task<IDataResult<int>> AddListAsync(List<AnswerVariation> answerVariations)
        {
            try
            {
                int affectedRows = await _answerVariationDal.AddAsync(answerVariations);
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

        public async Task<IDataResult<int>> UpdateListAndSaveAsync(List<AnswerVariation> answerVariations)
        {
            try
            {
                int affectedRows = await _answerVariationDal.UpdateAndSaveAsync(answerVariations);
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

        public async Task<IDataResult<int>> DeletePermanentlyListAsync(List<AnswerVariation> answerVariations)
        {
            try
            {
                int affectedRows = await _answerVariationDal.DeletePermanentlyAsync(answerVariations);
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

        public async Task<IDataResult<GetAnswerVariationDto>> GetDtoAsync(Expression<Func<AnswerVariation, bool>> filter = null)
        {
            try
            {
                var response = await _answerVariationDal.GetAsync(filter);
                var mappingResult = _mapper.Map<GetAnswerVariationDto>(response);
                return new SuccessDataResult<GetAnswerVariationDto>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetAnswerVariationDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<GetAnswerVariationDto>>> GetDtoListAsync(Expression<Func<AnswerVariation, bool>> filter = null, int takeCount = 2000)
        {
            try
            {
                var response = (await _answerVariationDal.GetAllAsQueryableAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<GetAnswerVariationDto>>(response).Take(takeCount).ToList();
                return new SuccessDataResult<List<GetAnswerVariationDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetAnswerVariationDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        #endregion

    }
}
