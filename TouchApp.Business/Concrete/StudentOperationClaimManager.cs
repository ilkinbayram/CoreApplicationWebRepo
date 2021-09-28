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
    public class StudentOperationClaimManager : IStudentOperationClaimService
    {
        private readonly IStudentOperationClaimDal _studentOperationClaimDal;
        private readonly IMapper _mapper;
        public StudentOperationClaimManager(IStudentOperationClaimDal studentOperationClaimDal, IMapper mapper)
        {
            _studentOperationClaimDal = studentOperationClaimDal;
            _mapper = mapper;
        }

        public IDataResult<int> Add(StudentOperationClaim studentOperationClaim)
        {
            try
            {
                int affectedRows = _studentOperationClaimDal.Add(studentOperationClaim);
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

                var deletableEntity = _studentOperationClaimDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                deletableEntity.IsActive = false;
                int affectedRows = _studentOperationClaimDal.DeleteByStatus(deletableEntity);

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

                var deletableEntity = _studentOperationClaimDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _studentOperationClaimDal.DeletePermanently(deletableEntity);
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

        public IDataResult<StudentOperationClaim> Get(Expression<Func<StudentOperationClaim, bool>> filter)
        {
            try
            {
                var response = _studentOperationClaimDal.Get(filter);
                var mappingResult = _mapper.Map<StudentOperationClaim>(response);
                return new SuccessDataResult<StudentOperationClaim>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<StudentOperationClaim>(null, $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<StudentOperationClaim>> GetList(Expression<Func<StudentOperationClaim, bool>> filter = null)
        {
            try
            {
                var response = _studentOperationClaimDal.GetList(filter);
                var mappingResult = _mapper.Map<List<StudentOperationClaim>>(response);
                return new SuccessDataResult<List<StudentOperationClaim>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<StudentOperationClaim>>(null, $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<int> Update(StudentOperationClaim studentOperationClaim)
        {
            try
            {
                int affectedRows = _studentOperationClaimDal.Update(studentOperationClaim);
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




        public IDataResult<int> UpdateList(List<StudentOperationClaim> studentOperationClaims)
        {
            try
            {
                int affectedRows = _studentOperationClaimDal.Update(studentOperationClaims);
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
        public IDataResult<int> AddList(List<StudentOperationClaim> studentOperationClaims)
        {
            try
            {
                foreach (var studentOperationClaim in studentOperationClaims)
                {
                    studentOperationClaim.IsActive = true;
                }

                int affectedRows = _studentOperationClaimDal.Add(studentOperationClaims);
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
        public IDataResult<int> DeleteByStatusList(List<StudentOperationClaim> studentOperationClaims)
        {
            try
            {
                foreach (var studentOperationClaim in studentOperationClaims)
                {
                    studentOperationClaim.IsActive = false;
                }

                int affectedRows = _studentOperationClaimDal.DeleteByStatus(studentOperationClaims);

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
        public IDataResult<int> DeletePermanentlyList(List<StudentOperationClaim> studentOperationClaims)
        {
            try
            {
                int affectedRows = _studentOperationClaimDal.DeletePermanently(studentOperationClaims);
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

        public async Task<IDataResult<int>> AddAsync(StudentOperationClaim studentOperationClaim)
        {
            try
            {
                int affectedRows = await _studentOperationClaimDal.AddAsync(studentOperationClaim);
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

                var deletableEntity = await _studentOperationClaimDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                // DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = await _studentOperationClaimDal.DeleteByStatusAsync(deletableEntity);

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

                var deletableEntity = await _studentOperationClaimDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = await _studentOperationClaimDal.DeletePermanentlyAsync(deletableEntity);
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

        public async Task<IDataResult<StudentOperationClaim>> GetAsync(Expression<Func<StudentOperationClaim, bool>> filter)
        {
            try
            {
                var response = await _studentOperationClaimDal.GetAsync(filter);
                var mappingResult = _mapper.Map<StudentOperationClaim>(response);
                return new SuccessDataResult<StudentOperationClaim>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<StudentOperationClaim>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<StudentOperationClaim>>> GetListAsync(Expression<Func<StudentOperationClaim, bool>> filter = null)
        {
            try
            {
                var response = (await _studentOperationClaimDal.GetAllAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<StudentOperationClaim>>(response);
                return new SuccessDataResult<List<StudentOperationClaim>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<StudentOperationClaim>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> UpdateAsync(StudentOperationClaim studentOperationClaim)
        {
            try
            {
                int affectedRows = await _studentOperationClaimDal.UpdateAsync(studentOperationClaim);
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

        public async Task<IDataResult<int>> AddListAsync(List<StudentOperationClaim> studentOperationClaims)
        {
            try
            {
                int affectedRows = await _studentOperationClaimDal.AddAsync(studentOperationClaims);
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

        public async Task<IDataResult<int>> UpdateListAndSaveAsync(List<StudentOperationClaim> studentOperationClaims)
        {
            try
            {
                int affectedRows = await _studentOperationClaimDal.UpdateAndSaveAsync(studentOperationClaims);
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

        public async Task<IDataResult<int>> DeletePermanentlyListAsync(List<StudentOperationClaim> studentOperationClaims)
        {
            try
            {
                int affectedRows = await _studentOperationClaimDal.DeletePermanentlyAsync(studentOperationClaims);
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

        //public async Task<IDataResult<GetStudentOperationClaimDto>> GetDtoAsync(Expression<Func<StudentOperationClaim, bool>> filter = null)
        //{
        //    try
        //    {
        //        var response = await _studentOperationClaimDal.GetAsync(filter);
        //        var mappingResult = _mapper.Map<GetStudentOperationClaimDto>(response);
        //        return new SuccessDataResult<GetStudentOperationClaimDto>(mappingResult);
        //    }
        //    catch (Exception exception)
        //    {
        //        return new ErrorDataResult<GetStudentOperationClaimDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
        //    }
        //}

        //public async Task<IDataResult<List<GetStudentOperationClaimDto>>> GetDtoListAsync(Expression<Func<StudentOperationClaim, bool>> filter = null, int takeCount = 2000)
        //{
        //    try
        //    {
        //        var response = (await _studentOperationClaimDal.GetAllAsync(filter)).ToList();
        //        var mappingResult = _mapper.Map<List<GetStudentOperationClaimDto>>(response).Take(takeCount).ToList();
        //        return new SuccessDataResult<List<GetStudentOperationClaimDto>>(mappingResult);
        //    }
        //    catch (Exception exception)
        //    {
        //        return new ErrorDataResult<List<GetStudentOperationClaimDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
        //    }
        //}

        #endregion
    }
}
