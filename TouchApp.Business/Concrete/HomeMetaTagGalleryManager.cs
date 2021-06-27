using AutoMapper;
using TouchApp.Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using TouchApp.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class HomeMetaTagGalleryManager : IHomeMetaTagGalleryService
    {
        private readonly IHomeMetaTagGalleryDal _homeMetaTagGalleryDal;
        private readonly IMapper _mapper;

        public HomeMetaTagGalleryManager(IHomeMetaTagGalleryDal homeMetaTagGalleryDal, IMapper mapper)
        {
            _homeMetaTagGalleryDal = homeMetaTagGalleryDal;
            _mapper = mapper;
        }

        public IDataResult<int> Add(HomeMetaTagGallery homeMetaTagGallery)
        {
            try
            {
                int affectedRows = _homeMetaTagGalleryDal.Add(homeMetaTagGallery);
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

                var deletableEntity = _homeMetaTagGalleryDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _homeMetaTagGalleryDal.DeletePermanently(deletableEntity);

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

                var deletableEntity = _homeMetaTagGalleryDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _homeMetaTagGalleryDal.DeletePermanently(deletableEntity);
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

        public IDataResult<HomeMetaTagGallery> Get(Expression<Func<HomeMetaTagGallery, bool>> filter)
        {
            try
            {
                var response = _homeMetaTagGalleryDal.Get(filter);
                var mappingResult = _mapper.Map<HomeMetaTagGallery>(response);
                return new SuccessDataResult<HomeMetaTagGallery>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<HomeMetaTagGallery>(null, $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<IEnumerable<HomeMetaTagGallery>> GetList(Expression<Func<HomeMetaTagGallery, bool>> filter = null)
        {
            try
            {
                var response = _homeMetaTagGalleryDal.GetList(filter);
                var mappingResult = _mapper.Map<IEnumerable<HomeMetaTagGallery>>(response);
                return new SuccessDataResult<IEnumerable<HomeMetaTagGallery>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<IEnumerable<HomeMetaTagGallery>>(null, $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> Update(HomeMetaTagGallery homeMetaTagGallery)
        {
            try
            {
                int affectedRows = _homeMetaTagGalleryDal.Update(homeMetaTagGallery);
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


        public IDataResult<int> UpdateList(IEnumerable<HomeMetaTagGallery> homeMetaTagGalleries)
        {
            try
            {
                int affectedRows = _homeMetaTagGalleryDal.Update(homeMetaTagGalleries);
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
        public IDataResult<int> AddList(IEnumerable<HomeMetaTagGallery> homeMetaTagGalleries)
        {
            try
            {
                foreach (var homeMetaTagGallery in homeMetaTagGalleries)
                {
                    homeMetaTagGallery.IsActive = true;
                }

                int affectedRows = _homeMetaTagGalleryDal.Add(homeMetaTagGalleries);
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
        public IDataResult<int> DeleteByStatusList(IEnumerable<HomeMetaTagGallery> homeMetaTagGalleries)
        {
            try
            {
                foreach (var homeMetaTagGallery in homeMetaTagGalleries)
                {
                    homeMetaTagGallery.IsActive = false;
                }

                int affectedRows = _homeMetaTagGalleryDal.DeleteByStatus(homeMetaTagGalleries);

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
        public IDataResult<int> DeletePermanentlyList(IEnumerable<HomeMetaTagGallery> homeMetaTagGalleries)
        {
            try
            {
                int affectedRows = _homeMetaTagGalleryDal.DeletePermanently(homeMetaTagGalleries);
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
    }
}
