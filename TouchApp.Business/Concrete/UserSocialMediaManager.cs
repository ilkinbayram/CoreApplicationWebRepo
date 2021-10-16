using AutoMapper;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Entities.Dtos.UserSocialMedia;
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
    public class UserSocialMediaManager : IUserSocialMediaService
    {
        private readonly IUserSocialMediaDal _userSocialMediaDal;
        private readonly IMapper _mapper;

        public UserSocialMediaManager(IUserSocialMediaDal userSocialMediaDal, IMapper mapper)
        {
            _userSocialMediaDal = userSocialMediaDal;
            _mapper = mapper;
        }

        public IDataResult<int> Add(UserSocialMedia userSocialMedia)
        {
            try
            {
                int affectedRows = _userSocialMediaDal.Add(userSocialMedia);
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

                var deletableEntity = _userSocialMediaDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = _userSocialMediaDal.DeleteByStatus(deletableEntity);

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

                var deletableEntity = _userSocialMediaDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _userSocialMediaDal.DeletePermanently(deletableEntity);
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

        public IDataResult<UserSocialMedia> Get(Expression<Func<UserSocialMedia, bool>> filter)
        {
            try
            {
                var response = _userSocialMediaDal.Get(filter);
                var mappingResult = _mapper.Map<UserSocialMedia>(response);
                return new SuccessDataResult<UserSocialMedia>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<UserSocialMedia>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<GetUserSocialMediaDto> GetDto(Expression<Func<UserSocialMedia, bool>> filter = null)
        {
            try
            {
                var response = _userSocialMediaDal.Get(filter);
                var mappedModel = _mapper.Map<GetUserSocialMediaDto>(response);
                return new SuccessDataResult<GetUserSocialMediaDto>(mappedModel);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetUserSocialMediaDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<UserSocialMedia>> GetList(Expression<Func<UserSocialMedia, bool>> filter = null)
        {
            try
            {
                var response = _userSocialMediaDal.GetList(filter);
                var mappingResult = _mapper.Map<List<UserSocialMedia>>(response);
                return new SuccessDataResult<List<UserSocialMedia>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<UserSocialMedia>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> Update(UserSocialMedia userSocialMedia)
        {
            try
            {
                int affectedRows = _userSocialMediaDal.Update(userSocialMedia);
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



        public IDataResult<int> AddList(List<UserSocialMedia> userSocialMedias)
        {
            try
            {
                int affectedRows = _userSocialMediaDal.Add(userSocialMedias);
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

        public IDataResult<int> UpdateList(List<UserSocialMedia> userSocialMedias)
        {
            try
            {
                int affectedRows = _userSocialMediaDal.Update(userSocialMedias);
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

        public IDataResult<int> DeletePermanentlyList(List<UserSocialMedia> userSocialMedias)
        {
            try
            {
                int affectedRows = _userSocialMediaDal.DeletePermanently(userSocialMedias);
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

        public IDataResult<int> DeleteByStatusList(List<UserSocialMedia> userSocialMedias)
        {
            try
            {
                foreach (var userSocialMedia in userSocialMedias)
                {
                    userSocialMedia.IsActive = false;
                }

                DeleteAllEntitiesByStatusForAllRelationList(userSocialMedias);

                int affectedRows = _userSocialMediaDal.DeleteByStatus(userSocialMedias);

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

        private void DeleteAllEntitiesByStatusForAllRelationList(List<UserSocialMedia> userSocialMedias)
        {
            foreach (var userSocialMedia in userSocialMedias)
            {
            }
        }

        private void DeleteByStatusForAllRelation(UserSocialMedia userSocialMedia)
        {
        }



        #region Asynchronous

        public async Task<IDataResult<int>> AddAsync(UserSocialMedia userSocialMedia)
        {
            try
            {
                int affectedRows = await _userSocialMediaDal.AddAsync(userSocialMedia);
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

                var deletableEntity = await _userSocialMediaDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = await _userSocialMediaDal.DeleteByStatusAsync(deletableEntity);

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

                var deletableEntity = await _userSocialMediaDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = await _userSocialMediaDal.DeletePermanentlyAsync(deletableEntity);
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

        public async Task<IDataResult<UserSocialMedia>> GetAsync(Expression<Func<UserSocialMedia, bool>> filter)
        {
            try
            {
                var response = await _userSocialMediaDal.GetAsync(filter);
                var mappingResult = _mapper.Map<UserSocialMedia>(response);
                return new SuccessDataResult<UserSocialMedia>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<UserSocialMedia>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<UserSocialMedia>>> GetListAsync(Expression<Func<UserSocialMedia, bool>> filter = null)
        {
            try
            {
                var response = (await _userSocialMediaDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<UserSocialMedia>>(response);
                return new SuccessDataResult<List<UserSocialMedia>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<UserSocialMedia>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> UpdateAsync(UserSocialMedia userSocialMedia)
        {
            try
            {
                int affectedRows = await _userSocialMediaDal.UpdateAsync(userSocialMedia);
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

        public async Task<IDataResult<int>> AddListAsync(List<UserSocialMedia> userSocialMedias)
        {
            try
            {
                int affectedRows = await _userSocialMediaDal.AddAsync(userSocialMedias);
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

        public async Task<IDataResult<int>> UpdateListAndSaveAsync(List<UserSocialMedia> userSocialMedias)
        {
            try
            {
                int affectedRows = await _userSocialMediaDal.UpdateAndSaveAsync(userSocialMedias);
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

        public async Task<IDataResult<int>> DeletePermanentlyListAsync(List<UserSocialMedia> userSocialMedias)
        {
            try
            {
                int affectedRows = await _userSocialMediaDal.DeletePermanentlyAsync(userSocialMedias);
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

        public async Task<IDataResult<GetUserSocialMediaDto>> GetDtoAsync(Expression<Func<UserSocialMedia, bool>> filter = null)
        {
            try
            {
                var response = await _userSocialMediaDal.GetAsync(filter);
                var mappingResult = _mapper.Map<GetUserSocialMediaDto>(response);
                return new SuccessDataResult<GetUserSocialMediaDto>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetUserSocialMediaDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<GetUserSocialMediaDto>>> GetDtoListAsync(Expression<Func<UserSocialMedia, bool>> filter = null, int takeCount = 2000)
        {
            try
            {
                var response = (await _userSocialMediaDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<GetUserSocialMediaDto>>(response).Take(takeCount).ToList();
                return new SuccessDataResult<List<GetUserSocialMediaDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetUserSocialMediaDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        #endregion
    }
}
