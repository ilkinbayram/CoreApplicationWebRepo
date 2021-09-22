using AutoMapper;
using Business.Constants;
using Core.Entities.Concrete;
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
    public class TeacherOperationClaimManager : ITeacherOperationClaimService
    {
        private readonly ITeacherOperationClaimDal _teacherOperationClaimDal;
        private readonly IMapper _mapper;
        public TeacherOperationClaimManager(ITeacherOperationClaimDal teacherOperationClaimDal, IMapper mapper)
        {
            _teacherOperationClaimDal = teacherOperationClaimDal;
            _mapper = mapper;
        }

        public IDataResult<int> Add(TeacherOperationClaim teacherOperationClaim)
        {
            try
            {
                int affectedRows = _teacherOperationClaimDal.Add(teacherOperationClaim);
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

                var deletableEntity = _teacherOperationClaimDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                deletableEntity.IsActive = false;
                int affectedRows = _teacherOperationClaimDal.DeleteByStatus(deletableEntity);

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

                var deletableEntity = _teacherOperationClaimDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _teacherOperationClaimDal.DeletePermanently(deletableEntity);
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

        public IDataResult<TeacherOperationClaim> Get(Expression<Func<TeacherOperationClaim, bool>> filter)
        {
            try
            {
                var response = _teacherOperationClaimDal.Get(filter);
                var mappingResult = _mapper.Map<TeacherOperationClaim>(response);
                return new SuccessDataResult<TeacherOperationClaim>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<TeacherOperationClaim>(null, $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<TeacherOperationClaim>> GetList(Expression<Func<TeacherOperationClaim, bool>> filter = null)
        {
            try
            {
                var response = _teacherOperationClaimDal.GetList(filter);
                var mappingResult = _mapper.Map<List<TeacherOperationClaim>>(response);
                return new SuccessDataResult<List<TeacherOperationClaim>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<TeacherOperationClaim>>(null, $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> Update(TeacherOperationClaim teacherOperationClaim)
        {
            try
            {
                int affectedRows = _teacherOperationClaimDal.Update(teacherOperationClaim);
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




        public IDataResult<int> UpdateList(List<TeacherOperationClaim> teacherOperationClaims)
        {
            try
            {
                int affectedRows = _teacherOperationClaimDal.Update(teacherOperationClaims);
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
        public IDataResult<int> AddList(List<TeacherOperationClaim> teacherOperationClaims)
        {
            try
            {
                foreach (var teacherOperationClaim in teacherOperationClaims)
                {
                    teacherOperationClaim.IsActive = true;
                }

                int affectedRows = _teacherOperationClaimDal.Add(teacherOperationClaims);
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
        public IDataResult<int> DeleteByStatusList(List<TeacherOperationClaim> teacherOperationClaims)
        {
            try
            {
                foreach (var teacherOperationClaim in teacherOperationClaims)
                {
                    teacherOperationClaim.IsActive = false;
                }

                int affectedRows = _teacherOperationClaimDal.DeleteByStatus(teacherOperationClaims);

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
        public IDataResult<int> DeletePermanentlyList(List<TeacherOperationClaim> teacherOperationClaims)
        {
            try
            {
                int affectedRows = _teacherOperationClaimDal.DeletePermanently(teacherOperationClaims);
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







        #region Asynchronous

        public async Task<IDataResult<int>> AddAsync(TeacherOperationClaim teacherOperationClaim)
        {
            try
            {
                int affectedRows = await _teacherOperationClaimDal.AddAsync(teacherOperationClaim);
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

                var deletableEntity = await _teacherOperationClaimDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                // DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = await _teacherOperationClaimDal.DeleteByStatusAsync(deletableEntity);

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

                var deletableEntity = await _teacherOperationClaimDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = await _teacherOperationClaimDal.DeletePermanentlyAsync(deletableEntity);
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

        public async Task<IDataResult<TeacherOperationClaim>> GetAsync(Expression<Func<TeacherOperationClaim, bool>> filter)
        {
            try
            {
                var response = await _teacherOperationClaimDal.GetAsync(filter);
                var mappingResult = _mapper.Map<TeacherOperationClaim>(response);
                return new SuccessDataResult<TeacherOperationClaim>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<TeacherOperationClaim>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<TeacherOperationClaim>>> GetListAsync(Expression<Func<TeacherOperationClaim, bool>> filter = null)
        {
            try
            {
                var response = (await _teacherOperationClaimDal.GetAllAsQueryableAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<TeacherOperationClaim>>(response);
                return new SuccessDataResult<List<TeacherOperationClaim>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<TeacherOperationClaim>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> UpdateAsync(TeacherOperationClaim teacherOperationClaim)
        {
            try
            {
                int affectedRows = await _teacherOperationClaimDal.UpdateAsync(teacherOperationClaim);
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

        public async Task<IDataResult<int>> AddListAsync(List<TeacherOperationClaim> teacherOperationClaims)
        {
            try
            {
                int affectedRows = await _teacherOperationClaimDal.AddAsync(teacherOperationClaims);
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

        public async Task<IDataResult<int>> UpdateListAndSaveAsync(List<TeacherOperationClaim> teacherOperationClaims)
        {
            try
            {
                int affectedRows = await _teacherOperationClaimDal.UpdateAndSaveAsync(teacherOperationClaims);
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

        public async Task<IDataResult<int>> DeletePermanentlyListAsync(List<TeacherOperationClaim> teacherOperationClaims)
        {
            try
            {
                int affectedRows = await _teacherOperationClaimDal.DeletePermanentlyAsync(teacherOperationClaims);
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

        //public async Task<IDataResult<GetTeacherOperationClaimDto>> GetDtoAsync(Expression<Func<TeacherOperationClaim, bool>> filter = null)
        //{
        //    try
        //    {
        //        var response = await _teacherOperationClaimDal.GetAsync(filter);
        //        var mappingResult = _mapper.Map<GetTeacherOperationClaimDto>(response);
        //        return new SuccessDataResult<GetTeacherOperationClaimDto>(mappingResult);
        //    }
        //    catch (Exception exception)
        //    {
        //        return new ErrorDataResult<GetTeacherOperationClaimDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
        //    }
        //}

        //public async Task<IDataResult<List<GetTeacherOperationClaimDto>>> GetDtoListAsync(Expression<Func<TeacherOperationClaim, bool>> filter = null, int takeCount = 2000)
        //{
        //    try
        //    {
        //        var response = (await _teacherOperationClaimDal.GetAllAsQueryableAsync(filter)).ToList();
        //        var mappingResult = _mapper.Map<List<GetTeacherOperationClaimDto>>(response).Take(takeCount).ToList();
        //        return new SuccessDataResult<List<GetTeacherOperationClaimDto>>(mappingResult);
        //    }
        //    catch (Exception exception)
        //    {
        //        return new ErrorDataResult<List<GetTeacherOperationClaimDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
        //    }
        //}

        #endregion
    }
}
