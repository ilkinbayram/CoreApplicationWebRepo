using Core.Entities.Concrete;
using Core.Entities.Dtos.TeacherSocialMedia;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TouchApp.Business.Abstract
{
    public interface ITeacherSocialMediaService
    {
        IDataResult<List<TeacherSocialMedia>> GetList(Expression<Func<TeacherSocialMedia, bool>> filter = null);
        IDataResult<TeacherSocialMedia> Get(Expression<Func<TeacherSocialMedia, bool>> filter);
        IDataResult<GetTeacherSocialMediaDto> GetDto(Expression<Func<TeacherSocialMedia, bool>> filter = null);
        IDataResult<int> Add(TeacherSocialMedia teacherSocialMedia);
        IDataResult<int> Update(TeacherSocialMedia teacherSocialMedia);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<TeacherSocialMedia> teacherSocialMedias);
        IDataResult<int> UpdateList(List<TeacherSocialMedia> teacherSocialMedias);
        IDataResult<int> DeletePermanentlyList(List<TeacherSocialMedia> teacherSocialMedias);
        IDataResult<int> DeleteByStatusList(List<TeacherSocialMedia> teacherSocialMedias);

        Task<IDataResult<List<GetTeacherSocialMediaDto>>> GetDtoListAsync(Expression<Func<TeacherSocialMedia, bool>> filter = null, int takeCount = 2000);
        Task<IDataResult<GetTeacherSocialMediaDto>> GetDtoAsync(Expression<Func<TeacherSocialMedia, bool>> filter = null);
        Task<IDataResult<int>> DeletePermanentlyListAsync(List<TeacherSocialMedia> teacherSocialMedias);
        Task<IDataResult<int>> UpdateListAndSaveAsync(List<TeacherSocialMedia> teacherSocialMedias);
        Task<IDataResult<List<TeacherSocialMedia>>> GetListAsync(Expression<Func<TeacherSocialMedia, bool>> filter = null);
        Task<IDataResult<int>> AddListAsync(List<TeacherSocialMedia> teacherSocialMedias);
        Task<IDataResult<int>> UpdateAsync(TeacherSocialMedia teacherSocialMedia);
        Task<IDataResult<TeacherSocialMedia>> GetAsync(Expression<Func<TeacherSocialMedia, bool>> filter);
        Task<IDataResult<int>> DeletePermanentlyAsync(long Id);
        Task<IDataResult<int>> DeleteByStatusAsync(long Id);
        Task<IDataResult<int>> AddAsync(TeacherSocialMedia teacherSocialMedia);
    }
}
