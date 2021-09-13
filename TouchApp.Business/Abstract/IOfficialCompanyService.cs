using Core.Entities.Concrete;
using Core.Entities.Dtos.OfficialCompany;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface IOfficialCompanyService
    {
        IDataResult<List<GetOfficialCompanyDto>> GetDtoList(Func<GetOfficialCompanyDto, bool> filter = null, int takeCount = 2000);
        IDataResult<GetOfficialCompanyDto> GetDto(Func<GetOfficialCompanyDto, bool> filter);
        IDataResult<List<OfficialCompany>> GetList(Expression<Func<OfficialCompany, bool>> filter = null);
        Task<IDataResult<List<GetOfficialCompanyDto>>> GetDtoListAsync(Expression<Func<OfficialCompany, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetOfficialCompanyDto>> GetDtoAsync(Expression<Func<OfficialCompany, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<OfficialCompany> officialCompanies);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<OfficialCompany> officialCompanies);
        Task<IDataResult<List<OfficialCompany>>> GetListAsync(Expression<Func<OfficialCompany, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<OfficialCompany> officialCompanies);
        Task<IDataResult<int>> UpdateAsync(OfficialCompany officialCompany);
        Task<IDataResult<OfficialCompany>> GetAsync(Expression<Func<OfficialCompany, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(OfficialCompany officialCompany);
        IDataResult<OfficialCompany> Get(Expression<Func<OfficialCompany, bool>> filter);
        IDataResult<int> Add(OfficialCompany officialCompany);
        IDataResult<int> Update(OfficialCompany officialCompany);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<OfficialCompany> officialCompanies);
        IDataResult<int> UpdateList(List<OfficialCompany> officialCompanies);
        IDataResult<int> DeletePermanentlyList(List<OfficialCompany> officialCompanies);
        IDataResult<int> DeleteByStatusList(List<OfficialCompany> officialCompanies);
    }
}
