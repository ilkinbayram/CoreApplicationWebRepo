using AutoMapper;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Entities.Dtos.Slider;
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
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;
        private readonly IMapper _mapper;

        public SliderManager(ISliderDal sliderDal, IMapper mapper)
        {
            _sliderDal = sliderDal;
            _mapper = mapper;
        }

        public IDataResult<int> Add(Slider homeMetaTagGallery)
        {
            try
            {
                int affectedRows = _sliderDal.Add(homeMetaTagGallery);
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
                return new ErrorDataResult<int>(-1, $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> DeleteByStatus(long Id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = _sliderDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _sliderDal.DeletePermanently(deletableEntity);

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
                return new ErrorDataResult<int>(-1, $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> DeletePermanently(long Id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = _sliderDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _sliderDal.DeletePermanently(deletableEntity);
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
                return new ErrorDataResult<int>(-1, $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<Slider> Get(Expression<Func<Slider, bool>> filter)
        {
            try
            {
                var response = _sliderDal.Get(filter);
                var mappingResult = _mapper.Map<Slider>(response);
                return new SuccessDataResult<Slider>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<Slider>(null, $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<Slider>> GetList(Expression<Func<Slider, bool>> filter = null)
        {
            try
            {
                var response = _sliderDal.GetList(filter);
                var mappingResult = _mapper.Map<List<Slider>>(response);
                return new SuccessDataResult<List<Slider>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<Slider>>(null, $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> Update(Slider homeMetaTagGallery)
        {
            try
            {
                int affectedRows = _sliderDal.Update(homeMetaTagGallery);
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
                return new ErrorDataResult<int>(-1, $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}");
            }
        }


        public IDataResult<int> UpdateList(List<Slider> homeMetaTagGalleries)
        {
            try
            {
                int affectedRows = _sliderDal.Update(homeMetaTagGalleries);
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
        public IDataResult<int> AddList(List<Slider> homeMetaTagGalleries)
        {
            try
            {
                foreach (var homeMetaTagGallery in homeMetaTagGalleries)
                {
                    homeMetaTagGallery.IsActive = true;
                }

                int affectedRows = _sliderDal.Add(homeMetaTagGalleries);
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
        public IDataResult<int> DeleteByStatusList(List<Slider> homeMetaTagGalleries)
        {
            try
            {
                foreach (var homeMetaTagGallery in homeMetaTagGalleries)
                {
                    homeMetaTagGallery.IsActive = false;
                }

                int affectedRows = _sliderDal.DeleteByStatus(homeMetaTagGalleries);

                IDataResult<int> dataResult;
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
        public IDataResult<int> DeletePermanentlyList(List<Slider> homeMetaTagGalleries)
        {
            try
            {
                int affectedRows = _sliderDal.DeletePermanently(homeMetaTagGalleries);
                IDataResult<int> dataResult;
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

        public IDataResult<List<GetSliderDto>> GetDtoList(Func<GetSliderDto, bool> filter = null, int takeCount = 2000)
        {
            try
            {
                var response = _sliderDal.GetList();
                var mappingResult = _mapper.Map<List<GetSliderDto>>(response).Where(filter).Take(takeCount).ToList();
                return new SuccessDataResult<List<GetSliderDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetSliderDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<GetSliderDto> GetDto(Func<GetSliderDto, bool> filter)
        {
            try
            {
                var response = _sliderDal.GetAll();
                var mappingResult = _mapper.Map<List<GetSliderDto>>(response);
                return new SuccessDataResult<GetSliderDto>(mappingResult.FirstOrDefault(filter));
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetSliderDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }


        #region Asynchronous

        public async Task<IDataResult<int>> AddAsync(Slider slider)
        {
            try
            {
                int affectedRows = await _sliderDal.AddAsync(slider);
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

                var deletableEntity = await _sliderDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                // DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = await _sliderDal.DeleteByStatusAsync(deletableEntity);

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

                var deletableEntity = await _sliderDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = await _sliderDal.DeletePermanentlyAsync(deletableEntity);
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

        public async Task<IDataResult<Slider>> GetAsync(Expression<Func<Slider, bool>> filter)
        {
            try
            {
                var response = await _sliderDal.GetAsync(filter);
                var mappingResult = _mapper.Map<Slider>(response);
                return new SuccessDataResult<Slider>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<Slider>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<Slider>>> GetListAsync(Expression<Func<Slider, bool>> filter = null)
        {
            try
            {
                var response = (await _sliderDal.GetAllAsQueryableAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<Slider>>(response);
                return new SuccessDataResult<List<Slider>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<Slider>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> UpdateAsync(Slider slider)
        {
            try
            {
                int affectedRows = await _sliderDal.UpdateAsync(slider);
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

        public async Task<IDataResult<int>> AddListAsync(List<Slider> sliders)
        {
            try
            {
                int affectedRows = await _sliderDal.AddAsync(sliders);
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

        public async Task<IDataResult<int>> UpdateListAndSaveAsync(List<Slider> sliders)
        {
            try
            {
                int affectedRows = await _sliderDal.UpdateAndSaveAsync(sliders);
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

        public async Task<IDataResult<int>> DeletePermanentlyListAsync(List<Slider> sliders)
        {
            try
            {
                int affectedRows = await _sliderDal.DeletePermanentlyAsync(sliders);
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

        public async Task<IDataResult<GetSliderDto>> GetDtoAsync(Expression<Func<Slider, bool>> filter = null)
        {
            try
            {
                var response = await _sliderDal.GetAsync(filter);
                var mappingResult = _mapper.Map<GetSliderDto>(response);
                return new SuccessDataResult<GetSliderDto>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetSliderDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<GetSliderDto>>> GetDtoListAsync(Expression<Func<Slider, bool>> filter = null, int takeCount = 2000)
        {
            try
            {
                var response = (await _sliderDal.GetAllAsQueryableAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<GetSliderDto>>(response).Take(takeCount).ToList();
                return new SuccessDataResult<List<GetSliderDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetSliderDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        #endregion
    }
}
