using AutoMapper;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Entities.Dtos.SharingTypeMedia;
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
    public class SharingTypeMediaManager : ISharingTypeMediaService
    {
        private readonly ISharingTypeMediaDal _sharingTypeMediaDal;
        private readonly IMapper _mapper;

        public SharingTypeMediaManager(ISharingTypeMediaDal SharingTypeMediaDal, IMapper mapper)
        {
            _sharingTypeMediaDal = SharingTypeMediaDal;
            _mapper = mapper;
        }

        public IDataResult<int> Add(SharingTypeMedia SharingTypeMedia)
        {
            try
            {
                int affectedRows = _sharingTypeMediaDal.Add(SharingTypeMedia);
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

                var deletableEntity = _sharingTypeMediaDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = _sharingTypeMediaDal.DeleteByStatus(deletableEntity);

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

                var deletableEntity = _sharingTypeMediaDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _sharingTypeMediaDal.DeletePermanently(deletableEntity);
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

        public IDataResult<SharingTypeMedia> Get(Expression<Func<SharingTypeMedia, bool>> filter)
        {
            try
            {
                var response = _sharingTypeMediaDal.Get(filter);
                var mappingResult = _mapper.Map<SharingTypeMedia>(response);
                return new SuccessDataResult<SharingTypeMedia>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<SharingTypeMedia>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<GetSharingTypeMediaDto> GetDto(Expression<Func<SharingTypeMedia, bool>> filter = null)
        {
            try
            {
                var response = _sharingTypeMediaDal.Get(filter);
                var mappedModel = _mapper.Map<GetSharingTypeMediaDto>(response);
                return new SuccessDataResult<GetSharingTypeMediaDto>(mappedModel);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetSharingTypeMediaDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<SharingTypeMedia>> GetList(Expression<Func<SharingTypeMedia, bool>> filter = null)
        {
            try
            {
                var response = _sharingTypeMediaDal.GetList(filter);
                var mappingResult = _mapper.Map<List<SharingTypeMedia>>(response);
                return new SuccessDataResult<List<SharingTypeMedia>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<SharingTypeMedia>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> Update(SharingTypeMedia SharingTypeMedia)
        {
            try
            {
                int affectedRows = _sharingTypeMediaDal.Update(SharingTypeMedia);
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



        public IDataResult<int> AddList(List<SharingTypeMedia> SharingTypeMedias)
        {
            try
            {
                int affectedRows = _sharingTypeMediaDal.Add(SharingTypeMedias);
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

        public IDataResult<int> UpdateList(List<SharingTypeMedia> SharingTypeMedias)
        {
            try
            {
                int affectedRows = _sharingTypeMediaDal.Update(SharingTypeMedias);
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

        public IDataResult<int> DeletePermanentlyList(List<SharingTypeMedia> SharingTypeMedias)
        {
            try
            {
                int affectedRows = _sharingTypeMediaDal.DeletePermanently(SharingTypeMedias);
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

        public IDataResult<int> DeleteByStatusList(List<SharingTypeMedia> SharingTypeMedias)
        {
            try
            {
                foreach (var SharingTypeMedia in SharingTypeMedias)
                {
                    SharingTypeMedia.IsActive = false;
                }

                DeleteAllEntitiesByStatusForAllRelationList(SharingTypeMedias);

                int affectedRows = _sharingTypeMediaDal.DeleteByStatus(SharingTypeMedias);

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

        private void DeleteAllEntitiesByStatusForAllRelationList(List<SharingTypeMedia> SharingTypeMedias)
        {
            foreach (var SharingTypeMedia in SharingTypeMedias)
            {
            }
        }

        private void DeleteByStatusForAllRelation(SharingTypeMedia SharingTypeMedia)
        {
        }


        #region Asynchronous

        public async Task<IDataResult<int>> AddAsync(SharingTypeMedia sharingTypeMedia)
        {
            try
            {
                int affectedRows = await _sharingTypeMediaDal.AddAsync(sharingTypeMedia);
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

                var deletableEntity = await _sharingTypeMediaDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = await _sharingTypeMediaDal.DeleteByStatusAsync(deletableEntity);

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

                var deletableEntity = await _sharingTypeMediaDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = await _sharingTypeMediaDal.DeletePermanentlyAsync(deletableEntity);
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

        public async Task<IDataResult<SharingTypeMedia>> GetAsync(Expression<Func<SharingTypeMedia, bool>> filter)
        {
            try
            {
                var response = await _sharingTypeMediaDal.GetAsync(filter);
                var mappingResult = _mapper.Map<SharingTypeMedia>(response);
                return new SuccessDataResult<SharingTypeMedia>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<SharingTypeMedia>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<SharingTypeMedia>>> GetListAsync(Expression<Func<SharingTypeMedia, bool>> filter = null)
        {
            try
            {
                var response = (await _sharingTypeMediaDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<SharingTypeMedia>>(response);
                return new SuccessDataResult<List<SharingTypeMedia>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<SharingTypeMedia>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> UpdateAsync(SharingTypeMedia sharingTypeMedia)
        {
            try
            {
                int affectedRows = await _sharingTypeMediaDal.UpdateAsync(sharingTypeMedia);
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

        public async Task<IDataResult<int>> AddListAsync(List<SharingTypeMedia> sharingTypeMedias)
        {
            try
            {
                int affectedRows = await _sharingTypeMediaDal.AddAsync(sharingTypeMedias);
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

        public async Task<IDataResult<int>> UpdateListAndSaveAsync(List<SharingTypeMedia> sharingTypeMedias)
        {
            try
            {
                int affectedRows = await _sharingTypeMediaDal.UpdateAndSaveAsync(sharingTypeMedias);
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

        public async Task<IDataResult<int>> DeletePermanentlyListAsync(List<SharingTypeMedia> sharingTypeMedias)
        {
            try
            {
                int affectedRows = await _sharingTypeMediaDal.DeletePermanentlyAsync(sharingTypeMedias);
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

        public async Task<IDataResult<GetSharingTypeMediaDto>> GetDtoAsync(Expression<Func<SharingTypeMedia, bool>> filter = null)
        {
            try
            {
                var response = await _sharingTypeMediaDal.GetAsync(filter);
                var mappingResult = _mapper.Map<GetSharingTypeMediaDto>(response);
                return new SuccessDataResult<GetSharingTypeMediaDto>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetSharingTypeMediaDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<GetSharingTypeMediaDto>>> GetDtoListAsync(Expression<Func<SharingTypeMedia, bool>> filter = null, int takeCount = 2000)
        {
            try
            {
                var response = (await _sharingTypeMediaDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<GetSharingTypeMediaDto>>(response).Take(takeCount).ToList();
                return new SuccessDataResult<List<GetSharingTypeMediaDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetSharingTypeMediaDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        #endregion
    }
}
