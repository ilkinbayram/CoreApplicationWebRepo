using AutoMapper;
using Business.Constants;
using Business.Libs;
using Core.Aspects.Autofac.Caching;
using Core.Entities.Concrete;
using Core.Entities.Dtos.FieUploud;
using Core.Entities.Dtos.Media;
using Core.Entities.Dtos.SharingTypeMedia;
using Core.Utilities.Results;
using Core.Utilities.Services.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TouchApp.Business.Abstract;
using TouchApp.DataAccess.Abstract;

namespace Business.Concrete
{
    public class MediaManager : IMediaService
    {
        private readonly IMediaDal _mediaDal;
        private readonly IMapper _mapper;

        private readonly IFileManager _fileManager;
        private readonly ICloudinaryService _cloudinaryService;

        public MediaManager(IMediaDal mediaDal,
                             IMapper mapper,
                             IFileManager fileManager,
                             ICloudinaryService cloudinaryService)
        {
            _mediaDal = mediaDal;
            _mapper = mapper;
            _fileManager = fileManager;
            _cloudinaryService = cloudinaryService;
        }

        public IDataResult<int> Add(CreateManagementMediaDto media)
        {
            try
            {
                var fileUploadResult = _fileManager.UploadSaveDictionary(media.SourceFile);

                if (!fileUploadResult.Success)
                    return new ErrorDataResult<int>(-1, fileUploadResult.Message);

                var publicId = _cloudinaryService.StoreImage(fileUploadResult.Data["imagePath"]);

                var result = new FileName()
                {
                    FilePath = fileUploadResult.Data["imagePath"],
                    CdnPath = _cloudinaryService.BuildUrl(publicId),
                    PublicId = publicId
                };

                _fileManager.Delete(fileUploadResult.Data["imagePath"]);

                media.Source = result.CdnPath;

                foreach (var idOne in media.SelectedSharingTypes)
                {
                    media.SharingTypeMedias.Add(new CreateManagementSharingTypeMediaDto { SharingTypeId = idOne });
                }

                media.UniqueParentToken = Guid.NewGuid().ToString().Replace("-", "");
                var mappedModel = _mapper.Map<Media>(media);
                int affectedRows = _mediaDal.Add(mappedModel);
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

        public IDataResult<int> DeleteByStatus(long Id)
        {
            try
            {
                IDataResult<int> dataResult;

                var deletableEntity = _mediaDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = _mediaDal.DeleteByStatus(deletableEntity);

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

                var deletableEntity = _mediaDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _mediaDal.DeletePermanently(deletableEntity);
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

        public IDataResult<Media> Get(Expression<Func<Media, bool>> filter)
        {
            try
            {
                var response = _mediaDal.Get(filter);
                var mappingResult = _mapper.Map<Media>(response);
                return new SuccessDataResult<Media>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<Media>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        [CacheAspect(1440)]
        public IDataResult<List<Media>> GetList(Expression<Func<Media, bool>> filter = null)
        {
            try
            {
                var response = _mediaDal.GetList(filter);
                var mappingResult = _mapper.Map<List<Media>>(response);
                return new SuccessDataResult<List<Media>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<Media>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> Update(Media media)
        {
            try
            {
                int affectedRows = _mediaDal.Update(media);
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



        public IDataResult<int> AddList(List<Media> medias)
        {
            try
            {
                int affectedRows = _mediaDal.Add(medias);
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

        public IDataResult<int> UpdateList(List<Media> medias)
        {
            try
            {
                int affectedRows = _mediaDal.Update(medias);
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

        public IDataResult<int> DeletePermanentlyList(List<Media> medias)
        {
            try
            {
                int affectedRows = _mediaDal.DeletePermanently(medias);
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

        public IDataResult<int> DeleteByStatusList(List<Media> medias)
        {
            try
            {
                foreach (var media in medias)
                {
                    media.IsActive = false;
                }

                DeleteAllEntitiesByStatusForAllRelationList(medias);

                int affectedRows = _mediaDal.DeleteByStatus(medias);

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

        private void DeleteAllEntitiesByStatusForAllRelationList(List<Media> medias)
        {
            foreach (var media in medias)
            {
            }
        }

        private void DeleteByStatusForAllRelation(Media media)
        {
        }

        public IDataResult<GetMediaDto> GetDto(Expression<Func<Media, bool>> filter = null)
        {
            try
            {
                var response = _mediaDal.GetWithRelations(filter);
                var mappedModel = _mapper.Map<GetMediaDto>(response);
                return new SuccessDataResult<GetMediaDto>(mappedModel);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetMediaDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        [CacheAspect(1440)]
        public IDataResult<List<GetMediaDto>> GetDtoList(Expression<Func<Media, bool>> filter = null, int takeCount = 2000)
        {
            try
            {
                var dtoListResult = new List<GetMediaDto>();
                _mediaDal.GetAllWithRelations(filter).Take(takeCount).ToList().ForEach(x =>
                {
                    var addableItem = _mapper.Map<GetMediaDto>(x);
                    var concatString = "";
                    x.SharingTypeMedias.Select(x => x.SharingType).ToList().ForEach(x =>
                    {
                        concatString += string.Format(" {0} ", x.AbriveatureClass);
                    });
                    addableItem.NavigationClassesConcatSharingType = concatString.Trim();
                    dtoListResult.Add(addableItem);
                });

                return new SuccessDataResult<List<GetMediaDto>>(dtoListResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetMediaDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        #region Asynchronous

        public async Task<IDataResult<int>> AddAsync(Media media)
        {
            try
            {
                int affectedRows = await _mediaDal.AddAsync(media);
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

                var deletableEntity = await _mediaDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = await _mediaDal.DeleteByStatusAsync(deletableEntity);

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

                var deletableEntity = await _mediaDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = await _mediaDal.DeletePermanentlyAsync(deletableEntity);
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

        public async Task<IDataResult<Media>> GetAsync(Expression<Func<Media, bool>> filter)
        {
            try
            {
                var response = await _mediaDal.GetAsync(filter);
                var mappingResult = _mapper.Map<Media>(response);
                return new SuccessDataResult<Media>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<Media>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<Media>>> GetListAsync(Expression<Func<Media, bool>> filter = null)
        {
            try
            {
                var response = (await _mediaDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<Media>>(response);
                return new SuccessDataResult<List<Media>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<Media>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> UpdateAsync(Media media)
        {
            try
            {
                int affectedRows = await _mediaDal.UpdateAsync(media);
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

        public async Task<IDataResult<int>> AddListAsync(List<Media> medias)
        {
            try
            {
                int affectedRows = await _mediaDal.AddAsync(medias);
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

        public async Task<IDataResult<int>> UpdateListAndSaveAsync(List<Media> medias)
        {
            try
            {
                int affectedRows = await _mediaDal.UpdateAndSaveAsync(medias);
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

        public async Task<IDataResult<int>> DeletePermanentlyListAsync(List<Media> medias)
        {
            try
            {
                int affectedRows = await _mediaDal.DeletePermanentlyAsync(medias);
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

        public async Task<IDataResult<GetMediaDto>> GetDtoAsync(Expression<Func<Media, bool>> filter = null)
        {
            try
            {
                var response = await _mediaDal.GetAsync(filter);
                var mappingResult = _mapper.Map<GetMediaDto>(response);
                return new SuccessDataResult<GetMediaDto>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetMediaDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<GetMediaDto>>> GetDtoListAsync(Expression<Func<Media, bool>> filter = null, int takeCount = 2000)
        {
            try
            {
                var response = (await _mediaDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<GetMediaDto>>(response).Take(takeCount).ToList();
                return new SuccessDataResult<List<GetMediaDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetMediaDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        #endregion
    }
}
