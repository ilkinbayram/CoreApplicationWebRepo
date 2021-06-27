using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TouchApp.Business.Abstract
{
    public interface IProfessionService
    {
        IDataResult<IEnumerable<Profession>> GetList(Expression<Func<Profession, bool>> filter = null);
        IDataResult<Profession> Get(Expression<Func<Profession, bool>> filter);
        IDataResult<int> Add(Profession profession);
        IDataResult<int> Update(Profession profession);
        IDataResult<int> DeletePermanently(long Id);
        IDataResult<int> DeleteByStatus(long Id);
        IDataResult<int> AddList(IEnumerable<Profession> professions);
        IDataResult<int> UpdateList(IEnumerable<Profession> professions);
        IDataResult<int> DeletePermanentlyList(IEnumerable<Profession> professions);
        IDataResult<int> DeleteByStatusList(IEnumerable<Profession> professions);
    }
}
