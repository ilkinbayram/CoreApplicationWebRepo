﻿using AutoMapper;
using Business.Constants;
using Business.Libs;
using Core.Entities.Concrete;
using Core.Entities.Dtos.FieUploud;
using Core.Entities.Dtos.SocialMedia;
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
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal;
        private readonly IMapper _mapper;

        private readonly IFileManager _fileManager;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly ILocalizationDal _localizationDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal,
                                  IMapper mapper,
                                  IFileManager fileManager,
                                  ICloudinaryService cloudinaryService,
                                  ILocalizationDal localizationDal)
        {
            _socialMediaDal = socialMediaDal;
            _mapper = mapper;
            _fileManager = fileManager;
            _cloudinaryService = cloudinaryService;
            _localizationDal = localizationDal;
        }

        public IDataResult<int> Add(CreateManagementSocialMediaDto socialMedia)
        {
            try
            {
                var listFileListAdded = new List<string>();

                var fileUploadResult = _fileManager.UploadThumbnail(socialMedia.IconSourceFile);

                if (!fileUploadResult.Success)
                    return new ErrorDataResult<int>(-1, false, fileUploadResult.Responses);

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

                socialMedia.IconSource = result.CdnPath;

                var mappedModel = _mapper.Map<SocialMedia>(socialMedia);

                int affectedRows = _socialMediaDal.Add(mappedModel);

                var localizationList = GeneralFunctionality.ConvertModelToLocalizationList(socialMedia);

                if (localizationList != null && localizationList.Count>0)
                {
                    foreach (var localizationOne in localizationList)
                    {
                        var responseAddLocalization = _localizationDal.Add(localizationOne);
                        if (responseAddLocalization <= 0)
                            throw new Exception(Messages.ErrorMessages.NOT_ADDED_AND_ROLLED_BACK);
                    }
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

                var deletableEntity = _socialMediaDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = _socialMediaDal.DeleteByStatus(deletableEntity);

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

                var deletableEntity = _socialMediaDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _socialMediaDal.DeletePermanently(deletableEntity);
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

        public IDataResult<SocialMedia> Get(Expression<Func<SocialMedia, bool>> filter)
        {
            try
            {
                var response = _socialMediaDal.Get(filter);
                var mappingResult = _mapper.Map<SocialMedia>(response);
                return new SuccessDataResult<SocialMedia>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<SocialMedia>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<GetSocialMediaDto> GetDto(Expression<Func<SocialMedia, bool>> filter = null)
        {
            try
            {
                var response = _socialMediaDal.GetWithRelations(filter);
                var mappedModel = _mapper.Map<GetSocialMediaDto>(response);
                return new SuccessDataResult<GetSocialMediaDto>(mappedModel);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetSocialMediaDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<SocialMedia>> GetList(Expression<Func<SocialMedia, bool>> filter = null)
        {
            try
            {
                var response = _socialMediaDal.GetList(filter);
                var mappingResult = _mapper.Map<List<SocialMedia>>(response);
                return new SuccessDataResult<List<SocialMedia>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<SocialMedia>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<GetSocialMediaDto>> GetDtoList(Expression<Func<SocialMedia, bool>> filter = null, int takeCount = 2000)
        {
            try
            {
                var dtoListResult = new List<GetSocialMediaDto>();
                var resultany = _socialMediaDal.GetList(filter).Take(takeCount).ToList();
                _socialMediaDal.GetList(filter).Take(takeCount).ToList().ForEach(x =>
                {
                    dtoListResult.Add(_mapper.Map<GetSocialMediaDto>(x));
                });

                return new SuccessDataResult<List<GetSocialMediaDto>>(dtoListResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetSocialMediaDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> Update(SocialMedia socialMedia)
        {
            try
            {
                int affectedRows = _socialMediaDal.Update(socialMedia);
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



        public IDataResult<int> AddList(List<SocialMedia> socialMedias)
        {
            try
            {
                int affectedRows = _socialMediaDal.Add(socialMedias);
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

        public IDataResult<int> UpdateList(List<SocialMedia> socialMedias)
        {
            try
            {
                int affectedRows = _socialMediaDal.Update(socialMedias);
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

        public IDataResult<int> DeletePermanentlyList(List<SocialMedia> socialMedias)
        {
            try
            {
                int affectedRows = _socialMediaDal.DeletePermanently(socialMedias);
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

        public IDataResult<int> DeleteByStatusList(List<SocialMedia> socialMedias)
        {
            try
            {
                foreach (var socialMedia in socialMedias)
                {
                    socialMedia.IsActive = false;
                }

                DeleteAllEntitiesByStatusForAllRelationList(socialMedias);

                int affectedRows = _socialMediaDal.DeleteByStatus(socialMedias);

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

        private void DeleteAllEntitiesByStatusForAllRelationList(List<SocialMedia> socialMedias)
        {
            foreach (var socialMedia in socialMedias)
            {
            }
        }

        private void DeleteByStatusForAllRelation(SocialMedia socialMedia)
        {
        }




        #region Asynchronous

        public async Task<IDataResult<int>> AddAsync(SocialMedia socialMedia)
        {
            try
            {
                int affectedRows = await _socialMediaDal.AddAsync(socialMedia);
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

                var deletableEntity = await _socialMediaDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = await _socialMediaDal.DeleteByStatusAsync(deletableEntity);

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

                var deletableEntity = await _socialMediaDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = await _socialMediaDal.DeletePermanentlyAsync(deletableEntity);
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

        public async Task<IDataResult<SocialMedia>> GetAsync(Expression<Func<SocialMedia, bool>> filter)
        {
            try
            {
                var response = await _socialMediaDal.GetAsync(filter);
                var mappingResult = _mapper.Map<SocialMedia>(response);
                return new SuccessDataResult<SocialMedia>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<SocialMedia>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<SocialMedia>>> GetListAsync(Expression<Func<SocialMedia, bool>> filter = null)
        {
            try
            {
                var response = (await _socialMediaDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<SocialMedia>>(response);
                return new SuccessDataResult<List<SocialMedia>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<SocialMedia>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> UpdateAsync(SocialMedia socialMedia)
        {
            try
            {
                int affectedRows = await _socialMediaDal.UpdateAsync(socialMedia);
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

        public async Task<IDataResult<int>> AddListAsync(List<SocialMedia> socialMedias)
        {
            try
            {
                int affectedRows = await _socialMediaDal.AddAsync(socialMedias);
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

        public async Task<IDataResult<int>> UpdateListAndSaveAsync(List<SocialMedia> socialMedias)
        {
            try
            {
                int affectedRows = await _socialMediaDal.UpdateAndSaveAsync(socialMedias);
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

        public async Task<IDataResult<int>> DeletePermanentlyListAsync(List<SocialMedia> socialMedias)
        {
            try
            {
                int affectedRows = await _socialMediaDal.DeletePermanentlyAsync(socialMedias);
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

        public async Task<IDataResult<GetSocialMediaDto>> GetDtoAsync(Expression<Func<SocialMedia, bool>> filter = null)
        {
            try
            {
                var response = await _socialMediaDal.GetAsync(filter);
                var mappingResult = _mapper.Map<GetSocialMediaDto>(response);
                return new SuccessDataResult<GetSocialMediaDto>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetSocialMediaDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<GetSocialMediaDto>>> GetDtoListAsync(Expression<Func<SocialMedia, bool>> filter = null, int takeCount = 2000)
        {
            try
            {
                var response = (await _socialMediaDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<GetSocialMediaDto>>(response).Take(takeCount).ToList();
                return new SuccessDataResult<List<GetSocialMediaDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetSocialMediaDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }
        #endregion
    }
}
