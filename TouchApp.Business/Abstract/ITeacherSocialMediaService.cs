using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface ITeacherSocialMediaService
    {
        IDataResult<IEnumerable<TeacherSocialMedia>> GetList(Expression<Func<TeacherSocialMedia, bool>> filter = null);
        IDataResult<TeacherSocialMedia> Get(Expression<Func<TeacherSocialMedia, bool>> filter);
        IDataResult<int> Add(TeacherSocialMedia teacherSocialMedia);
        IDataResult<int> Update(TeacherSocialMedia teacherSocialMedia);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<TeacherSocialMedia> teacherSocialMedias);
        IDataResult<int> UpdateList(IEnumerable<TeacherSocialMedia> teacherSocialMedias);
        IDataResult<int> DeletePermanentlyList(IEnumerable<TeacherSocialMedia> teacherSocialMedias);
        IDataResult<int> DeleteByStatusList(IEnumerable<TeacherSocialMedia> teacherSocialMedias);
    }
}
