using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface ITeacherInfoService
    {
        IDataResult<IEnumerable<TeacherInfo>> GetList(Expression<Func<TeacherInfo, bool>> filter = null);
        IDataResult<TeacherInfo> Get(Expression<Func<TeacherInfo, bool>> filter);
        IDataResult<int> Add(TeacherInfo teacherInfo);
        IDataResult<int> Update(TeacherInfo teacherInfo);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<TeacherInfo> teacherInfos);
        IDataResult<int> UpdateList(IEnumerable<TeacherInfo> teacherInfos);
        IDataResult<int> DeletePermanentlyList(IEnumerable<TeacherInfo> teacherInfos);
        IDataResult<int> DeleteByStatusList(IEnumerable<TeacherInfo> teacherInfos);
    }
}
