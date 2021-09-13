using Core.Entities.Concrete;
using Core.Entities.Dtos.TeacherOfficialCompany;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface ITeacherOfficialCompanyService
    {
        IDataResult<List<GetTeacherOfficialCompanyDto>> GetDtoList(Func<GetTeacherOfficialCompanyDto, bool> filter = null, int takeCount = 2000);
        IDataResult<GetTeacherOfficialCompanyDto> GetDto(Func<GetTeacherOfficialCompanyDto, bool> filter);
        IDataResult<List<TeacherOfficialCompany>> GetList(Expression<Func<TeacherOfficialCompany, bool>> filter = null);
        Task<IDataResult<List<GetTeacherOfficialCompanyDto>>> GetDtoListAsync(Expression<Func<TeacherOfficialCompany, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetTeacherOfficialCompanyDto>> GetDtoAsync(Expression<Func<TeacherOfficialCompany, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<TeacherOfficialCompany> teacherOfficialCompanies);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<TeacherOfficialCompany> teacherOfficialCompanies);
        Task<IDataResult<List<TeacherOfficialCompany>>> GetListAsync(Expression<Func<TeacherOfficialCompany, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<TeacherOfficialCompany> teacherOfficialCompanies);
        Task<IDataResult<int>> UpdateAsync(TeacherOfficialCompany teacherOfficialCompany);
        Task<IDataResult<TeacherOfficialCompany>> GetAsync(Expression<Func<TeacherOfficialCompany, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(TeacherOfficialCompany teacherOfficialCompany);
        IDataResult<TeacherOfficialCompany> Get(Expression<Func<TeacherOfficialCompany, bool>> filter);
        IDataResult<int> Add(TeacherOfficialCompany teacherOfficialCompany);
        IDataResult<int> Update(TeacherOfficialCompany teacherOfficialCompany);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<TeacherOfficialCompany> teacherOfficialCompanies);
        IDataResult<int> UpdateList(List<TeacherOfficialCompany> teacherOfficialCompanies);
        IDataResult<int> DeletePermanentlyList(List<TeacherOfficialCompany> teacherOfficialCompanies);
        IDataResult<int> DeleteByStatusList(List<TeacherOfficialCompany> teacherOfficialCompanies);
    }
}
