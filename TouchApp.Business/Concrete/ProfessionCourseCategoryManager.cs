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
    public class ProfessionCourseCategoryManager : IProfessionCourseCategoryService
    {
        private readonly IProfessionCourseCategoryDal _professionCourseCategoryDal;
        private readonly IMapper _mapper;

        public ProfessionCourseCategoryManager(IProfessionCourseCategoryDal professionCourseCategoryDal, IMapper mapper)
        {
            _professionCourseCategoryDal = professionCourseCategoryDal;
            _mapper = mapper;
        }

        public IDataResult<int> Add(ProfessionCourseCategory professionCourseCategory)
        {
            try
            {
                int affectedRows = _professionCourseCategoryDal.Add(professionCourseCategory);
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

                var deletableEntity = _professionCourseCategoryDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = _professionCourseCategoryDal.DeleteByStatus(deletableEntity);

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

                var deletableEntity = _professionCourseCategoryDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _professionCourseCategoryDal.DeletePermanently(deletableEntity);
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

        public IDataResult<ProfessionCourseCategory> Get(Expression<Func<ProfessionCourseCategory, bool>> filter)
        {
            try
            {
                var response = _professionCourseCategoryDal.Get(filter);
                var mappingResult = _mapper.Map<ProfessionCourseCategory>(response);
                return new SuccessDataResult<ProfessionCourseCategory>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<ProfessionCourseCategory>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<ProfessionCourseCategory>> GetList(Expression<Func<ProfessionCourseCategory, bool>> filter = null)
        {
            try
            {
                var response = _professionCourseCategoryDal.GetList(filter);
                var mappingResult = _mapper.Map<List<ProfessionCourseCategory>>(response);
                return new SuccessDataResult<List<ProfessionCourseCategory>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<ProfessionCourseCategory>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> Update(ProfessionCourseCategory professionCourseCategory)
        {
            try
            {
                int affectedRows = _professionCourseCategoryDal.Update(professionCourseCategory);
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



        public IDataResult<int> AddList(List<ProfessionCourseCategory> professionCourseCategorys)
        {
            try
            {
                int affectedRows = _professionCourseCategoryDal.Add(professionCourseCategorys);
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

        public IDataResult<int> UpdateList(List<ProfessionCourseCategory> professionCourseCategorys)
        {
            try
            {
                int affectedRows = _professionCourseCategoryDal.Update(professionCourseCategorys);
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

        public IDataResult<int> DeletePermanentlyList(List<ProfessionCourseCategory> professionCourseCategorys)
        {
            try
            {
                int affectedRows = _professionCourseCategoryDal.DeletePermanently(professionCourseCategorys);
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

        public IDataResult<int> DeleteByStatusList(List<ProfessionCourseCategory> professionCourseCategorys)
        {
            try
            {
                foreach (var professionCourseCategory in professionCourseCategorys)
                {
                    professionCourseCategory.IsActive = false;
                }

                DeleteAllEntitiesByStatusForAllRelationList(professionCourseCategorys);

                int affectedRows = _professionCourseCategoryDal.DeleteByStatus(professionCourseCategorys);

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

        private void DeleteAllEntitiesByStatusForAllRelationList(List<ProfessionCourseCategory> professionCourseCategorys)
        {
            foreach (var professionCourseCategory in professionCourseCategorys)
            {
            }
        }

        private void DeleteByStatusForAllRelation(ProfessionCourseCategory professionCourseCategory)
        {
        }
    }
}
