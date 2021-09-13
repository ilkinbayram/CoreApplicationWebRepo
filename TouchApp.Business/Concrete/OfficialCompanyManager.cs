using AutoMapper;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Entities.Dtos.OfficialCompany;
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
    public class OfficialCompanyManager : IOfficialCompanyService
    {
        private readonly IOfficialCompanyDal _officialCompanyDal;
        private readonly IMapper _mapper;

        public OfficialCompanyManager(IOfficialCompanyDal officialCompanyDal, IMapper mapper)
        {
            _officialCompanyDal = officialCompanyDal;
            _mapper = mapper;
        }

        public IDataResult<int> Add(OfficialCompany officialCompany)
        {
            try
            {
                int affectedRows = _officialCompanyDal.Add(officialCompany);
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

                var deletableEntity = _officialCompanyDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = _officialCompanyDal.DeleteByStatus(deletableEntity);

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

                var deletableEntity = _officialCompanyDal.Get(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = _officialCompanyDal.DeletePermanently(deletableEntity);
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

        public IDataResult<OfficialCompany> Get(Expression<Func<OfficialCompany, bool>> filter)
        {
            try
            {
                var response = _officialCompanyDal.Get(filter);
                var mappingResult = _mapper.Map<OfficialCompany>(response);
                return new SuccessDataResult<OfficialCompany>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<OfficialCompany>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<OfficialCompany>> GetList(Expression<Func<OfficialCompany, bool>> filter = null)
        {
            try
            {
                var response = _officialCompanyDal.GetList(filter);
                var mappingResult = _mapper.Map<List<OfficialCompany>>(response);
                return new SuccessDataResult<List<OfficialCompany>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<OfficialCompany>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }



        public IDataResult<GetOfficialCompanyDto> GetDto(Func<GetOfficialCompanyDto, bool> filter = null)
        {
            try
            {
                var response = _officialCompanyDal.GetAll();
                var mappingResult = _mapper.Map<List<GetOfficialCompanyDto>>(response);
                return new SuccessDataResult<GetOfficialCompanyDto>(mappingResult.FirstOrDefault(filter));
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetOfficialCompanyDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public IDataResult<List<GetOfficialCompanyDto>> GetDtoList(Func<GetOfficialCompanyDto, bool> filter = null, int takeCount = 2000)
        {
            try
            {
                var response = _officialCompanyDal.GetList();
                var mappingResult = _mapper.Map<List<GetOfficialCompanyDto>>(response).Where(filter).Take(takeCount).ToList();
                return new SuccessDataResult<List<GetOfficialCompanyDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetOfficialCompanyDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }



        public IDataResult<int> Update(OfficialCompany officialCompany)
        {
            try
            {
                int affectedRows = _officialCompanyDal.Update(officialCompany);
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



        public IDataResult<int> AddList(List<OfficialCompany> officialCompanys)
        {
            try
            {
                int affectedRows = _officialCompanyDal.Add(officialCompanys);
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

        public IDataResult<int> UpdateList(List<OfficialCompany> officialCompanys)
        {
            try
            {
                int affectedRows = _officialCompanyDal.Update(officialCompanys);
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

        public IDataResult<int> DeletePermanentlyList(List<OfficialCompany> officialCompanys)
        {
            try
            {
                int affectedRows = _officialCompanyDal.DeletePermanently(officialCompanys);
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

        public IDataResult<int> DeleteByStatusList(List<OfficialCompany> officialCompanys)
        {
            try
            {
                foreach (var officialCompany in officialCompanys)
                {
                    officialCompany.IsActive = false;
                }

                DeleteAllEntitiesByStatusForAllRelationList(officialCompanys);

                int affectedRows = _officialCompanyDal.DeleteByStatus(officialCompanys);

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

        private void DeleteAllEntitiesByStatusForAllRelationList(List<OfficialCompany> officialCompanys)
        {
            foreach (var officialCompany in officialCompanys)
            {
            }
        }

        private void DeleteByStatusForAllRelation(OfficialCompany officialCompany)
        {
        }




        #region Asynchronous

        public async Task<IDataResult<int>> AddAsync(OfficialCompany officialCompany)
        {
            try
            {
                int affectedRows = await _officialCompanyDal.AddAsync(officialCompany);
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

                var deletableEntity = await _officialCompanyDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                DeleteByStatusForAllRelation(deletableEntity);

                deletableEntity.IsActive = false;
                int affectedRows = await _officialCompanyDal.DeleteByStatusAsync(deletableEntity);

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

                var deletableEntity = await _officialCompanyDal.GetAsync(x => x.Id == Id);

                if (deletableEntity == null)
                {
                    dataResult = new SuccessDataResult<int>(-1, Messages.DeletableDataWasNotFound);
                    return dataResult;
                }

                int affectedRows = await _officialCompanyDal.DeletePermanentlyAsync(deletableEntity);
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

        public async Task<IDataResult<OfficialCompany>> GetAsync(Expression<Func<OfficialCompany, bool>> filter)
        {
            try
            {
                var response = await _officialCompanyDal.GetAsync(filter);
                var mappingResult = _mapper.Map<OfficialCompany>(response);
                return new SuccessDataResult<OfficialCompany>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<OfficialCompany>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<OfficialCompany>>> GetListAsync(Expression<Func<OfficialCompany, bool>> filter = null)
        {
            try
            {
                var response = (await _officialCompanyDal.GetAllAsQueryableAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<OfficialCompany>>(response);
                return new SuccessDataResult<List<OfficialCompany>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<OfficialCompany>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<int>> UpdateAsync(OfficialCompany officialCompany)
        {
            try
            {
                int affectedRows = await _officialCompanyDal.UpdateAsync(officialCompany);
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

        public async Task<IDataResult<int>> AddListAsync(List<OfficialCompany> officialCompanies)
        {
            try
            {
                int affectedRows = await _officialCompanyDal.AddAsync(officialCompanies);
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

        public async Task<IDataResult<int>> UpdateListAndSaveAsync(List<OfficialCompany> officialCompanies)
        {
            try
            {
                int affectedRows = await _officialCompanyDal.UpdateAndSaveAsync(officialCompanies);
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

        public async Task<IDataResult<int>> DeletePermanentlyListAsync(List<OfficialCompany> officialCompanies)
        {
            try
            {
                int affectedRows = await _officialCompanyDal.DeletePermanentlyAsync(officialCompanies);
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

        public async Task<IDataResult<GetOfficialCompanyDto>> GetDtoAsync(Expression<Func<OfficialCompany, bool>> filter = null)
        {
            try
            {
                var response = await _officialCompanyDal.GetAsync(filter);
                var mappingResult = _mapper.Map<GetOfficialCompanyDto>(response);
                return new SuccessDataResult<GetOfficialCompanyDto>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<GetOfficialCompanyDto>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }

        public async Task<IDataResult<List<GetOfficialCompanyDto>>> GetDtoListAsync(Expression<Func<OfficialCompany, bool>> filter = null, int takeCount = 2000)
        {
            try
            {
                var response = (await _officialCompanyDal.GetAllAsQueryableAsync(filter)).ToList();
                var mappingResult = _mapper.Map<List<GetOfficialCompanyDto>>(response).Take(takeCount).ToList();
                return new SuccessDataResult<List<GetOfficialCompanyDto>>(mappingResult);
            }
            catch (Exception exception)
            {
                return new ErrorDataResult<List<GetOfficialCompanyDto>>(null, $"Exception Message: { $"Exception Message: {exception.Message} \nInner Exception: {exception.InnerException}"} \nInner Exception: {exception.InnerException}");
            }
        }


        #endregion
    }
}
