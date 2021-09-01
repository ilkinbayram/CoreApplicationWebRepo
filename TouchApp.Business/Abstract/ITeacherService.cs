using Core.Entities.Concrete;
using Core.Entities.Dtos.Teacher;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface ITeacherService
    {
        IDataResult<List<Teacher>> GetList(Expression<Func<Teacher, bool>> filter = null);
        IDataResult<Teacher> Get(Expression<Func<Teacher, bool>> filter);
        IDataResult<List<GetTeacherDto>> GetDtoList(Func<GetTeacherDto, bool> filter = null, int takeCount = 2000);
        IDataResult<GetTeacherDto> GetDto(Func<GetTeacherDto, bool> filter);
        IDataResult<int> Add(Teacher teacher);
        IDataResult<int> Update(Teacher teacher);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(List<Teacher> teachers);
        IDataResult<int> UpdateList(List<Teacher> teachers);
        IDataResult<int> DeletePermanentlyList(List<Teacher> teachers);
        IDataResult<int> DeleteByStatusList(List<Teacher> teachers);
    }
}
