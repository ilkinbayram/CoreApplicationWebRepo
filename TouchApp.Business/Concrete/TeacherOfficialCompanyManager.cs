using AutoMapper;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Entities.Dtos.TeacherOfficialCompany;
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
    public class TeacherOfficialCompanyManager : ITeacherOfficialCompanyService
    {
        private readonly ITeacherOfficialCompanyDal _teacherOfficialCompanyDal;
        private readonly IMapper _mapper;

        public TeacherOfficialCompanyManager(ITeacherOfficialCompanyDal teacherOfficialCompanyDal, IMapper mapper)
        {
            _teacherOfficialCompanyDal = teacherOfficialCompanyDal;
            _mapper = mapper;
        }

        public IDataResult<int> Add(TeacherOfficialCompany teacherOfficialCompany)
        {
            try
            {
                int affectedRows = _teacherOfficialCompanyDal.Add(teacherOfficialCompany);
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

                var deletableEntity = _teacherOfficialCompanyDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = _teacherOfficialCompanyDal.DeleteByStatus(deletableEntity);

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

                var deletableEntity = _teacherOfficialCompanyDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _teacherOfficialCompanyDal.DeletePermanently(deletableEntity);
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

        public IDataResult<TeacherOfficialCompany> Get(Expression<Func<TeacherOfficialCompany, bool>> filter)
        {
            try
            {
                var response = _teacherOfficialCompanyDal.Get(filter);
                var mappingResult = _mapper.Map<TeacherOfficialCompany>(response);
                return new SuccessDataResult<TeacherOfficialCompany>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<TeacherOfficialCompany>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<TeacherOfficialCompany>> GetList(Expression<Func<TeacherOfficialCompany, bool>> filter = null)
        {
            try
            {
                var response = _teacherOfficialCompanyDal.GetList(filter);
                var mappingResult = _mapper.Map<List<TeacherOfficialCompany>>(response);
                return new SuccessDataResult<List<TeacherOfficialCompany>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<TeacherOfficialCompany>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }



        public IDataResult<GetTeacherOfficialCompanyDto> GetDto(Func<GetTeacherOfficialCompanyDto, bool> filter = null)
        {
            try
            {
                var response = _teacherOfficialCompanyDal.GetAll();
                var mappingResult = _mapper.Map<List<GetTeacherOfficialCompanyDto>>(response);
                return new SuccessDataResult<GetTeacherOfficialCompanyDto>(mappingResult.FirstOrDefault(filter));
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetTeacherOfficialCompanyDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<GetTeacherOfficialCompanyDto>> GetDtoList(Func<GetTeacherOfficialCompanyDto, bool> filter = null, int takeCount = 2000)
        {
            try
            {
                var response = _teacherOfficialCompanyDal.GetList();
                var mappingResult = _mapper.Map<List<GetTeacherOfficialCompanyDto>>(response).Where(filter).Take(takeCount).ToList();
                return new SuccessDataResult<List<GetTeacherOfficialCompanyDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetTeacherOfficialCompanyDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }



        public IDataResult<int> Update(TeacherOfficialCompany teacherOfficialCompany)
        {
            try
            {
                int affectedRows = _teacherOfficialCompanyDal.Update(teacherOfficialCompany);
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



        public IDataResult<int> AddList(List<TeacherOfficialCompany> teacherOfficialCompanys)
        {
            try
            {
                int affectedRows = _teacherOfficialCompanyDal.Add(teacherOfficialCompanys);
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

        public IDataResult<int> UpdateList(List<TeacherOfficialCompany> teacherOfficialCompanys)
        {
            try
            {
                int affectedRows = _teacherOfficialCompanyDal.Update(teacherOfficialCompanys);
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

        public IDataResult<int> DeletePermanentlyList(List<TeacherOfficialCompany> teacherOfficialCompanys)
        {
            try
            {
                int affectedRows = _teacherOfficialCompanyDal.DeletePermanently(teacherOfficialCompanys);
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

        public IDataResult<int> DeleteByStatusList(List<TeacherOfficialCompany> teacherOfficialCompanys)
        {
            try
            {
                foreach (var teacherOfficialCompany in teacherOfficialCompanys)
                {
                    teacherOfficialCompany.IsActive = false;
                }

                DeleteAllEntitiesByStatusForAllRelationList(teacherOfficialCompanys);

                int affectedRows = _teacherOfficialCompanyDal.DeleteByStatus(teacherOfficialCompanys);

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

        private void DeleteAllEntitiesByStatusForAllRelationList(List<TeacherOfficialCompany> teacherOfficialCompanys)
        {
            foreach (var teacherOfficialCompany in teacherOfficialCompanys)
            {
            }
        }

        private void DeleteByStatusForAllRelation(TeacherOfficialCompany teacherOfficialCompany)
        {
        }




        #region Asynchronous

        public async Task<IDataResult<int>> AddAsync(TeacherOfficialCompany teacherOfficialCompany)
        {
            try
            {
                int affectedRows = await _teacherOfficialCompanyDal.AddAsync(teacherOfficialCompany);
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

                var deletableEntity = await _teacherOfficialCompanyDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = await _teacherOfficialCompanyDal.DeleteByStatusAsync(deletableEntity);

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

                var deletableEntity = await _teacherOfficialCompanyDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = await _teacherOfficialCompanyDal.DeletePermanentlyAsync(deletableEntity);
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

        public async Task<IDataResult<TeacherOfficialCompany>> GetAsync(Expression<Func<TeacherOfficialCompany, bool>> filter)
        {
            try
            {
                var response = await _teacherOfficialCompanyDal.GetAsync(filter);
                var mappingResult = _mapper.Map<TeacherOfficialCompany>(response);
                return new SuccessDataResult<TeacherOfficialCompany>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<TeacherOfficialCompany>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<TeacherOfficialCompany>>> GetListAsync(Expression<Func<TeacherOfficialCompany, bool>> filter = null)
        {
            try
            {
                var response = (await _teacherOfficialCompanyDal.GetAllAsQueryableAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<TeacherOfficialCompany>>(response);
                return new SuccessDataResult<List<TeacherOfficialCompany>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<TeacherOfficialCompany>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> UpdateAsync(TeacherOfficialCompany teacherOfficialCompany)
        {
            try
            {
                int affectedRows = await _teacherOfficialCompanyDal.UpdateAsync(teacherOfficialCompany);
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

        public async Task<IDataResult<int>> AddListAsync(List<TeacherOfficialCompany> officialCompanies)
        {
            try
            {
                int affectedRows = await _teacherOfficialCompanyDal.AddAsync(officialCompanies);
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

        public async Task<IDataResult<int>> UpdateListAndSaveAsync(List<TeacherOfficialCompany> officialCompanies)
        {
            try
            {
                int affectedRows = await _teacherOfficialCompanyDal.UpdateAndSaveAsync(officialCompanies);
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

        public async Task<IDataResult<int>> DeletePermanentlyListAsync(List<TeacherOfficialCompany> officialCompanies)
        {
            try
            {
                int affectedRows = await _teacherOfficialCompanyDal.DeletePermanentlyAsync(officialCompanies);
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

        public async Task<IDataResult<GetTeacherOfficialCompanyDto>> GetDtoAsync(Expression<Func<TeacherOfficialCompany, bool>> filter = null)
        {
            try
            {
                var response = await _teacherOfficialCompanyDal.GetAsync(filter);
                var mappingResult = _mapper.Map<GetTeacherOfficialCompanyDto>(response);
                return new SuccessDataResult<GetTeacherOfficialCompanyDto>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetTeacherOfficialCompanyDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<GetTeacherOfficialCompanyDto>>> GetDtoListAsync(Expression<Func<TeacherOfficialCompany, bool>> filter = null, int takeCount = 2000)
        {
            try
            {
                var response = (await _teacherOfficialCompanyDal.GetAllAsQueryableAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<GetTeacherOfficialCompanyDto>>(response).Take(takeCount).ToList();
                return new SuccessDataResult<List<GetTeacherOfficialCompanyDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetTeacherOfficialCompanyDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }


        #endregion
    }
}
