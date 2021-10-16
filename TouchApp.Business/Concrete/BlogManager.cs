using AutoMapper;
using Business.Constants;
using Business.Libs;
using Core.Entities.Concrete;
using Core.Entities.Dtos.Blog;
using Core.Entities.Dtos.FieUploud;
using Core.Entities.Dtos.Tag;
using Core.Entities.Dtos.TagBlog;
using Core.Extensions;
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
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;
        private readonly IMapper _mapper;

        private readonly IFileManager _fileManager;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly ILocalizationDal _localizationDal;
        private readonly ITagDal _tagDal;
        private readonly ITagBlogDal _tagBlogDal;

        public BlogManager(IBlogDal blogDal,
                           IMapper mapper,
                           IFileManager fileManager,
                           ICloudinaryService cloudinaryService,
                           ILocalizationDal localizationDal,
                           ITagBlogDal tagBlogDal,
                           ITagDal tagDal)
        {
            _blogDal = blogDal;
            _mapper = mapper;
            _fileManager = fileManager;
            _cloudinaryService = cloudinaryService;
            _localizationDal = localizationDal;
            _tagDal = tagDal;
            _tagBlogDal = tagBlogDal;
        }

        public IDataResult<int> Add(CreateManagementBlogDto blog)
        {
            try
            {
                var listFileListAdded = new List<string>();

                var fileUploadResult = _fileManager.UploadSaveDictionary(blog.CaptionSourceFile);

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

                listFileListAdded.Add(publicId);

                blog.CaptionSource = result.CdnPath;

                var blogTagsList = blog.TagsConcat.Split('|').ToList();

                var addedTagIds = new List<long>();

                foreach(var item in blogTagsList)
                {
                    if (_tagDal.Get(k => k.Name.ToLower().Trim() == item.ToLower().Trim()) == null)
                    {
                        var tag = new Tag
                        {
                            TagType = Core.Resources.Enums.TagTypeEnum.ForGlobalSearching,
                            Name = item.Trim(),
                            Modified_at = DateTime.Now,
                            Modified_by = "System Manager"
                        };

                        var resultTagAddOpt = _tagDal.Add(tag);

                        if (resultTagAddOpt <= 0)
                            throw new Exception(Messages.ErrorMessages.NOT_ADDED_AND_ROLLED_BACK);

                        var dbGetTagModelOne = _tagDal.GetWithRelations(x => x.Name.ToLower().Trim() == item.ToLower().Trim());

                        var tagCurrent = _mapper.Map<CreateTagForManagementDto>(dbGetTagModelOne);
                        blog.TagBlogs.Add(new CreateTagBlogManagementDto { TagId = tagCurrent.Id});
                    }
                    else
                    {
                        var dbGetTagModelOne = _tagDal.GetWithRelations(x => x.Name.ToLower().Trim() == item.ToLower().Trim());

                        var foundTag = _mapper.Map<CreateTagForManagementDto>(dbGetTagModelOne);
                        blog.TagBlogs.Add(new CreateTagBlogManagementDto { TagId = foundTag.Id});
                    }
                };

                var addBlogModel = _mapper.Map<Blog>(blog);

                int affectedRows = _blogDal.Add(addBlogModel);

                var localizationList = GeneralFunctionality.ConvertModelToLocalizationList(blog);

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

                var deletableEntity = _blogDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = _blogDal.DeleteByStatus(deletableEntity);

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

                var deletableEntity = _blogDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _blogDal.DeletePermanently(deletableEntity);
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

        public IDataResult<Blog> Get(Expression<Func<Blog, bool>> filter)
        {
            try
            {
                var response = _blogDal.GetWithRelations(filter);
                return new SuccessDataResult<Blog>(response);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<Blog>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<Blog>> GetList(Expression<Func<Blog, bool>> filter = null)
        {
            try
            {
                var response = _blogDal.GetList(filter);
                var mappingResult = _mapper.Map<List<Blog>>(response);
                return new SuccessDataResult<List<Blog>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<Blog>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<GetBlogDto>> GetListDto(Expression<Func<Blog, bool>> filter = null)
        {
            try
            {
                var dtoListResult = new List<GetBlogDto>();
                _blogDal.GetAllWithRelations(filter).ForEach(x=>
                {
                    dtoListResult.Add(_mapper.Map<GetBlogDto>(x));
                });

                return new SuccessDataResult<List<GetBlogDto>>(dtoListResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetBlogDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<GetBlogDto>> GetRelatedBlogsByBlogCategoryId(long id, long savingId = -1)
        {
            try
            {
                var resultDtoList = new List<GetBlogDto>();

                if (_blogDal.GetAllWithRelations(x => x.BlogCategoryId == id && x.Id != savingId) != null && 
                    _blogDal.GetAllWithRelations(x => x.BlogCategoryId == id && x.Id != savingId).Count > 0)
                {
                    _blogDal.GetAllWithRelations(x => x.BlogCategoryId == id && x.Id != savingId).ForEach(blog =>
                    {
                        resultDtoList.Add(_mapper.Map<GetBlogDto>(blog));
                    });
                }

                return new SuccessDataResult<List<GetBlogDto>>(resultDtoList);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetBlogDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<GetBlogDto>> GetFilteredBlogsByTagId(long id)
        {
            try
            {
                var filteredBlogsByTag = new List<GetBlogDto>();
                var foundTag = _tagDal.Get(x=>x.Id==id);

                if (foundTag!=null)
                {
                    _tagBlogDal.GetList(x => x.Tag.Id == foundTag.Id).Select(p => p.Blog).ToList().ForEach(blog=>
                    {
                        filteredBlogsByTag.Add(_mapper.Map<GetBlogDto>(blog));
                    });
                }

                return new SuccessDataResult<List<GetBlogDto>>(filteredBlogsByTag);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetBlogDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<GetBlogDto>> GetFilteredBlogsByBlogCategoryId(long id)
        {
            try
            {
                var resultDtoList = new List<GetBlogDto>();

                List<Blog> blogs = null;

                if (id < 999 && id > 0)
                {
                    blogs = _blogDal.GetAllWithRelations(x => x.BlogCategoryId == id);
                }
                else if(id == 999)
                {
                    blogs = _blogDal.GetAllWithRelations();
                }

                if (blogs != null && blogs.Count > 0)
                {
                    blogs.ForEach(x =>
                    {
                        resultDtoList.Add(_mapper.Map<GetBlogDto>(x));
                    });
                }
                
                return new SuccessDataResult<List<GetBlogDto>>(resultDtoList);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetBlogDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> Update(Blog blog)
        {
            try
            {
                int affectedRows = _blogDal.Update(blog);
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

        public IDataResult<int> AddList(List<Blog> blogs)
        {
            try
            {
                int affectedRows = _blogDal.Add(blogs);
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

        public IDataResult<int> UpdateList(List<Blog> blogs)
        {
            try
            {
                int affectedRows = _blogDal.Update(blogs);
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

        public IDataResult<int> DeletePermanentlyList(List<Blog> blogs)
        {
            try
            {
                int affectedRows = _blogDal.DeletePermanently(blogs);
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

        public IDataResult<int> DeleteByStatusList(List<Blog> blogs)
        {
            try
            {
                foreach (var blog in blogs)
                {
                    blog.IsActive = false;
                }

                DeleteAllEntitiesByStatusForAllRelationList(blogs);

                int affectedRows = _blogDal.DeleteByStatus(blogs);

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

        private void DeleteAllEntitiesByStatusForAllRelationList(List<Blog> blogs)
        {
            foreach (var blog in blogs)
            {
            }
        }

        private void DeleteByStatusForAllRelation(Blog blog)
        {
        }

        public IDataResult<GetBlogDto> GetDto(Expression<Func<Blog, bool>> filter = null)
        {
            try
            {
                var response = _blogDal.GetWithRelations(filter);
                var mappedModel = _mapper.Map<GetBlogDto>(response);
                return new SuccessDataResult<GetBlogDto>(mappedModel);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetBlogDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<GetBlogDto>> GetDtoList(Expression<Func<Blog, bool>> filter = null, int takeCount = 2000)
        {
            try
            {
                var dtoListResult = new List<GetBlogDto>();
                _blogDal.GetList(filter).Take(takeCount).ToList().ForEach(x =>
                {
                    dtoListResult.Add(_mapper.Map<GetBlogDto>(x));
                });

                return new SuccessDataResult<List<GetBlogDto>>(dtoListResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetBlogDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }



        #region Asynchronous

        public async Task<IDataResult<int>> AddAsync(CreateManagementBlogDto blog)
        {
            try
            {
                var mmappedModel = _mapper.Map<Blog>(blog);
                int affectedRows = await _blogDal.AddAsync(mmappedModel);
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

                var deletableEntity = await _blogDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = await _blogDal.DeleteByStatusAsync(deletableEntity);

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

                var deletableEntity = await _blogDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = await _blogDal.DeletePermanentlyAsync(deletableEntity);
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

        public async Task<IDataResult<Blog>> GetAsync(Expression<Func<Blog, bool>> filter)
        {
            try
            {
                var response = await _blogDal.GetAsync(filter);
                var mappingResult = _mapper.Map<Blog>(response);
                return new SuccessDataResult<Blog>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<Blog>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<Blog>>> GetListAsync(Expression<Func<Blog, bool>> filter = null)
        {
            try
            {
                var response = (await _blogDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<Blog>>(response);
                return new SuccessDataResult<List<Blog>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<Blog>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> UpdateAsync(Blog blog)
        {
            try
            {
                int affectedRows = await _blogDal.UpdateAsync(blog);
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

        public async Task<IDataResult<int>> AddListAsync(List<Blog> blogs)
        {
            try
            {
                int affectedRows = await _blogDal.AddAsync(blogs);
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

        public async Task<IDataResult<int>> UpdateListAndSaveAsync(List<Blog> blogs)
        {
            try
            {
                int affectedRows = await _blogDal.UpdateAndSaveAsync(blogs);
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

        public async Task<IDataResult<int>> DeletePermanentlyListAsync(List<Blog> blogs)
        {
            try
            {
                int affectedRows = await _blogDal.DeletePermanentlyAsync(blogs);
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

        public async Task<IDataResult<GetBlogDto>> GetDtoAsync(Expression<Func<Blog, bool>> filter = null)
        {
            try
            {
                var response = await _blogDal.GetAsync(filter);
                var mappingResult = _mapper.Map<GetBlogDto>(response);
                return new SuccessDataResult<GetBlogDto>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetBlogDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<GetBlogDto>>> GetDtoListAsync(Expression<Func<Blog, bool>> filter = null, int takeCount = 2000)
        {
            try
            {
                var response = (await _blogDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<GetBlogDto>>(response).Take(takeCount).ToList();
                return new SuccessDataResult<List<GetBlogDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetBlogDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        #endregion

    }
}
