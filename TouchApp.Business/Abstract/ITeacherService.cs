using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface ITeacherService
    {
        IDataResult<IEnumerable<Teacher>> GetList(Expression<Func<Teacher, bool>> filter = null);
        IDataResult<Teacher> Get(Expression<Func<Teacher, bool>> filter);
        IDataResult<int> Add(Teacher teacher);
        IDataResult<int> Update(Teacher teacher);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<Teacher> teachers);
        IDataResult<int> UpdateList(IEnumerable<Teacher> teachers);
        IDataResult<int> DeletePermanentlyList(IEnumerable<Teacher> teachers);
        IDataResult<int> DeleteByStatusList(IEnumerable<Teacher> teachers);
    }
}
