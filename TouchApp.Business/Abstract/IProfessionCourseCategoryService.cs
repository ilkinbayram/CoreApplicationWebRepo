using Core.Entities.Concrete;
using Core.Entities.Dtos.ProfessionCourseCategory;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface IProfessionCourseCategoryService
    {
        IDataResult<List<ProfessionCourseCategory>> GetList(Expression<Func<ProfessionCourseCategory, bool>> filter = null);
        IDataResult<ProfessionCourseCategory> Get(Expression<Func<ProfessionCourseCategory, bool>> filter);
        IDataResult<GetProfessionCourseCategoryDto> GetDto(Expression<Func<ProfessionCourseCategory, bool>> filter = null);
        IDataResult<List<GetProfessionCourseCategoryDto>> GetListDto(Expression<Func<ProfessionCourseCategory, bool>> filter = null);
        IDataResult<int> Add(CreateManagementProfessionCourseCategoryDto professionProfessionCourseCategoryCategory);
        IDataResult<int> Update(ProfessionCourseCategory professionProfessionCourseCategoryCategory);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<ProfessionCourseCategory> professionProfessionCourseCategoryCategorys);
        IDataResult<int> UpdateList(List<ProfessionCourseCategory> professionProfessionCourseCategoryCategorys);
        IDataResult<int> DeletePermanentlyList(List<ProfessionCourseCategory> professionProfessionCourseCategoryCategorys);
        IDataResult<int> DeleteByStatusList(List<ProfessionCourseCategory> professionProfessionCourseCategoryCategorys);

        Task<IDataResult<List<GetProfessionCourseCategoryDto>>> GetDtoListAsync(Expression<Func<ProfessionCourseCategory, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetProfessionCourseCategoryDto>> GetDtoAsync(Expression<Func<ProfessionCourseCategory, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<ProfessionCourseCategory> professionCourseCategories);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<ProfessionCourseCategory> professionCourseCategories);
        Task<IDataResult<List<ProfessionCourseCategory>>> GetListAsync(Expression<Func<ProfessionCourseCategory, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<ProfessionCourseCategory> professionCourseCategories);
        Task<IDataResult<int>> UpdateAsync(ProfessionCourseCategory professionCourseCategory);
        Task<IDataResult<ProfessionCourseCategory>> GetAsync(Expression<Func<ProfessionCourseCategory, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(ProfessionCourseCategory professionCourseCategory);
    }
}
