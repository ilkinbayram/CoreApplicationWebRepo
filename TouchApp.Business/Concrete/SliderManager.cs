using AutoMapper;
using Business.Constants;
using Business.Libs;
using Core.Entities.Concrete;
using Core.Entities.Dtos.FieUploud;
using Core.Entities.Dtos.Slider;
using Core.Utilities.Results;
using Core.Utilities.Services.Rest;
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
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _sliderDal;
        private readonly IMapper _mapper;

        private readonly IFileManager _fileManager;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly ILocalizationDal _localizationDal;

        public SliderManager(ISliderDal sliderDal, 
                             IMapper mapper,
                             IFileManager fileManager,
                             ICloudinaryService cloudinaryService,
                             ILocalizationDal localizationDal)
        {
            _sliderDal = sliderDal;
            _mapper = mapper;
            _fileManager = fileManager;
            _cloudinaryService = cloudinaryService;
            _localizationDal = localizationDal;
        }

        public IDataResult<int> Add(CreateManagementSliderDto sliderModel)
        {
            try
            {
                var fileUploadResult = _fileManager.UploadSaveDictionary(sliderModel.SliderMediaSourceFile);

                if (!fileUploadResult.Success)
                    return new ErrorDataResult<int>(-1, false, fileUploadResult.Responses);

                var publicId = _cloudinaryService.StoreImage(fileUploadResult.Data["imagePath"]);

                var result = new FileName()
                {
                    FilePath = fileUploadResult.Data["imagePath"],
                    CdnPath = _cloudinaryService.BuildUrl(publicId),
                    PublicId = publicId
                };

                _fileManager.Delete(fileUploadResult.Data["imagePath"]);

                sliderModel.SliderMediaSource = result.CdnPath;

                var mappedModel = _mapper.Map<Slider>(sliderModel);

                int affectedRows = _sliderDal.Add(mappedModel);

                var localizationList = GeneralFunctionality.ConvertModelToLocalizationList(sliderModel);

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
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotDeleted);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}");
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
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotDeleted);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}");
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
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotUpdated);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}");
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
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotUpdated);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
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
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
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
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotDeleted);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
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
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotDeleted);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }

        }

        public IDataResult<List<GetSliderDto>> GetDtoList(Expression<Func<Slider, bool>> filter = null, int takeCount = 2000)
        {
            try
            {
                var dtoListResult = new List<GetSliderDto>();
                _sliderDal.GetList(filter).Take(takeCount).ToList().ForEach(x =>
                {
                    dtoListResult.Add(_mapper.Map<GetSliderDto>(x));
                });

                return new SuccessDataResult<List<GetSliderDto>>(dtoListResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetSliderDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<GetSliderDto> GetDto(Expression<Func<Slider, bool>> filter = null)
        {
            try
            {
                var response = _sliderDal.Get(filter);
                var mappedModel = _mapper.Map<GetSliderDto>(response);
                return new SuccessDataResult<GetSliderDto>(mappedModel);
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
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotDeleted);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
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
                var response = (await _sliderDal.GetAllAsync(filter)).ToList();
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
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotUpdated);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
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
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
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
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
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
                    dataResult = new ErrorDataResult<int>(-1, false, Messages.BusinessDataWasNotAdded);
                }

                return dataResult;
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<int>(-1, true, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
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
                var response = (await _sliderDal.GetAllAsync(filter)).ToList();
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
